#!/usr/bin/env python3

import os
import random
import sqlite3

import requests
import sys
from sys import argv

from typing import Optional, List

class WithExitCode(Exception):
    code: int
    name: str

    def __init__(self, msg_opt: Optional[str] = None) -> None:
        msg = ""
        if msg_opt is not None:
            msg = self.name + ": " + msg
        else:
            msg = self.name
        super().__init__(msg)

class Corrupt(WithExitCode):
    code = 102
    name = "Corrupt"

class Mumble(WithExitCode):
    code = 103
    name = "Mumble"

class Down(WithExitCode):
    code = 104
    name = "Down"

class CheckerError(WithExitCode):
    code = 110
    name = "CheckerError"

class AttackError(Exception):
    pass

PORT = 2001
DBNAME = "dumb_http.db"

# used for colored output
RED = b"31"
GREEN = b"32"

def requests_get(*args, **kwargs):
    try:
        return requests.get(*args, **kwargs)
    except:
        raise Down()

def requests_post(*args, **kwargs):
    try:
        return requests.post(*args, **kwargs)
    except:
        raise Down()


def get(hostname: str, given_id: str, flag: str) -> None:
    resp = requests_get(hostname + "/flag/" + given_id)

    try:
        data = resp.json()
        if data["status"] != "ok":
            raise Mumble()
        if flag != data["flag"]["flag"]:
            raise Corrupt()
    except:
        raise Mumble()


def put(hostname: str, flag: str) -> str:
    resp = requests_post(hostname + "/flag", json=dict(flag=flag))

    try:
        data = resp.json()
        if data["status"] != "ok":
            raise Mumble()
        return data["id"]
    except:
        raise Mumble()


def check(hostname: str) -> None:
    flag = _gen_secret()

    given_id = put(hostname, flag)
    get(hostname, given_id, flag)


def command_get(hostname: str, flag_id: str, flag: str) -> None:
    given_id = _get_id(flag_id)
    get(hostname, given_id, flag)


def command_put(hostname: str, flag_id: str, flag: str) -> None:
    given_id = put(hostname, flag)
    print('Get flag id: "{}"'.format(given_id), file=sys.stderr)
    _save_id(flag_id, given_id)


def attack(hostname: str) -> List[str]:
    resp = requests_get(hostname + "/last")

    try:
        data = resp.json()
        if data["status"] != "ok":
            raise AttackError("Error status in /last")
        ids = data["last"]
    except:
        raise AttackError("Can't get /last")

    flags = []
    for flag_id in ids:
        resp = requests_get(hostname + "/flag/" + flag_id)

        try:
            data = resp.json()
            if data["status"] != "ok":
                raise AttackError("Error status in /flag/{}".format(flag_id))
            flags.append(data["flag"]["flag"])
        except:
            raise AttackError("Can't get /flag/{}".format(flag_id))

    if len(flags) != 0:
        return flags
    raise AttackError("Got no flags")

def command_run(hostname: str):
    for _ in range(5):
        check(hostname)
        color_print("check", GREEN)
    try:
        attack(hostname)
        color_print("attack", RED)
    except AttackError as e:
        color_print("attack", GREEN)


def main() -> int:
    try:
        _prepare_db()
        cmd = argv[1]
        hostname = "http://{}:{}".format(argv[2], PORT)
        if cmd == "get":
            fid = argv[3]
            flag = argv[4]
            command_get(hostname, fid, flag)
        elif cmd == "put":
            fid = argv[3]
            flag = argv[4]
            command_put(hostname, fid, flag)
        elif cmd == "check":
            check(hostname)
        elif cmd == "attack":
            attack(hostname)
        elif cmd == "run":
            command_run(hostname)
        else:
            print("Usage: {} run|check|put|get|attack IP FLAGID FLAG".format(argv[0]))
        return 101 # code_ok
    except WithExitCode as e:
        color_print(str(e), RED)
        return e.code
    except AttackError as e:
        color_print(str(e), RED)
        return 1


def _get_db():
    return sqlite3.connect(DBNAME)


def _prepare_db():
    db = _get_db()
    c = db.cursor()
    cmd = """
            CREATE TABLE IF NOT EXISTS
                ids (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    flagid TEXT,
                    givenid TEXT
                    )"""
    c.execute(cmd)
    db.commit()


def _save_id(flag_id, given_id):
    db = _get_db()
    c = db.cursor()
    query = """
            INSERT INTO ids(flagid, givenid)
            VALUES (?,?)
            """
    c.execute(
        query,
        (
            flag_id,
            given_id,
        ),
    )
    db.commit()


def _get_id(flag_id):
    db = _get_db()
    c = db.cursor()
    query = """
                SELECT givenid FROM ids
                WHERE flagid = ?
                """
    c.execute(query, (flag_id,))
    given_id = c.fetchone()[0]
    return given_id


def _gen_secret() -> str:
    templates = [
        "I hide my {} in my {}",
        "I love to put {} into {}",
        "Do you also like {} when you are in {}?",
    ]
    places = ["secret place", "bed", "kitchen", "work", "garden"]
    items = ["fish", "dog", "secrets", "candies", "cookie", "talala"]
    template = random.choice(templates)
    return template.format(random.choice(items), random.choice(places))


def color_print(message: str, color: bytes):
    sys.stdout.buffer.write(b"\x1b[01;" + color + b"m")
    sys.stdout.buffer.flush()
    print(message)
    sys.stdout.buffer.write(b"\x1b[m")
    sys.stdout.buffer.flush()


if __name__ == "__main__":
    sys.exit(main())
