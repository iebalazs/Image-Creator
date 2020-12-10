using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Creator
{
    public class Uart
    {
        SerialPort serialPort;

        public SerialPort Port {
            get { return serialPort; }
        }

        public Uart() {
            serialPort = new SerialPort();

            serialPort.BaudRate = 115200;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.DataBits = 8;
        }

        public void ConnectPort() {
            if (serialPort.IsOpen == false)
                serialPort.Open();
        }

        public void UnConnectPort() {
            try {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString(), "Error closing Port");
            }
        }

        public byte[] prepareFigToSend(Image<Gray, byte> figure, bool isSpotted) {
            byte[] FigToSend = new byte[1252];          //[(int)(Math.Ceiling((double)figure.Cols * figure.Rows/8) + 2)];
            int NumOfBytes = (int)(Math.Ceiling((double)figure.Cols * figure.Rows / 8));    // number of bytes that represent the figure
            char[] FigAsArray = new char[NumOfBytes*8];                         // array that contains the figure in characters
            FigToSend[0] = (byte)(figure.Rows + (isSpotted==true ? 1 : 0)*128); // first bit of first byte(whitch is number of rows) informs about if the figure is spotted or not
            FigToSend[1] = (byte)(figure.Cols);                                // second byte is the number of columns of the figure
            for (int row = 0; row < figure.Rows; row++) {
                for (int col = 0; col < figure.Cols; col++) {
                    if (figure.Data[row, col, 0] == 0)
                    {
                        FigAsArray[row*figure.Cols+col] = '1';
                    }
                    else {
                        FigAsArray[row*figure.Cols+col] = '0';
                    }
                }
            }

            for (int residue = figure.Cols*figure.Rows; residue < FigAsArray.Length; residue++) {       // fill the other chars with 0
                FigAsArray[residue] = '0';
            }

            string FigAsString = new string(FigAsArray);        // figure as string

            for (int i = 0; i < NumOfBytes; i++) {              // fill the array with bytes that represent the figure
                FigToSend[i+2] = Convert.ToByte(FigAsString.Substring(i * 8, 8), 2);
            }

            for (int j=NumOfBytes+2; j<1252; j++) {               // fill the other bytes with 0.
                FigToSend[j] = 0;
            }

            return FigToSend;
        }

        public void Send(Image<Gray, byte> figure, bool isSpotted) {
            byte[] figToSend = prepareFigToSend(figure, isSpotted);
            serialPort.DiscardOutBuffer();
            serialPort.Write(figToSend, 0, figToSend.Length);
        }

    }
}
