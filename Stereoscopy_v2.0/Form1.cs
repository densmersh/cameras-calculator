using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Stereoscopy_v2._0
{
    public partial class Form1 : Form
    {
        public static int HorResol1;
        public static int HorResol2;
        public static int VertResol1;
        public static int VertResol2;
        public static int Xleft;
        public static int Xright;

        public static double Accuracy;
        public static double Relative;

        public static int Yleft;
        public static int Yright;
        public static double Distance;
        public static double DeadZone;
        private static int CordsX;
        private static int CordsY;

        private static readonly List<Control> listtextbox = new List<Control>();

        private readonly Class1 calc = new Class1();
        private double AngleView1;
        private double AngleView2;
        private double Focus1;
        private double Focus2;
        private double HighMatrix1;
        private double HighMatrix2;
        private int HorPixelAmount1;
        private int HorPixelAmount2;
        private double PixelSize1;
        private double PixelSize2;
        private double RotationAngle1;
        private double RotationAngle2;
        private int VerticalPixelAmount1;
        private int VerticalPixelAmount2;

        private double WidthBase;
        private double WidthMatrix1;
        private double WidthMatrix2;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new[] {"1/2", "1/3", "2/3"});
            comboBox2.Items.AddRange(new[] {"1/2", "1/3", "2/3"});
            GetAllTypedControls(this, listtextbox, typeof (TextBox));
        }


        private void GetAllTypedControls(Control ctrl, List<Control> controls, Type type)
        {
            // Работаем только с элементами искомого типа   
            if (ctrl.GetType() == type)
            {
                controls.Add(ctrl);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Control ctrlChild in ctrl.Controls)
            {
                GetAllTypedControls(ctrlChild, controls, type);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            HorResol1 = Convert.ToInt32(Inspect(textBox1.Text));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AngleView1 = Convert.ToDouble(Inspect(textBox2.Text));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            HorPixelAmount1 = Convert.ToInt32(Inspect(textBox3.Text));
        }

        public double Inspect(string Text)
        {
            double textbox = 0;
            try
            {
                if (Text != "")
                {
                    textbox = Convert.ToDouble(Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return textbox;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.Enabled = false;
                textBox4.BackColor = SystemColors.Window;
                textBox5.Enabled = false;
                textBox5.BackColor = SystemColors.Window;
                textBox8.Enabled = false;
                textBox8.BackColor = SystemColors.Window;
                textBox9.Enabled = false;
                textBox9.BackColor = SystemColors.Window;
                textBox13.Enabled = false;
                textBox10.BackColor = SystemColors.Window;
                textBox10.Enabled = false;
                textBox10.BackColor = SystemColors.Window;
                textBox13.Enabled = false;
                textBox13.BackColor = SystemColors.Window;
                comboBox2.Enabled = false;
                comboBox2.BackColor = SystemColors.Window;
                checkBox3.Enabled = false;
                textBox21.Enabled = false;
                textBox21.BackColor = SystemColors.Window;
            }
            else
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox21.Enabled = true;
                checkBox3.Enabled = true;
                checkBox3.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox3.BackColor = SystemColors.Window;
                textBox6.Enabled = false;
                textBox6.BackColor = SystemColors.Window;
                textBox7.Enabled = false;
                textBox7.BackColor = SystemColors.Window;
                textBox12.Enabled = false;
                textBox12.BackColor = SystemColors.Window;
                comboBox1.Enabled = false;
                comboBox1.BackColor = SystemColors.Window;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.BackColor = SystemColors.Window;
                textBox3.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox12.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox5.Enabled = true;
                textBox8.Enabled = false;
                textBox8.BackColor = SystemColors.Window;
                textBox9.Enabled = false;
                textBox9.BackColor = SystemColors.Window;
                textBox10.Enabled = false;
                textBox10.BackColor = SystemColors.Window;
                textBox13.Enabled = false;
                textBox13.BackColor = SystemColors.Window;
                comboBox2.Enabled = false;
            }
            else
            {
                textBox5.Enabled = false;
                textBox5.BackColor = SystemColors.Window;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                comboBox2.Enabled = true;
                textBox13.Enabled = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                textBox6.Enabled = true;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                textBox9.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                textBox6.BackColor = SystemColors.Window;
                textBox6.Enabled = false;
            }
            else
            {
                textBox6.Enabled = true;
            }


            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    WidthMatrix1 = 6.4*Math.Pow(10, -3);
                    HighMatrix1 = 4.8*Math.Pow(10, -3);
                    break;

                case 1:
                    WidthMatrix1 = 4.8*Math.Pow(10, -3);
                    HighMatrix1 = 3.6*Math.Pow(10, -3);
                    break;

                case 2:
                    WidthMatrix1 = 8.8*Math.Pow(10, -3);
                    HighMatrix1 = 6.6*Math.Pow(10, -3);
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() != "")
            {
                textBox9.BackColor = SystemColors.Window;
                textBox9.Enabled = false;
            }
            else
            {
                textBox9.Enabled = true;
            }

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    WidthMatrix2 = 6.4*Math.Pow(10, -3);
                    HighMatrix2 = 4.8*Math.Pow(10, -3);
                    break;

                case 1:
                    WidthMatrix2 = 4.8*Math.Pow(10, -3);
                    HighMatrix2 = 3.6*Math.Pow(10, -3);
                    break;

                case 2:
                    WidthMatrix2 = 8.8*Math.Pow(10, -3);
                    HighMatrix2 = 6.6*Math.Pow(10, -3);
                    break;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
            }
            PixelSize1 = Convert.ToDouble(Inspect(textBox6.Text))*Math.Pow(10, -6);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Focus1 = Convert.ToDouble(Inspect(textBox7.Text))*Math.Pow(10, -3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            HorResol2 = Convert.ToInt32(Inspect(textBox4.Text));
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            AngleView2 = Convert.ToDouble(Inspect(textBox5.Text));
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            HorPixelAmount2 = Convert.ToInt32(Inspect(textBox10.Text));
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                comboBox2.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = true;
            }
            PixelSize2 = Convert.ToDouble(Inspect(textBox9.Text))*Math.Pow(10, -6);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Focus2 = Convert.ToDouble(Inspect(textBox8.Text))*Math.Pow(10, -3);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            WidthBase = Convert.ToDouble(Inspect(textBox11.Text));
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            Xleft = Convert.ToInt32(Inspect(textBox15.Text));
            if (Xleft > HorResol1)
            {
                MessageBox.Show("Координата объекта не может быть больше разрешения снимка.");
                textBox15.Clear();
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Xright = Convert.ToInt32(Inspect(textBox14.Text));
            if (Xright >= Xleft)
            {
                MessageBox.Show("Координата с правого снимка не может быть больше или равна координате с левого снимка.");
                textBox14.Clear();
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            RotationAngle1 = Convert.ToDouble(textBox6.Text);
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            RotationAngle2 = Convert.ToDouble(Inspect(textBox17.Text));
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            Yleft = Convert.ToInt32(Inspect(textBox18.Text));
            verticalBorders(Yleft, textBox18);
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            Yright = Convert.ToInt32(Inspect(textBox19.Text));
            verticalBorders(Yright, textBox19);
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
        }

        private void textBox14_Click(object sender, EventArgs e)
        {
            textBox14.Clear();
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            VerticalPixelAmount1 = Convert.ToInt32(Inspect(textBox12.Text));
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            VerticalPixelAmount2 = Convert.ToInt32(Inspect(textBox13.Text));
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
        }

        private void textBox16_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
        }

        private void textBox17_Click(object sender, EventArgs e)
        {
            textBox17.Clear();
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            textBox18.Clear();
        }

        private void textBox19_Click(object sender, EventArgs e)
        {
            textBox19.Clear();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            VertResol1 = Convert.ToInt32(Inspect(textBox20.Text));
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            VertResol2 = Convert.ToInt32(Inspect(textBox21.Text));
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            textBox20.Clear();
        }

        private void textBox22_Click(object sender, EventArgs e)
        {
            textBox22.Clear();
        }
        private void textBox21_Click(object sender, EventArgs e)
        {
            textBox21.Clear();
        }
        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            Accuracy = Convert.ToDouble(Inspect(textBox22.Text));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            for (var i = 0; i < listtextbox.Count; i++)
            {
                if (listtextbox[i].Enabled && listtextbox[i].Text == "")
                {
                    listtextbox[i].BackColor = Color.Crimson;
                }
                else if (listtextbox[i].Enabled && listtextbox[i].Text != "")
                {
                    listtextbox[i].BackColor = Color.White;
                }
            }

            if (Xleft == Xright)
            {
                MessageBox.Show("Ошибка.Координаты не могут быть одинаковыми");
                textBox14.Clear();
                textBox15.Clear();
            }
            if (!checkBox2.Checked)
            {
                AngleView1 = Math.Round(calc.AngleView(HorPixelAmount1, PixelSize1, Focus1), 3);
                if (!textBox6.Enabled)
                {
                    AngleView1 = Math.Round(calc.AngleViewD(WidthMatrix1, Focus1), 2);
                    PixelSize1 = calc.SizeElement(WidthMatrix1, HorPixelAmount1);
                }
                else
                {
                    WidthMatrix1 = PixelSize1*HorPixelAmount1;
                    HighMatrix1 = PixelSize1*VerticalPixelAmount1;
                }
            }

            if (!checkBox3.Checked)
            {
                AngleView2 = Math.Round(calc.AngleView(HorPixelAmount2, PixelSize2, Focus2), 3);
                if (!textBox9.Enabled)
                {
                    AngleView2 = Math.Round(calc.AngleViewD(WidthMatrix2, Focus2), 2);
                    PixelSize2 = calc.SizeElement(WidthMatrix2, HorPixelAmount2);
                }
                else
                {
                    WidthMatrix2 = PixelSize2*HorPixelAmount2;
                    HighMatrix2 = PixelSize2*VerticalPixelAmount2;
                }
            }

            Distance = Math.Round(calc.Distance(WidthBase, HorResol1, AngleView1, Xleft, Xright), 2);
            DeadZone = Math.Round(calc.Deadzone(WidthBase, AngleView1), 2);
            var Disparity = calc.Disparity(Xleft, Xright);

            label1.Text = string.Format("Угол обзора камеры - {0} градусов\n" +
                                        "Ширина матрицы - {1} мм\n" +
                                        "Высота матрицы - {2} мм\n" +
                                        "Размер светочувствительного элемента - {3} мкм\n" +
                                        "Фокусное расстояние объектива - {4} мм\n", AngleView1,
                WidthMatrix1*Math.Pow(10, 3), HighMatrix1*Math.Pow(10, 3), Math.Round(PixelSize1*Math.Pow(10, 6), 2),
                Focus1*Math.Pow(10, 3));

            if (!checkBox1.Checked)
            {
                label2.Text = string.Format("Угол обзора камеры - {0} градусов\n" +
                                            "Ширина матрицы - {1} мм\n" +
                                            "Высота матрицы - {2} мм\n" +
                                            "Размер светочувствительного элемента - {3} мкм\n" +
                                            "Фокусное расстояние объектива - {4} мм\n", AngleView2,
                    WidthMatrix2*Math.Pow(10, 3), HighMatrix2*Math.Pow(10, 3), Math.Round(PixelSize2*Math.Pow(10, 6), 2),
                    Focus2*Math.Pow(10, 3));
            }


            label3.Text = string.Format("Расстояние до цели - {0} метра\n" +
                                        "\n" +
                                        "Мертвая зона - {1} метра" +
                                        "\n" +
                                        "Диспаратность - {2} пикселей" +
                                        "\n"
                                        , Distance, DeadZone, Disparity);

            textBox22.BackColor = SystemColors.Window;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "0")
            {
                MessageBox.Show("Введите разрешение снимка");
            }
            else
            {
                var form = new Form2();
                form.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xleft = 0;
            Xright = 0;
            Yleft = 0;
            Yright = 0;
            openFileDialog1.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";
            openFileDialog1.ShowDialog();
            try
            {
                var imageLeft = Image.FromFile(openFileDialog1.FileName);

                var width = imageLeft.Size.Width;
                HorResol1 = width;
                textBox1.Text = HorResol1.ToString();
                var height = imageLeft.Height;
                VertResol1 = height;
                textBox20.Text = VertResol1.ToString();

                var form3 = new Form3();
                form3.Width = width;
                form3.Height = height;

                form3.ThePicture.Height = height;
                form3.ThePicture.Width = width;

                form3.ThePicture.Image = imageLeft;
                form3.ShowDialog();
                Xleft = CordsX;
                Yleft = CordsY;
                textBox15.Text = Xleft.ToString();
                textBox18.Text = Yleft.ToString();

                do
                {
                    openFileDialog1.FileName = "";
                    if (Xright >= Xleft)
                    {
                        MessageBox.Show(
                            "Координата правого снимка не может быть больше либо равной координате левого снимка. Выберите координату объекта заново на правом снимке.");
                    }
                    Xright = 0;
                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName == "")
                    {
                        break;
                    }
                    var imageRight = Image.FromFile(openFileDialog1.FileName);
                    form3.ThePicture.Image = imageRight;

                    if (!checkBox1.Checked)
                    {
                        HorResol2 = imageRight.Width;
                        textBox4.Text = HorResol2.ToString();
                        VertResol2 = imageRight.Height;
                        textBox21.Text = VertResol2.ToString();
                    }

                    form3.ShowDialog();
                    Xright = CordsX;
                    Yright = CordsY;
                } while (Xright >= Xleft);

                textBox14.Text = Xright.ToString();
                textBox19.Text = Yright.ToString();
            }
            catch (Exception)
            {
            }
        }

        public void XY(int x, int y)
        {
            CordsX = x;
            CordsY = y;
        }

        private void verticalBorders(int border, TextBox textbox)
        {
            if (border > VertResol1)
            {
                MessageBox.Show("Вертикальная координата не может быть больше чем разрешение снимка");
                textbox.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "")
            {
                textBox22.BackColor = Color.Crimson;
            }
            else
            {
                textBox22.BackColor = SystemColors.Window;
                Relative = calc.CalculateAccuracy(Accuracy, Distance);
                label3.Text = string.Format("Расстояние до цели - {0} метра\n" +
                                       "\n" +
                                       "Мертвая зона - {1} метра" +
                                       "\n" +
                                       "Диспаратность - {2} пикселей" +
                                       "\n" +
                                       "Относительная погрешность - {3} %" +
                                       "\n", Distance, DeadZone, calc.Disparity(Xleft, Xright), Math.Round(Relative,2));
            }
        }
    }
}