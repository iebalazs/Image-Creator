using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Image_Creator
{
    public partial class MainForm : Form
    {

        Image<Bgr, byte> img;   // selected image from local computer

        Figure fig = new Figure();  // Figure that manages figure to be drawn

        bool isImageSelected = false;   // true if an image is selected

        bool isPortSelected = false;    // true if port is selected

        Uart uart = new Uart();     // Uart for communication with microcontroller

        public MainForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)      // event handler function for clicking "Open Image" button
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = new Image<Bgr, byte>(dialog.FileName);
                    pictureBox1.Image = img.ToBitmap();
                }
                catch (Exception ex) {
                    MessageBox.Show("The format of the selected file is not correct.", "Invalid format");
                }
            }
            isImageSelected = true;
        }

        public void setSettings()   // function for settings
        {
            if (radioButtonContoured.Checked)     // select style
                fig.Contoured = true;
            else { fig.Contoured = false; }

            if (radioButtonSpotted.Checked)       // select line style
                fig.Spotted = true;
            else { fig.Spotted = false; }
        }

        private void showButton_Click(object sender, EventArgs e)   // event handler function for showing figure
        {
            if (isImageSelected)
            {
                setSettings();              // set selected styles
                fig.prepareFigure(img);     // prepare figure

                Form FigureForm = new Form();
                FigureForm.Show();
                FigureForm.Text = "Figure";
                FigureForm.ClientSize = new System.Drawing.Size(610, 610);
                fig.drawFigure(FigureForm.CreateGraphics());        // draw figure to form
            }
            else { MessageBox.Show("Image is not selected. Press 'Open Image' button.", "Open Image"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)     // event handler function for selecting COM port
        {
            this.uart.Port.PortName = comboBox1.Text;
            this.isPortSelected = true;
        }

        private void timer1_Tick(object sender, EventArgs e)        // event handler function for tick of timer
        {
            if (this.progressBar1.Value < 100)
                this.progressBar1.Value += 1;
            else {
                this.progressBar1.Value = 0;
                this.timer1.Stop();
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)   // event handler function for clicking "Draw Figure" button
        {
            if (isImageSelected && isPortSelected)
            {
                setSettings();
                fig.prepareFigure(img);

                this.timer1.Interval = (int)fig.calculatePreparationTime(fig.countOnesInFig(), fig.countLengthOfLinesInFig()) * 60 * 10;

                try
                {
                    uart.ConnectPort();
                    uart.Send(fig.Fig, fig.Spotted);

                    timer1.Start();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString(), "Error opening port");
                }
            }
            else { MessageBox.Show("Select COM Port and Image before Drawing.", "Info"); }
        }

    }
}
