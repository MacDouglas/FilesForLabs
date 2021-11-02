
namespace PhotoEditor
{
   partial class Form1
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.BrightnessBar = new System.Windows.Forms.TrackBar();
         this.label2 = new System.Windows.Forms.Label();
         this.SaveButton = new System.Windows.Forms.Button();
         this.OpenButton = new System.Windows.Forms.Button();
         this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.button3 = new System.Windows.Forms.Button();
         this.button4 = new System.Windows.Forms.Button();
         this.pictureBox2 = new System.Windows.Forms.PictureBox();
         this.button5 = new System.Windows.Forms.Button();
         this.button6 = new System.Windows.Forms.Button();
         this.button7 = new System.Windows.Forms.Button();
         this.button8 = new System.Windows.Forms.Button();
         this.button9 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.BrightnessBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.Location = new System.Drawing.Point(12, 12);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(1188, 548);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.SystemColors.GrayText;
         this.button1.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button1.Location = new System.Drawing.Point(124, 609);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(106, 36);
         this.button1.TabIndex = 1;
         this.button1.Text = "Отменить";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.BackColor = System.Drawing.SystemColors.GrayText;
         this.button2.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button2.Location = new System.Drawing.Point(460, 609);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(106, 36);
         this.button2.TabIndex = 2;
         this.button2.Text = "Черно-Белый";
         this.button2.UseVisualStyleBackColor = false;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // BrightnessBar
         // 
         this.BrightnessBar.BackColor = System.Drawing.SystemColors.GrayText;
         this.BrightnessBar.Location = new System.Drawing.Point(887, 596);
         this.BrightnessBar.Margin = new System.Windows.Forms.Padding(1);
         this.BrightnessBar.Maximum = 50;
         this.BrightnessBar.Name = "BrightnessBar";
         this.BrightnessBar.Size = new System.Drawing.Size(275, 45);
         this.BrightnessBar.TabIndex = 11;
         this.BrightnessBar.Scroll += new System.EventHandler(this.BrightnessBar_Scroll);
         this.BrightnessBar.ValueChanged += new System.EventHandler(this.BrightnessBar_ValueChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("JetBrains Mono Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.label2.Location = new System.Drawing.Point(987, 563);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(79, 19);
         this.label2.TabIndex = 9;
         this.label2.Text = "Яркость";
         this.label2.Click += new System.EventHandler(this.label2_Click);
         // 
         // SaveButton
         // 
         this.SaveButton.BackColor = System.Drawing.SystemColors.GrayText;
         this.SaveButton.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.SaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.SaveButton.Location = new System.Drawing.Point(12, 609);
         this.SaveButton.Name = "SaveButton";
         this.SaveButton.Size = new System.Drawing.Size(106, 36);
         this.SaveButton.TabIndex = 14;
         this.SaveButton.Text = "Save";
         this.SaveButton.UseVisualStyleBackColor = false;
         this.SaveButton.Click += new System.EventHandler(this.button7_Click);
         // 
         // OpenButton
         // 
         this.OpenButton.BackColor = System.Drawing.SystemColors.GrayText;
         this.OpenButton.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.OpenButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.OpenButton.Location = new System.Drawing.Point(12, 566);
         this.OpenButton.Name = "OpenButton";
         this.OpenButton.Size = new System.Drawing.Size(106, 36);
         this.OpenButton.TabIndex = 13;
         this.OpenButton.Text = "Open";
         this.OpenButton.UseVisualStyleBackColor = false;
         this.OpenButton.Click += new System.EventHandler(this.button8_Click);
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.FileName = "openFileDialog1";
         // 
         // button3
         // 
         this.button3.BackColor = System.Drawing.SystemColors.GrayText;
         this.button3.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button3.Location = new System.Drawing.Point(684, 609);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(106, 36);
         this.button3.TabIndex = 3;
         this.button3.Text = "Холодный";
         this.button3.UseVisualStyleBackColor = false;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // button4
         // 
         this.button4.BackColor = System.Drawing.SystemColors.GrayText;
         this.button4.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button4.Location = new System.Drawing.Point(572, 609);
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size(106, 36);
         this.button4.TabIndex = 15;
         this.button4.Text = "Осветлить";
         this.button4.UseVisualStyleBackColor = false;
         this.button4.Click += new System.EventHandler(this.button4_Click);
         // 
         // pictureBox2
         // 
         this.pictureBox2.Location = new System.Drawing.Point(12, 12);
         this.pictureBox2.Name = "pictureBox2";
         this.pictureBox2.Size = new System.Drawing.Size(694, 351);
         this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox2.TabIndex = 16;
         this.pictureBox2.TabStop = false;
         this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
         // 
         // button5
         // 
         this.button5.BackColor = System.Drawing.SystemColors.GrayText;
         this.button5.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button5.Location = new System.Drawing.Point(236, 567);
         this.button5.Name = "button5";
         this.button5.Size = new System.Drawing.Size(106, 36);
         this.button5.TabIndex = 17;
         this.button5.Text = "Рамка 1";
         this.button5.UseVisualStyleBackColor = false;
         this.button5.Click += new System.EventHandler(this.button5_Click);
         // 
         // button6
         // 
         this.button6.BackColor = System.Drawing.SystemColors.GrayText;
         this.button6.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button6.Location = new System.Drawing.Point(236, 609);
         this.button6.Name = "button6";
         this.button6.Size = new System.Drawing.Size(106, 36);
         this.button6.TabIndex = 18;
         this.button6.Text = "Рамка 2";
         this.button6.UseVisualStyleBackColor = false;
         this.button6.Click += new System.EventHandler(this.button6_Click);
         // 
         // button7
         // 
         this.button7.BackColor = System.Drawing.SystemColors.GrayText;
         this.button7.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button7.Location = new System.Drawing.Point(348, 609);
         this.button7.Name = "button7";
         this.button7.Size = new System.Drawing.Size(106, 36);
         this.button7.TabIndex = 20;
         this.button7.Text = "Смайл 2";
         this.button7.UseVisualStyleBackColor = false;
         this.button7.Click += new System.EventHandler(this.button7_Click_1);
         // 
         // button8
         // 
         this.button8.BackColor = System.Drawing.SystemColors.GrayText;
         this.button8.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button8.Location = new System.Drawing.Point(460, 566);
         this.button8.Name = "button8";
         this.button8.Size = new System.Drawing.Size(106, 36);
         this.button8.TabIndex = 19;
         this.button8.Text = "С ДР!";
         this.button8.UseVisualStyleBackColor = false;
         this.button8.Click += new System.EventHandler(this.button8_Click_1);
         // 
         // button9
         // 
         this.button9.BackColor = System.Drawing.SystemColors.GrayText;
         this.button9.Font = new System.Drawing.Font("JetBrains Mono Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.button9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.button9.Location = new System.Drawing.Point(348, 567);
         this.button9.Name = "button9";
         this.button9.Size = new System.Drawing.Size(106, 36);
         this.button9.TabIndex = 21;
         this.button9.Text = "Смайл 1";
         this.button9.UseVisualStyleBackColor = false;
         this.button9.Click += new System.EventHandler(this.button9_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Gray;
         this.ClientSize = new System.Drawing.Size(1212, 657);
         this.Controls.Add(this.button9);
         this.Controls.Add(this.button7);
         this.Controls.Add(this.button8);
         this.Controls.Add(this.button6);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.button5);
         this.Controls.Add(this.button4);
         this.Controls.Add(this.SaveButton);
         this.Controls.Add(this.OpenButton);
         this.Controls.Add(this.BrightnessBar);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.pictureBox2);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.BrightnessBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.TrackBar BrightnessBar;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button SaveButton;
      private System.Windows.Forms.Button OpenButton;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button4;
      private System.Windows.Forms.PictureBox pictureBox2;
      private System.Windows.Forms.Button button5;
      private System.Windows.Forms.Button button6;
      private System.Windows.Forms.Button button7;
      private System.Windows.Forms.Button button8;
      private System.Windows.Forms.Button button9;
   }
}

