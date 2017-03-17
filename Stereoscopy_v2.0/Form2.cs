using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stereoscopy_v2._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Bitmap btmFront = new Bitmap(1155, 606);     //фон
            Graphics grFront = Graphics.FromImage(btmFront);  
            pictureBox1.Image = btmFront;
            Pen pen = new Pen(Color.FromArgb(150, 255, 0, 0));
            //camera 1
            

            grFront.DrawRectangle(pen, pictureBox1.Width/2 - 50, pictureBox1.Bottom/2 + 100, 10, 20);
            grFront.DrawLine(pen, pictureBox1.Width/2 - 50 + 5, pictureBox1.Bottom / 2 + 100, pictureBox1.Width / 2 - 150, 0);
            grFront.DrawLine(pen, pictureBox1.Width / 2 - 50 + 5, pictureBox1.Bottom / 2 + 100, pictureBox1.Width / 2 +50, 0);
            //camera left
            grFront.DrawRectangle(pen, 0, pictureBox1.Bottom / 2 + 80, 140, 95);

            //camera 2
            grFront.DrawRectangle(pen, pictureBox1.Width / 2 + 50, pictureBox1.Bottom / 2 + 100, 10, 20);
            grFront.DrawLine(pen, pictureBox1.Width / 2 + 50 + 5, pictureBox1.Bottom / 2 + 100, pictureBox1.Width / 2 - 50, 0);
            grFront.DrawLine(pen, pictureBox1.Width / 2 + 50 + 5, pictureBox1.Bottom / 2 + 100, pictureBox1.Width / 2 + 150, 0);
            grFront.DrawArc(pen, 317, 258, 57, 20, 0, -180);
            grFront.DrawArc(pen, 417, 258, 57, 20, 0, -180);
            //camera right
            grFront.DrawRectangle(pen, 145, pictureBox1.Bottom / 2 + 80, 140, 95);

            //camera 3 and object
            grFront.DrawRectangle(pen, 10, pictureBox1.Bottom -25, 20, 10);
            grFront.DrawArc(pen, pictureBox1.Width - 20, pictureBox1.Bottom - 49 +(int)(Form1.Yleft*45/Form1.VertResol1), 4, 4, 0, 360);


            //view 1
            grFront.DrawRectangle(pen,0,pictureBox1.Height-100,pictureBox1.Width-1,99);

            //distance line
            grFront.DrawLine(pen, pictureBox1.Width / 2 + 170, pictureBox1.Bottom / 2 + 120, pictureBox1.Width / 2 + 170, 100);
            grFront.DrawLine(pen, pictureBox1.Width / 2 + 160, pictureBox1.Bottom / 2 + 120, pictureBox1.Width / 2 + 180, pictureBox1.Bottom / 2 + 120);
            grFront.DrawLine(pen, pictureBox1.Width / 2 + 160, 100, pictureBox1.Width / 2 + 180, 100);

            try
            {
                grFront.DrawArc(pen, pictureBox1.Width/2 - 20 + Form1.Xleft*40/Form1.HorResol1, 100, 4, 4, 0, 360);
                //in rect
                //cam1
                grFront.DrawArc(pen, 0 + Form1.Xleft*135/Form1.HorResol1, pictureBox1.Bottom/2 + 80 + Form1.Yleft * 90 / Form1.VertResol1, 4, 4, 0, 360);
                //cam2
                if (Form1.HorResol2 == 0)
                {//if cameras the same to each other
                    grFront.DrawArc(pen, 145 + Form1.Xright*135 /Form1.HorResol1, pictureBox1.Bottom/2 + 80 + Form1.Yright * 90 / Form1.VertResol1,50, 4, 0,360);
                }
                else
                { //not the same
                    grFront.DrawArc(pen, 145 + Form1.Xright * 135 / Form1.HorResol2, pictureBox1.Bottom / 2 + 80 + Form1.Yright * 90 / Form1.VertResol2, 4, 4, 0, 360);
                }
                
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Введите разрешение снимка");
            }


            pictureBox1.Refresh();

            label1.Text = " Мертвая \n     зона\n" + "    "+Form1.DeadZone.ToString() + "\n метр(а)ов";
            label2.Text =  "Дальность - " + Form1.Distance.ToString() + " метр(а)ов";

        }

    }
}
