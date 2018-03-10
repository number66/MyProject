using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace spi_test_csharp3
{
    public partial class Form1 : Form
    {


        Bitmap image;
        private Source NEW = new Source();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_tick);
            timer1.Interval = 10; // C ВРЕМЕНЕМ ТАЙМЕРА ИГРАЕМСЯ, ЧТОБЫ НЕ БЫЛО КОЛЛИЗИИ!
            timer1.Start();
        }

        public void timer1_tick(object sender, EventArgs e)
        {
            if (!ReadButton.Enabled)
            {  
                using (MemoryStream mstream = new MemoryStream(NEW.loadImage()))
                {
                   image = new Bitmap(mstream);
                }
                pictureBox1.Image = image;
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            NEW.OpenFtdi();
            CloseButton.Enabled = true;
            ButtonOpen.Enabled = false;
            ReadButton.Enabled = true;
            ViewButton.Enabled = true;
            OpenPortBar.Value = 100;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            ButtonOpen.Enabled = true;
            CloseButton.Enabled = false;
            SaveButton.Enabled = false;
            ReadButton.Enabled = true;
            OpenPortBar.Value = 0;
            NEW.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (FileStream fstream = new FileStream("C:\\ImageSPI.jpg", FileMode.OpenOrCreate))
            {
                fstream.Write(NEW.loadImage(), 0, NEW.loadImage().Length);
                fstream.Close();
            }
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (ButtonOpen.Enabled == true)
            {
                ButtonOpen.PerformClick();
            }
            else 
            { 
                ReadButton.Enabled = false;
                SaveButton.Enabled = true;
            }
            
            
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            ReadButton.Enabled = true;
            using (FileStream fstream = new System.IO.FileStream(@"C:\\ImageSPI.jpg", FileMode.Open, FileAccess.Read))
            {
                pictureBox1.Image = Image.FromStream(fstream);
                fstream.Close();
            }
        }
    }
}
