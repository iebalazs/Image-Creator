using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Creator
{
    public class Figure
    {
        private int coloumns;   // number of coloumns in the figure
        private int rows;        // number of rows in the figure

        private Image<Gray, byte> fig;  // figure to be printed

        private bool isSpotted = true; // style of drawn lines, linear or spotted, default is spotted
        private bool isContoured = false; // style of figure, contoured or shaded, default is shaded

        public int topLeftX = 5;
        public int topLeftY = 20;

        private const int resolution = 100;

        public int Cols
        {
            get { return coloumns; }
        }

        public int Rows
        {
            get { return rows; }
        }

        public bool Spotted
        {
            get { return isSpotted; }
            set { isSpotted = value; }
        }

        public bool Contoured
        {
            get { return isContoured; }
            set { isContoured = value; }
        }

        public Image<Gray, byte> Fig
        {
            get { return fig; }
            set
            {
                fig = value;
                this.coloumns = value.Width;
                this.rows = value.Height;
            }
        }

        public Figure()
        {
            this.fig = new Image<Gray, byte>(resolution, resolution);
        }

        public Figure(Image<Gray, byte> img)
        {
            fig = img;
            coloumns = img.Width;
            rows = img.Height;
        }

        public int countOnesInFig()     // count dots in the figure
        {
            int NumOfOnes = 0;
            for (int i = 0; i < fig.Rows; i++)
            {
                for (int j = 0; j < fig.Cols; j++)
                {
                    if (fig.Data[i, j, 0] == 0)
                        NumOfOnes++;
                }
            }
            return NumOfOnes;
        }

        public int countLengthOfLinesInFig()    // count the total legth of lines in the figure
        {
            int Length = 0;
            string[] States = { "Not Line", "May be Line", "Line" };
            string State = States[0];
            for (int i = 0; i < fig.Rows; i++)
            {
                for (int j = 0; j < fig.Cols; j++)
                {
                    if (fig.Data[i, j, 0] == 0 && State == States[0])
                    {
                        State = States[1];
                    }
                    else if (fig.Data[i, j, 0] == 0 && State == States[1])
                    {
                        State = States[2];
                        Length++;
                    }
                    else if (fig.Data[i, j, 0] == 0 && State == States[2])
                    {
                        Length++;
                    }
                    else State = States[0];
                }
            }
            return Length;
        }

        public double calculatePreparationTime(int NumOfOnes, int LengthOfLines)    // calculate time that needed the plotter to draw the figure
        {
            double StepSpotted = 0.74;
            double StepLinear = 0.0274;
            double b = 59;
            if (this.Spotted)
                return ((StepSpotted * NumOfOnes + b) / 60.0);
            else
            {
                return (StepSpotted * (NumOfOnes - LengthOfLines) + b + StepLinear * LengthOfLines) / 60.0;
            }
        }

        public void prepareFigure(Image<Bgr, byte> img)     // prepare figure to send
        {
            Image<Gray, byte> temp = img.Convert<Gray, byte>();
            Image<Gray, byte> result;
            bool isHeightBigger = (img.Height > img.Width ? true : false);

            if (isHeightBigger)
            {
                temp = temp.Resize((double)resolution / img.Height, Emgu.CV.CvEnum.Inter.Nearest);
            }
            else
            {
                temp = temp.Resize((double)resolution / img.Width, Emgu.CV.CvEnum.Inter.Nearest);
            }

            if (this.isContoured)
            {
                temp = temp.ThresholdBinary(new Gray(128), new Gray(255));
                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                Mat hier = new Mat();
                CvInvoke.FindContours(temp, contours, hier, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                result = new Image<Gray, byte>(temp.Width, temp.Height, new Gray(255));
                int thickness = (int)(isHeightBigger == true ? temp.Height / 100.0 : temp.Width / 100.0);
                CvInvoke.DrawContours(result, contours, -1, new MCvScalar(0, 0, 0), thickness);
            }
            else
            {
                thresholdImage(temp);
                result = shadeImage(temp);
            }

            this.fig = result;
            this.coloumns = result.Cols;
            this.rows = result.Rows;
        }

        public void thresholdImage(Image<Gray, byte> img)       // threshold image to four shade
        {
            for (int row = 0; row < img.Rows; row++)
            {
                for (int col = 0; col < img.Cols; col++)
                {
                    if (img.Data[row, col, 0] < 64)
                    {
                        img.Data[row, col, 0] = 0;
                    }
                    else if (img.Data[row, col, 0] >= 64 && img.Data[row, col, 0] < 128) { img.Data[row, col, 0] = 85; }
                    else if (img.Data[row, col, 0] >= 128 && img.Data[row, col, 0] < 192) { img.Data[row, col, 0] = 170; }
                    else { img.Data[row, col, 0] = 255; }
                }
            }
        }

        public Image<Gray, byte> shadeImage(Image<Gray, byte> img)  // calculate dots in the figure based on the shades
        {
            Image<Gray, byte> result = new Image<Gray, byte>(img.Width, img.Height, new Gray(255));
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    if (img.Data[row, col, 0] == 85 && isDarkGrayPosition(row, col))
                    {
                        result.Data[row, col, 0] = 0;
                    }
                    else if (img.Data[row, col, 0] == 170 && isLightGrayPosition(row, col))
                    {
                        result.Data[row, col, 0] = 0;
                    }
                    else
                    {
                        if (img.Data[row, col, 0] == 0)
                            result.Data[row, col, 0] = 0;
                    }
                }
            }

            return result;
        }

        public bool isDarkGrayPosition(int row, int col)        // calculate dots' positions that represent dark gray shade
        {
            if ((row % 2 == 0) && (col % 2 == 0)) { return true; }
            else if ((row % 2 == 1) && (col % 2 == 1)) { return true; }
            else return false;
        }

        public bool isLightGrayPosition(int row, int col)       // calculate dots' positions that represent light gray shade
        {
            if ((row % 4 == 0) && (col % 2 == 0)) { return true; }
            else if ((row + 2) % 4 == 0 && (col % 2 == 1)) { return true; }
            else return false;
        }


        public void drawFigure(Graphics g)      // draw the figure on a separate form
        {
            g.DrawString("Approximate Preparation Time: " + String.Format("{0:0.0}", calculatePreparationTime(countOnesInFig(), countLengthOfLinesInFig())) + " minutes",
                new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 0, 0);
            double thickness = 6;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (fig.Data[row, col, 0] == 0)
                    {
                        if (isSpotted)
                            g.FillEllipse(Brushes.Black, (int)(topLeftX + col * thickness),
                            (int)(topLeftY + row * thickness), (int)thickness, (int)thickness);
                        else
                        {
                            g.FillRectangle(Brushes.Black, (int)(topLeftX + col * thickness),
                            (int)(topLeftY + row * thickness), (int)thickness, (int)thickness);
                        }
                    }
                }
            }
        }

    }
}
