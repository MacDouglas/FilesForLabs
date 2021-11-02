using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using PhotoEditor.Properties;

namespace PhotoEditor
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }
      Image p_file;
      bool p_opened = false;

      private void OpenImage()
      {
         var dir = openFileDialog1.ShowDialog();
         if (dir == DialogResult.OK)
         {
            p_file = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = p_file;
            p_opened = true;
         }
      }

      void SaveImage()
      {
         if (p_opened)
         {
            SaveFileDialog sfd = new SaveFileDialog(); // create a new save file dialog object
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;// you want to store it in by default format
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               string ext = Path.GetExtension(sfd.FileName);
               switch (ext)
               {
                  case ".jpg":
                     format = ImageFormat.Jpeg;
                     break;
                  case ".bmp":
                     format = ImageFormat.Bmp;
                     break;
               }
               pictureBox1.Image.Save(sfd.FileName, format);
            }



         }
         else { MessageBox.Show("No image loaded, first upload image "); }

      }
      void Reload()
      {
         if (!p_opened)
         {
            // MessageBox.Show("Open an Image then apply changes");
         }
         else
         {
            if (p_opened)
            {
               p_file = Image.FromFile(openFileDialog1.FileName);
               pictureBox1.Image = p_file;
               p_opened = true;
            }
         }
      }
      void Hue()
      {
         var changeRed = BrightnessBar.Value * 0.1f;
         var changeGreen = BrightnessBar.Value * 0.1f;
         var changeBlue = BrightnessBar.Value * 0.1f;

         Reload();
         if (p_opened)
         {
            Image img = pictureBox1.Image;
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
               new[]{1+changeRed, 0, 0, 0, 0},
               new[]{0, 1+changeGreen, 0, 0, 0},
               new[]{0, 0, 1+changeBlue, 0, 0},
               new float[]{0, 0, 0, 1, 0},
               new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;


         }
      }
      void grayscale()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {
            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{0.299f, 0.299f, 0.299f, 0, 0},
                    new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                    new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 0}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;
         }
      }
      void fog()
      {

         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {


            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0.7f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;



         }
      }
      void flash()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {




            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{1+0.9f, 0, 0, 0, 0},
            new float[]{0, 1+1.5f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }

      }
      void Frozen()
      {

         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {


            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0f, 0, 0, 0},
            new float[]{0, 0, 1+5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }

      }
      void redscale()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {

            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }
      }
      void filter1()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {

            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{.393f, .349f, .272f+1.3f, 0, 0},
            new float[]{.769f, .686f+0.5f, .534f, 0, 0},
            new float[]{.189f+2.3f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }
      }
      void filter2()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {

            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{.393f, .349f+0.5f, .272f, 0, 0},
            new float[]{.769f+0.3f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }
      }
      void filter3()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {

            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{.393f+0.3f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f+0.2f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.9f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }
      }

      //-----------------------------------------------------------------------RED Filter ------------------------------------------------------------------------------------

      void Winter()
      {
         if (!p_opened)
         {
            MessageBox.Show("Open an Image then apply changes");
         }
         else
         {

            Image img = pictureBox1.Image;                             // storing image into img variable of image type from picturebox1
            Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   /* creating a bitmap of the height of imported picture in picturebox which consists of the pixel data for a graphics image
                                                                        and its attributes. A Bitmap is an object used to work with images defined by pixel data.*/

            ImageAttributes ia = new ImageAttributes();                 //creating an object of imageattribute ia to change the attribute of images
            ColorMatrix cmPicture = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
            {
                    new float[]{1,0,0,0,0},
                    new float[]{0,1,0,0,0},
                    new float[]{0,0,1,0,0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 1, 0, 1}
            });
            ia.SetColorMatrix(cmPicture);           //pass the color matrix to imageattribute object ia
            Graphics g = Graphics.FromImage(bmpInverted);   /*create a new object of graphics named g, ; Create graphics object for alteration.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); is the format of loading image into graphics for alteration*/

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


            /*   g.drawimage(image, new rectangle(location of rectangle axix-x, location axis-y, width of rectangle, height of rectangle),
           location of image in rectangle x-axis, location of image in rectangle y-axis, width of image, height of image,
           format of graphics unit,provide the image attributes   */


            g.Dispose();                            //Releases all resources used by this Graphics.
            pictureBox1.Image = bmpInverted;

         }
      }


      private void BrightnessBar_Scroll(object sender, EventArgs e)
      {
      }
      private void label2_Click(object sender, EventArgs e)
      {
      }
      private void Form1_Load(object sender, EventArgs e)
      {
      }
      private void button7_Click(object sender, EventArgs e)
      {
         SaveImage();
      }
      private void pictureBox1_Click(object sender, EventArgs e)
      {
      }
      private void button8_Click(object sender, EventArgs e)
      {
         OpenImage();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         BrightnessBar.Value = 0;
         Reload();
      }
      private void BrightnessBar_ValueChanged(object _sender, EventArgs _e)
      {
         Hue();
      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {
         
      }

      private void button5_Click(object sender, EventArgs e)
      {
         //OpenFileDialog ofd = new OpenFileDialog();
         //ofd.InitialDirectory = System.Environment.CurrentDirectory;
         //ofd.Filter = "Icons (*.ico)|*.ico|BMPs (*.bmp)|*.bmp|GIFs (*.gif)|*.gif|JPEGs (*.jp*)|*.jp*|PNGs (*.png)|*.png";

         var filePath = @"C:\Users\Elias\Desktop\Учеба\рамка2.png";
         if (true)
         {
            //Image img = Image.FromFile(ofd.FileName);
            Image img = Image.FromFile(filePath);
            pictureBox2.Image = new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height));

            Bitmap baseImage = (Bitmap)pictureBox1.Image;
            Bitmap overlayImage  = (Bitmap)pictureBox2.Image;
            
            var finalImage = new Bitmap(overlayImage.Width, overlayImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            
            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);
            
            pictureBox1.Image = finalImage;
         }
      }

      private void button3_Click(object sender, EventArgs e)
      {
         Reload();
         Frozen();
      }

      private void button2_Click(object sender, EventArgs e)
      {
         Reload();
         grayscale();
      }

      private void button4_Click(object sender, EventArgs e)
      {
         Reload();
         flash();
      }

      private void button6_Click(object sender, EventArgs e)
      {
         //OpenFileDialog ofd = new OpenFileDialog();
         //ofd.InitialDirectory = System.Environment.CurrentDirectory;
         //ofd.Filter = "Icons (*.ico)|*.ico|BMPs (*.bmp)|*.bmp|GIFs (*.gif)|*.gif|JPEGs (*.jp*)|*.jp*|PNGs (*.png)|*.png";

         var filePath = @"C:\Users\Elias\Desktop\Учеба\рамка1.png";
         //if (ofd.ShowDialog(this) != DialogResult.Cancel)
         if (true)
         {
            //Image img = Image.FromFile(ofd.FileName);
            Image img = Image.FromFile(filePath);
            pictureBox2.Image = new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height));

            Bitmap baseImage = (Bitmap)pictureBox1.Image;
            Bitmap overlayImage = (Bitmap)pictureBox2.Image;

            var finalImage = new Bitmap(overlayImage.Width, overlayImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            pictureBox1.Image = finalImage;
         }
      }

      private void button8_Click_1(object sender, EventArgs e)
      {
         var filePath = @"C:\Users\Elias\Desktop\Учеба\dr2.png";
         //if (ofd.ShowDialog(this) != DialogResult.Cancel)
         if (true)
         {
            //Image img = Image.FromFile(ofd.FileName);
            Image img = Image.FromFile(filePath);
            pictureBox2.Image = new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height));

            Bitmap baseImage = (Bitmap)pictureBox1.Image;
            Bitmap overlayImage = (Bitmap)pictureBox2.Image;

            var finalImage = new Bitmap(overlayImage.Width, overlayImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            pictureBox1.Image = finalImage;
         }
      }

      private void button7_Click_1(object sender, EventArgs e)
      {
         var filePath = @"C:\Users\Elias\Desktop\Учеба\смайл1.png";
         //if (ofd.ShowDialog(this) != DialogResult.Cancel)
         if (true)
         {
            //Image img = Image.FromFile(ofd.FileName);
            Image img = Image.FromFile(filePath);
            pictureBox2.Image = new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height));

            Bitmap baseImage = (Bitmap)pictureBox1.Image;
            Bitmap overlayImage = (Bitmap)pictureBox2.Image;

            var finalImage = new Bitmap(overlayImage.Width, overlayImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            pictureBox1.Image = finalImage;
         }
      }

      private void button9_Click(object sender, EventArgs e)
      {
         var filePath = @"C:\Users\Elias\Desktop\Учеба\smile2.png";
         //if (ofd.ShowDialog(this) != DialogResult.Cancel)
         if (true)
         {
            //Image img = Image.FromFile(ofd.FileName);
            Image img = Image.FromFile(filePath);
            pictureBox2.Image = new Bitmap(img, new Size(pictureBox1.Width, pictureBox1.Height));

            Bitmap baseImage = (Bitmap)pictureBox1.Image;
            Bitmap overlayImage = (Bitmap)pictureBox2.Image;

            var finalImage = new Bitmap(overlayImage.Width, overlayImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            pictureBox1.Image = finalImage;
         }
      }
   }
}


/*
      private void button1_Click(object sender, EventArgs e)
      {
         reload();
         grayscale();
      }

      private void button2_Click(object sender, EventArgs e)
      {
         reload();
      }

      private void button3_Click(object sender, EventArgs e)
      {
         OpenImage();
      }

      private void button4_Click(object sender, EventArgs e)
      {

         //pictureBox1.Image.Save(@"D:\xx.jpeg", System.Drawing.Imaging.ImageFormat.Bmp);


         saveImage();


      }

      private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
      {

      }

      private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
      {

      }

      private void button5_Click(object sender, EventArgs e)
      {
         reload();
         redscale();
      }

      private void button6_Click(object sender, EventArgs e)
      {
         reload();
         Winter();
      }

      private void groupBox1_Enter(object sender, EventArgs e)
      {

      }

      private void groupBox2_Enter(object sender, EventArgs e)
      {

      }

      private void trackBar2_Scroll(object sender, EventArgs e)
      {

      }

      private void timer1_Tick(object sender, EventArgs e)
      {




      }

      private void pictureBox1_DragOver(object sender, DragEventArgs e)
      {

      }

      private void trackBar2_ValueChanged(object sender, EventArgs e)
      {
         Hue();
      }

      private void label3_Click(object sender, EventArgs e)
      {

      }

      private void trackBar1_ValueChanged(object sender, EventArgs e)
      {
         Hue();





      }

      private void trackBar3_Scroll(object sender, EventArgs e)
      {

      }

      private void trackBar3_Scroll_1(object sender, EventArgs e)
      {
         Hue();
      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {
         saveImage();
      }

      private void toolTip1_Popup(object sender, PopupEventArgs e)
      {

      }

      private void pictureBox3_Click(object sender, EventArgs e)
      {
         OpenImage();
      }

      private void button3_Click_1(object sender, EventArgs e)
      {
         reload();
         fog();
      }

      private void button1_Click_1(object sender, EventArgs e)
      {
         reload();
         grayscale();
      }

      private void button6_Click_1(object sender, EventArgs e)
      {
         reload();
         Winter();
      }

      private void button2_Click_1(object sender, EventArgs e)
      {
         reload();
         redscale();
      }

      private void button5_Click_1(object sender, EventArgs e)
      {
         BrightnessBar.Value = 0;
         reload();
      }

      private void button4_Click_1(object sender, EventArgs e)
      {
         OpenImage();
      }

      private void button7_Click(object sender, EventArgs e)
      {
         saveImage();
      }

      private void button8_Click(object sender, EventArgs e)
      {
         reload();
         flash();
      }

      private void button9_Click(object sender, EventArgs e)
      {
         reload();
         Frozen();
      }

      private void button10_Click(object sender, EventArgs e)
      {
      }

      private void panel1_Paint(object sender, PaintEventArgs e)
      {

      }

      private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
      {

      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }
      private void label5_Click(object sender, EventArgs e)
      {

      }

      private void label4_Click(object sender, EventArgs e)
      {

      }

      private void label6_Click(object sender, EventArgs e)
      {

      }

      private void label7_Click(object sender, EventArgs e)
      {

      }

      private void pictureBox1_Click(object sender, EventArgs e)
      {

      }

      private void greenbar_Scroll(object sender, EventArgs e)
      {

      }
      private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
      { }
      private void button2_Click_2(object sender, EventArgs e)
      {
         reload();
         Frozen();
      }
      private void button3_Click_2(object sender, EventArgs e)
      {
         reload();
         fog();
      }
   }
}
*/