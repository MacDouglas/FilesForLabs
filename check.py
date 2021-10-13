#!/usr/bin/env python3

import os
import random
import sqlite3

import requests
import sys
from sys import argv

CODES = {"OK": 101, "CORRUPT": 102, "MUMBLE": 103, "DOWN": 104, "CHECKER_ERROR": 110}

LOG = True

PORT = 2001
DBNAME = "dumb_http.db"

# Add error descriptions here.
BAD_EVENTS = {
    "conn": ("Unable to connect to the service", CODES["DOWN"]),
    "prot": ("Server doesn't answers properly", CODES["MUMBLE"]),
    "flggg": ("Wrong flag", CODES["CORRUPT"]),
    "wtf": ("Man, you should correct your checker", CODES["CHECKER_ERROR"]),
}

RED = b"31"
GREEN = b"32"


def check(hostname):
    flag = _gen_secret()

    given_id = _put(hostname, flag)
    _get(hostname, given_id, flag)

    return _undie("checked")


def _get(hostname, given_id, flag):
    try:
        resp = requests.get(hostname + "/flag/" + given_id)
    except:
        _die("conn")

    try:
        data = resp.json()
        if data["status"] != "ok":
            _die("prot")
        if flag != data["flag"]["flag"]:
            _die("flggg")
    except:
        _die("prot")


def get(hostname, flag_id, flag):
    given_id = _get_id(flag_id)
    _get(hostname, given_id, flag)
    return _undie("getting")


def _put(hostname, flag):
    try:
        resp = requests.post(hostname + "/flag", json=dict(flag=flag))
    except:
        _die("conn")

    try:
        data = resp.json()
        if data["status"] != "ok":
            _die("prot")
        return data["id"]
    except:
        _die("prot")


def put(hostname, flag_id, flag):
    given_id = _put(hostname, flag)
    _log('Get flag id: "{}"'.format(given_id))
    _save_id(flag_id, given_id)

    return _undie("putting")

def attack(hostname):
    try:
        resp = requests.get(hostname + "/last")
    except:
        _die("conn")

    try:
        data = resp.json()
        if data["status"] != "ok":
            _die("prot")
        ids = data["last"]
    except:
        return _undie("attacking")

    flags = []
    for flag_id in ids:
        try:
            resp = requests.get(hostname + "/flag/" + flag_id)
        except:
            _die("conn")

        try:
            data = resp.json()
            if data["status"] != "ok":
                _die("prot")
            flags.append(data["flag"]["flag"])
        except:
            return _undie("attacking")

    if len(flags) != 0:
        print(flags)
        return _undie("attacking", color=RED)
    return _undie("attacking")

def run(hostname):
    for _ in range(5):
        check(hostname)
    return attack(hostname)


def main():
    try:
        _prepare_db()
        cmd = argv[1]
        hostname = "http://{}:{}".format(argv[2], PORT)
        if cmd == "get":
            fid = argv[3]
            flag = argv[4]
            return get(hostname, fid, flag)
        elif cmd == "put":
            fid = argv[3]
            flag = argv[4]
            return put(hostname, fid, flag)
        elif cmd == "check":
            return check(hostname)
        elif cmd == "attack":
            return attack(hostname)
        elif cmd == "run":
            return run(hostname)
        else:
            return _die("wtf")
    except Exception as e:
        print("Usage: %s run|check|put|get|attack IP FLAGID FLAG" % argv[0])
        return _die("conn")


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


def _gen_secret():
    templates = [
        "I hide my {} in my {}",
        "I love to put {} into {}",
        "Do you also like {} when you are in {}?",
    ]
    places = ["secret place", "bed", "kitchen", "work", "garden"]
    items = ["fish", "dog", "secrets", "candies", "cookie", "talala"]
    template = random.choice(templates)
    return template.format(random.choice(items), random.choice(places))


def _log(t):
    if LOG:
        print(t, file=sys.stderr)
    return t


def _die(event):
    if event not in BAD_EVENTS:
        exit(CODES["CHECKER_ERROR"])
    msg, code = BAD_EVENTS[event]
    _log(msg)
    exit(code)

def _undie(message: str, color=GREEN):
    sys.stdout.buffer.write(b"\x1b[01;" + color + b"m")
    sys.stdout.buffer.flush()
    print(message)
    sys.stdout.buffer.write(b"\x1b[m")
    sys.stdout.buffer.flush()


if __name__ == "__main__":
    _die(main())
