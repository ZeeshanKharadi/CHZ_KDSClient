using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MCKDS
{
    public partial class FryingStation : MetroFramework.Forms.MetroForm
    {
        private clsCOMDataReader ComDataRead;
        private int iCurrentRowIndx;


        private const int cNeedtoFryCell = 2;
        private const int cCumFriedQtyCell = 3;
        private const int cOnHandCell = 4;
        private const int cFriedQtyCell = 5;
        private const int cItemCell = 6;
        //private const int cFromDateCell = 10;
        //private const int cToDateCell = 11;

        //private string currentTime
        public FryingStation()
        {
            InitializeComponent();
        }

        private void FryingStation_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = DateTime.Now.Day + " " + DateTime.Now.ToString("MMMM, yyyy");
                label3.Text = System.DateTime.Now.ToString("dddd");
                label1.Text = " FRYING STATION";
                // TODO: This line of code loads data into the 'mCKDSDataSet.Item' table. You can move, or remove it, as needed.
                metroGrid1.AutoGenerateColumns = false;
                this.itemTableAdapter1.Fill(this.mCKDSDataSet.Item);
               
                this.metroGrid1.Columns["ItemName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
               // this.metroGrid1.Columns["ProjectedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.metroGrid1.Columns["NeedtoFry"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.metroGrid1.Columns["CumulativeFriedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.metroGrid1.Columns["OnHand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.metroGrid1.Columns["FriedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                ErrorMessageHandler("Unable to Connect KDS Server", ex);
            }
            try
            {
                CurRow.Text = "0";
                ComDataRead = new clsCOMDataReader();
                ComDataRead.OpenPort();
                ComDataRead.comDataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comdata_read);
            }
            catch (Exception ex)
            {
                ErrorMessageHandler("Unable to Open COM Port", ex);
            }
            //SetProjectedTimePeriod();
        }


        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //metroGrid1.Rows[0].Selected = true;
                if (metroGrid1.CurrentCell != null)
                    metroGrid1.CurrentCell = metroGrid1.Rows[metroGrid1.SelectedRows[0].Index].Cells[cFriedQtyCell];
            }
            catch (Exception)
            {

            }
        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (metroGrid1.CurrentRow != null)
                {
                    //iCurrentRowIndx = metroGrid1.CurrentRow.Index;
                    iCurrentRowIndx = metroGrid1.SelectedRows[0].Index;
                    CurRow.Text = metroGrid1.SelectedRows[0].Index.ToString();
                    //CurrentTimePeriod.Text = metroGrid1.CurrentRow.Index.ToString();

                    if ((metroGrid1.CurrentRow != null) & metroGrid1.CurrentCell.ColumnIndex != cFriedQtyCell)
                        SetSelectedRow(iCurrentRowIndx);
                }
            }
            catch (Exception) { }
        }

        private void SetSelectedRow(int pIndex)
        {
            metroGrid1.CurrentCell = metroGrid1.Rows[pIndex].Cells[cFriedQtyCell];

        }
        private void updateOnHandQuantity()
        {

            int onHand;
            int inputFried;
            int Projected;
            int cumlativefried;
            int NeedtoFry;
            string ItemId;
            try
            {
                if ((metroGrid1.CurrentRow.Cells[cFriedQtyCell].EditedFormattedValue != null) && (metroGrid1.CurrentRow.Cells[cFriedQtyCell].EditedFormattedValue != ""))
                {

                    if ((metroGrid1.CurrentRow.Cells[cItemCell].Value != null) && (metroGrid1.CurrentRow.Cells[cItemCell].EditedFormattedValue != ""))
                    {
                        ItemId = metroGrid1.CurrentRow.Cells[cItemCell].Value.ToString();

                        inputFried = getcellValue(metroGrid1.CurrentRow.Cells[cFriedQtyCell]);
                        //Projected = getcellValue(metroGrid1.CurrentRow.Cells[cProjectedCell]);
                        NeedtoFry = getcellValue(metroGrid1.CurrentRow.Cells[cNeedtoFryCell]);
                        cumlativefried = getcellValue(metroGrid1.CurrentRow.Cells[cCumFriedQtyCell]);
                        onHand = getcellValue(metroGrid1.CurrentRow.Cells[cOnHandCell]);


                        onHand += inputFried;
                        //NeedtoFry -= inputFried;
                        cumlativefried += inputFried;


                        //metroGrid1.CurrentRow.Cells[cCumFriedQtyCell].Value = cumlativefried.ToString();


                        //metroGrid1.CurrentRow.Cells[cNeedtoFryCell].Value = NeedtoFry.ToString();
                        //metroGrid1.CurrentRow.Cells[cOnHandCell].Value = onHand.ToString();
                        metroGrid1.CurrentRow.Cells[cFriedQtyCell].Value = "";
                        Save(ItemId, onHand, cumlativefried, inputFried);
                        dbClass dbcls = new dbClass();
                        dbcls.UpdateOrderStatustoPreparation(ItemId, inputFried, onHand);
                        GridRefresh();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        private int getcellValue(DataGridViewCell cell)
        {
            int rValue = 0;
            if ((cell.Value != null) && (cell.Value.ToString() != ""))
            {
                //Validation for Numeric vlaue
                rValue = int.Parse(cell.Value.ToString());

            }
            return rValue;
        }

        private void metroGrid1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (metroGrid1.CurrentCell.ColumnIndex == cFriedQtyCell)
                updateOnHandQuantity();

        }

        private void Save(string ItemId, int pOnHand, int pCumlativefried, int pInputFried)
        {

            dbClass dbcls = new dbClass();
            dbcls.UpdateOnHand(ItemId, pOnHand, pCumlativefried, pInputFried);



        }

        private void GridRefresh()
        {
            label2.Text = DateTime.Now.Day + " " + DateTime.Now.ToString("MMMM, yyyy");
            label3.Text = System.DateTime.Now.ToString("dddd");
            int cIndex = iCurrentRowIndx;
            if (ReFillGrid())
            {
                //SetProjectedTimePeriod();
                try
                {
                    if (cIndex != 0)
                    {
                        //metroGrid1.CurrentRow.Index = iCurrentRowIndx;
                        metroGrid1.Rows[cIndex].Selected = true;
                        SetSelectedRow(cIndex);
                        iCurrentRowIndx = cIndex;
                    }
                }
                catch (Exception)
                {
                    iCurrentRowIndx = 0;
                }
            }
        }
        private void SetProjectedTimePeriod()
        {
            CurrentTimePeriod.Text = "Current Time Slot: ";
            //try
            //{
            //    if (metroGrid1.Rows.Count > 0)
            //        if ((metroGrid1.Rows[0].Cells[cFromDateCell].EditedFormattedValue != null) && (metroGrid1.Rows[0].Cells[cFromDateCell].EditedFormattedValue != ""))
            //        {
            //            CurrentTimePeriod.Text += metroGrid1.Rows[0].Cells[cFromDateCell].Value.ToString();

            //            if ((metroGrid1.Rows[0].Cells[cToDateCell].Value != null) && (metroGrid1.Rows[0].Cells[cToDateCell].EditedFormattedValue != ""))
            //            {
            //                CurrentTimePeriod.Text += " : " + metroGrid1.Rows[0].Cells[cToDateCell].Value.ToString();

            //            }
            //            metroGrid1.Columns[4].HeaderText = "Projection   " + metroGrid1.Rows[0].Cells["CSlot"].Value.ToString();
            //            metroGrid1.Columns[3].HeaderText = "Projection   " + metroGrid1.Rows[0].Cells["Slot1"].Value.ToString();
            //            metroGrid1.Columns[2].HeaderText = "Projection   " + metroGrid1.Rows[0].Cells["Slot2"].Value.ToString();

            //        }
            //}
            //catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.Message); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //CurrentTimePeriod.Text = DateTime.Now.ToLongTimeString();

        }

        private void tmRefreshScreen_Tick(object sender, EventArgs e)
        {
            GridRefresh();

        }

        private void Grid_KeyPress(object sender, KeyPressEventArgs e)
        {

            //KeyMapping(e.KeyChar);

        }

        private void FringStationForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyMapping(e.KeyChar);
        }
        


        public void KeyMapping(char inputkey)
        {
            switch (inputkey)
            {
                case 'a':
                case '1':
                    InvokeKeyPress('1');
                    break;
                case 'b':
                case '5':
                    InvokeKeyPress('5');
                    break;
                case 'c':
                case '2':
                    InvokeKeyPress('2');
                    break;
                case 'd':
                case '6':
                    InvokeKeyPress('6');
                    break;
                case 'e':
                case '3':
                    InvokeKeyPress('3');
                    break;
                case 'f':
                case '7':
                    InvokeKeyPress('7');
                    break;
                case 'g':
                case '4':
                    InvokeKeyPress('4');
                    break;
                case 'h':
                case '8':
                    InvokeKeyPress('8');
                    break;
                case 'i':
                case '0':
                    InvokeKeyPress('0');
                    break;
                case 'j':
                    InvokeKeyPress('9');
                    break;
                case 'k':
                case '+':
                    //InvokeKeyPress((Char)Keys.Up);
                    metroGrid1.Focus();
                    SendKeys.Send("{UP}");
                    break;
                case 'l':
                case (char)Keys.Back:
                    //InvokeKeyPress((Char)Keys.Down);
                    metroGrid1.Focus();
                    SendKeys.Send("{DOWN}");
                    break;
                case 'm':
                    break;
                case 'n':
                case (char)Keys.Enter:
                    updateOnHandQuantity();
                    //metroGrid1.Focus();
                    //SendKeys.Send("{ENTER}");
                    //updateOnHandQuantity();

                    //InvokeKeyPress((Char)Keys.Enter);
                    //SaveFriedItem();

                    break;
                case 'o':
                    break;
                case 'p':
                    break;
                default:
                    break;


            }
        }
        private void InvokeKeyPress(Char pKeyPressed)
        {
            TakeInput(pKeyPressed.ToString());
            //metroGrid1.Focus();
            //SendKeys.Send(pKeyPressed.ToString());
            //KeyPressEventArgs kPEA = new KeyPressEventArgs(pKeyPressed);
            //metroGrid1.Invoke(new Action(() => this.OnKeyPress(kPEA)));

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ////capture up arrow key
            //if (keyData == Keys.Up)
            //{
            //    //MessageBox.Show("You pressed Up arrow key");
            //    return true;
            //}
            ////capture down arrow key
            //if (keyData == Keys.Down)
            //{
            //    //MessageBox.Show("You pressed Down arrow key");
            //    return true;
            //}
            //capture left arrow key
            //if (keyData == Keys.Left)
            //{
            //    KeyMapping((char)keyData);

            //    return true;
            //}
            ////capture right arrow key
            //if (keyData == Keys.Right)
            //{
            //    KeyMapping((char)keyData);

            //    return true;
            //}
            //capture right arrow key
            if (keyData == Keys.Add)
            {
                KeyMapping((char)keyData);

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void comdata_read(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                SerialPort sp = (SerialPort)sender;
                string value = sp.ReadExisting();

                KeyPressEventArgs ke = new KeyPressEventArgs(value[0]);
                this.Invoke(new Action(() => this.OnKeyPress(ke)));
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void TakeInput(string pInput)
        {
            object curValue = metroGrid1.Rows[iCurrentRowIndx].Cells[cFriedQtyCell].Value;
            
            if (curValue != null)
            {
                string newValue = curValue.ToString() + pInput;
                metroGrid1.Rows[iCurrentRowIndx].Cells[cFriedQtyCell].Value = newValue;
            }
            else
                metroGrid1.Rows[iCurrentRowIndx].Cells[cFriedQtyCell].Value = pInput;
        }
        public void SaveFriedItem()
        {
            metroGrid1_SelectionChanged(null, null);
            MessageBox.Show("Save Button Pressed");
        }
        private void OrderGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComDataRead != null)
                ComDataRead.close();

            this.Dispose(true);
        }




        private bool ReFillGrid()
        {
            try
            {
                dbClass dbc = new dbClass();
                dbc.ResetComulativeFried();

                this.itemTableAdapter1.Fill(this.mCKDSDataSet.Item);
                ClearMsgtoPanel();


                return true;
            }
            catch (System.Exception ex)
            {
                ErrorMessageHandler("Unable to Connect KDS Server", ex);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }


        private void ErrorMessageHandler(String Msg, Exception e)
        {
            //MessageBox.Show(Msg);
            WriteMsgtoPanel(Msg);
            //WritetoLogfile(Msg,e);
        }
        private void WriteMsgtoPanel(String Msg)
        {

            lblErrorMSG.Text = Msg;
            lblErrorMSG.Visible = true;
        }
        private void ClearMsgtoPanel()
        {
            lblErrorMSG.Text = "";
            lblErrorMSG.Visible = false;

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.itemTableAdapter1.FillBy(this.mCKDSDataSet.Item);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

     
    }
}
