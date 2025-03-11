using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.IO;

namespace MCKDS
{
    class clsCOMDataReader
    {
        protected static System.IO.Ports.SerialPort _serialPort;
        //[DllImport("user32.dll")]
        private delegate void SetTextDeleg(string text);
        public event System.IO.Ports.SerialDataReceivedEventHandler comDataReceived;

        public bool OpenPort()
        {
            try
            {
                //_serialPort = new System.IO.Ports.SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

                string filepath = @"Settings.txt";

                string[] lines = File.ReadAllLines(filepath);
                string commport = lines[3].Substring(2, lines[3].Length - 2);

                if (commport != "")
                {
                    _serialPort = new System.IO.Ports.SerialPort(commport, 9600, Parity.None, 8, StopBits.One);
                    _serialPort.Handshake = Handshake.None;
                    _serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(sp_DataReceived);
                    _serialPort.Open();
                    _serialPort.RtsEnable = true;
                    _serialPort.DtrEnable = true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                this.comDataReceived(sender, e);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public void close()
        {
            try
            {
               // _serialPort.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
