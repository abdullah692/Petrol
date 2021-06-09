using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FP__PPMS_
{
    public partial class Main : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;userid=root; password=Abdullahmy@ql12;database=database1");
        double iTax = 17.5;
        public int CustNameh;
        public Main()
        {
            InitializeComponent();
            //dataGridView1.ColumnCount = 22;
            //dataGridView1.Columns[0].Name = "Cust Name";
            //dataGridView1.Columns[1].Name = "Cust Phone No";
            //dataGridView1.Columns[2].Name = "Order Date";
            //dataGridView1.Columns[3].Name = "Order Time";
            //dataGridView1.Columns[4].Name = "Order Ref No";
            //dataGridView1.Columns[5].Name = "PETROL";
            //dataGridView1.Columns[6].Name = "CNG";
            //dataGridView1.Columns[7].Name = "DIESEL";
            //dataGridView1.Columns[8].Name = "Qty1";
            //dataGridView1.Columns[9].Name = "Qty2";
            //dataGridView1.Columns[10].Name = "Qty3";
            //dataGridView1.Columns[11].Name = "Unit_Price1";
            //dataGridView1.Columns[12].Name = "Unit_Price2";
            //dataGridView1.Columns[13].Name = "Unit_Price3";
            //dataGridView1.Columns[14].Name = "Sub_Total1";
            //dataGridView1.Columns[15].Name = "Sub_Total2";
            //dataGridView1.Columns[16].Name = "Sub_Total3";
            //dataGridView1.Columns[17].Name = "Order_Sub_Total";
            //dataGridView1.Columns[18].Name = "Tax";
            //dataGridView1.Columns[19].Name = "Total";
            //dataGridView1.Columns[20].Name = "Cash";
            //dataGridView1.Columns[21].Name = "Card";
        }
        string PaymentMethod;
        //ADD TO DATAGRIDVIEW
        private void add(string CustName, string CustPhoneNo, string OrderDate, string OrderTime, string OrderRefNo, string PETROL, string CNG, string DIESEL, string Qty1, string Qty2, string Qty3, string UnitPrice1, string UnitPrice2, string UnitPrice3, string SubTotal1, string SubTotal2, string SubTotal3, string OrderSubTotal, string Tax, string Total)
        {
            dataGridView1.Rows.Add(CustName, CustPhoneNo, OrderDate, OrderTime, OrderRefNo, PETROL, CNG, DIESEL, Qty1, Qty2, Qty3, UnitPrice1, UnitPrice2, UnitPrice3, SubTotal1, SubTotal2, SubTotal3, OrderSubTotal, Tax, Total, PaymentMethod);

            clearTxts();

        }
        double Total1 = 0;
        double Total2 = 0;
        bool plus = false;
        bool minus = false;
        bool div = false;
        bool mul = false;
        private void clearTxts()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
        }

       
       
        private void Main_Load(object sender, EventArgs e)
        {
            DateTime idate = DateTime.Now;
            textBox17.Text = idate.ToString("dd/MM/yyyy");
            textBox3.Text = idate.ToString("HH:mm");

            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";

            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
        }
        private void getrecords()
        {
            MySqlCommand cmd = new MySqlCommand("Select*from petrol_management_system", con);
            DataTable dataTable = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;

        }
        public void disp_data()
        {
            //create function

            MySqlCommand cmd = new MySqlCommand("Select * from petrol_management_system", con);
            DataTable dataTable = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMethod = "Cash";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMethod = "Card";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine s = new SpeechRecognitionEngine();
            Grammar words = new DictationGrammar();
            s.LoadGrammar(words);
            //button1.Enabled = true;
            // button2.Enabled = false;

            try
            {
                s.SetInputToDefaultAudioDevice();
                RecognitionResult result = s.Recognize();
                textBox1.Text = result.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                s.UnloadAllGrammars();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine s = new SpeechRecognitionEngine();
            Grammar words = new DictationGrammar();
            s.LoadGrammar(words);
            //button1.Enabled = true;
            // button2.Enabled = false;

            try
            {
                s.SetInputToDefaultAudioDevice();
                RecognitionResult result = s.Recognize();
                textBox2.Text = result.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                s.UnloadAllGrammars();

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection(@"server=localhost;userid=root;password=Abdullahmy@ql12;database=database1");
            MySqlCommand cmd = new MySqlCommand("Insert into petrol_management_system values(@custName,@custPhoneNo,@orderDate,@OrderTime,@OrderRefNo,@PETROL,@CNG,@DIESEL,@Qty1,@Qty2,@Qty3,@Unit_Price1,@Unit_Price2,@Unit_Price3,@Sub_Total1,@Sub_Total2,@Sub_Total3,@Order_Sub_Total,@Tax,@Total,@Cash,@Card)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@custName", textBox1.Text);
            cmd.Parameters.AddWithValue("@custPhoneNo", textBox2.Text);
            cmd.Parameters.AddWithValue("@orderDate", textBox17.Text);
            cmd.Parameters.AddWithValue("@OrderTime", textBox3.Text);
            cmd.Parameters.AddWithValue("@OrderRefNo", textBox16.Text);
            cmd.Parameters.AddWithValue("@PETROL", label9.Text);
            cmd.Parameters.AddWithValue("@CNG", label10.Text);
            cmd.Parameters.AddWithValue("@DIESEL", label11.Text);
            cmd.Parameters.AddWithValue("@Qty1", textBox4.Text);
            cmd.Parameters.AddWithValue("@Qty2", textBox5.Text);
            cmd.Parameters.AddWithValue("@Qty3", textBox6.Text);
            cmd.Parameters.AddWithValue("@Unit_Price1", textBox7.Text);
            cmd.Parameters.AddWithValue("@Unit_Price2", textBox8.Text);
            cmd.Parameters.AddWithValue("@Unit_Price3", textBox9.Text);
            cmd.Parameters.AddWithValue("@Sub_Total1", textBox10.Text);
            cmd.Parameters.AddWithValue("@Sub_Total2", textBox11.Text);
            cmd.Parameters.AddWithValue("@Sub_Total3", textBox12.Text);
            cmd.Parameters.AddWithValue("@Order_Sub_Total", textBox13.Text);
            cmd.Parameters.AddWithValue("@Tax", textBox14.Text);
            cmd.Parameters.AddWithValue("@Total", textBox15.Text);
            cmd.Parameters.AddWithValue("@Cash", radioButton1.Text);
            cmd.Parameters.AddWithValue("@Card", radioButton2.Text);
            tabControl1.SelectedTab = tabPage3;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("record inserted successfully");

            getrecords();
            disp_data();
            clearTxts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double WPETROL;
            Double RCNG;
            Double ODIESEL;
            Double unitprice1;
            Double unitprice2;
            Double unitprice3;
            Double NetTax;


            WPETROL = Double.Parse(textBox4.Text);
            RCNG = Double.Parse(textBox5.Text);
            ODIESEL = Double.Parse(textBox6.Text);



            unitprice1 = Double.Parse(textBox7.Text);
            unitprice2 = Double.Parse(textBox8.Text);
            unitprice3 = Double.Parse(textBox9.Text);

            WPETROL = WPETROL * unitprice1;
            RCNG = RCNG * unitprice2;
            ODIESEL = ODIESEL * unitprice3;

            textBox10.Text = System.Convert.ToString(WPETROL);
            textBox11.Text = System.Convert.ToString(RCNG);
            textBox12.Text = System.Convert.ToString(ODIESEL);

            textBox13.Text = System.Convert.ToString(WPETROL + RCNG + ODIESEL);
            NetTax = ((WPETROL + RCNG + ODIESEL) * iTax) / 100;
            textBox14.Text = System.Convert.ToString(NetTax);
            textBox13.Text = System.Convert.ToString(NetTax + (WPETROL + RCNG + ODIESEL));

            textBox7.Text = string.Format("{0:c}", Double.Parse(textBox7.Text));
            textBox8.Text = string.Format("{0:c}", Double.Parse(textBox8.Text));
            textBox9.Text = string.Format("{0:c}", Double.Parse(textBox9.Text));

            textBox10.Text = string.Format("{0:c}", Double.Parse(textBox10.Text));
            textBox11.Text = string.Format("{0:c}", Double.Parse(textBox11.Text));
            textBox12.Text = string.Format("{0:c}", Double.Parse(textBox12.Text));
            textBox13.Text = string.Format("{0:c}", Double.Parse(textBox13.Text));
            textBox14.Text = string.Format("{0:c}", Double.Parse(textBox14.Text));
            //textBox15.Text = String.Format("{0:c}", Double.Parse(textBox15.Text));
            textBox15.Text = textBox13.Text + textBox14.Text;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";

            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";

            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox16.Text = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Microsoft sans sarif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text += "*******************************\n";
            richTextBox1.Text += "**      Petrol Receipt       **\n";
            richTextBox1.Text += "*******************************\n";
            richTextBox1.Text += "cust name:" + textBox1.Text + "\n\n";
            richTextBox1.Text += "cust phone no:" + textBox2.Text + "\n\n";
            richTextBox1.Text += "Order Date:" + textBox17.Text + "\n\n";
            richTextBox1.Text += "Order Time:" + textBox3.Text + "\n\n";
            richTextBox1.Text += "Order Ref No:" + textBox16.Text + "\n\n";
            richTextBox1.Text += "Total" + textBox15.Text + "\n\n";
            DateTime idate = DateTime.Now;
            textBox17.Text = idate.ToString("dd/MM/yyyy");
            textBox3.Text = idate.ToString("HH:mm");
            richTextBox1.Text += "*******************************\n";
            richTextBox1.Text += "**Thank You For Choosing Us**\n";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Total1 += double.Parse(textBox18.Text);
            textBox18.Clear();
            plus = true;
            minus = false;
            mul = false;
            div = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Total1 += double.Parse(textBox18.Text);
            textBox18.Clear();
            plus = false;
            minus = true;
            mul = false;
            div = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Total1 += double.Parse(textBox18.Text);
            textBox18.Clear();
            plus = false;
            minus = false;
            mul = false;
            div = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Total1 += double.Parse(textBox18.Text);
            textBox18.Clear();
            plus = false;
            minus = false;
            mul = true;
            div = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button24.Text;

        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button20.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button18.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button16.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button14.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button11.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (plus == true)
            {
                Total2 = Total1 + double.Parse(textBox18.Text);
                textBox18.Text = Total2.ToString();
                Total1 = 0;
            }
            else if (minus == true)
            {
                Total2 = Total1 - double.Parse(textBox18.Text);
                textBox18.Text = Total2.ToString();
                Total1 = 0;
            }
            else if (mul == true)
            {
                Total2 = Total1 * double.Parse(textBox18.Text);
                textBox18.Text = Total2.ToString();
                Total1 = 0;
            }
            else if (div == true)
            {
                Total2 = Total1 / double.Parse(textBox18.Text);
                textBox18.Text = Total2.ToString();
                Total1 = 0;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.textBox18.Text = textBox18.Text + button21.Text;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox18.Clear();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (CustNameh > 0)
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM petrol_management_system WHERE Cust Name = @CustName", con);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CustName", this.CustNameh);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record successfully Deleted in the database ", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getrecords();   //call function
            }
            else
            {

                MessageBox.Show(" PLEASE! Select Row Record was not Deleted ", "SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
