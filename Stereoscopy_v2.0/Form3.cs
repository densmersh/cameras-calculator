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
    public partial class Form3 : Form
    {

        public int relativePointX = 0;
        public int relativePointY = 0;


        public Form3()
        {
            InitializeComponent();
        }

        public PictureBox ThePicture
        {
            get { return this.pictureBox1; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            relativePointX = PointToClient(Cursor.Position).X;
            relativePointY = PointToClient(Cursor.Position).Y;

            Form1 form1 = new Form1();
            form1.XY(relativePointX,relativePointY);
            Close();
        }
    }
}
