using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stereoscopy_v2._0
{
    class Class1
    {
        public double AngleView(int Resolution,double ElementSize, double Focus) { 
            double SizeMatrix = Resolution * ElementSize;
            double Angle = 2 * Math.Atan(SizeMatrix / 2 / Focus) * 180 / Math.PI;
            return Angle;
        }

        public double Distance(double WidthBase, int Resolution, double Angle,int Xleft,int Xright)
        {
            
            double Distance = Math.Round(WidthBase * Resolution / (2 * Math.Tan(Angle / (2 * 180 / Math.PI)) * (Xleft - Xright)));
            return Distance;
        }

        public double Deadzone(double WidthBase, double Angle)
        {
            double DeadZone = WidthBase / 2 / Math.Tan(Angle / 2 / 180 * Math.PI);
            return DeadZone;
        }

        public double AngleViewD(double SizeMatrix, double Focus)
        {
            double Angle = 2 * Math.Atan(SizeMatrix / 2 / Focus) * 180 / Math.PI;
            return Angle;
        }

        public double SizeElement(double WidthMatrix, int HorPixelAmount)
        {
            double SizeElement = WidthMatrix/HorPixelAmount;
            return SizeElement;
        }

        public int Disparity(int Xleft, int Xright)
        {
            int Disparity = Xleft - Xright;
            return Disparity;
        }

        public double CalculateAccuracy(double Accuracy, double Distance)
        {
            double Absolut = Accuracy - Distance;
            double Relative = Absolut / Accuracy * 100;
            return Relative;
        }
    }
}
