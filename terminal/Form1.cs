using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terminal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string connStr = "server=localhost;user=root;database=JDVokzal;password=;SslMode=none";  // строка подключения к БД
        public static string idreis = "";
        public static string namereis = "";
        public static string otprav = "";
        public static string pribit = "";

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
          
            //////////////////////
            //ПОДКЛЮЧЕНИЕ К БАЗЕ//
            //////////////////////
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(Form1.connStr);
            // устанавливаем соединение с БД
            conn.Open();

            //ЗАГРУЖАЕМ ТАБЛИЦУ ПОЛЬЗОВАТЕЛЕЙ
            DataSet ds = new DataSet();
            MySqlDataAdapter ad = new MySqlDataAdapter("Select * from Reis", conn);// параметры- команда для выполнения + connection;
            ad.Fill(ds, "Reis");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //переименовываем столбцы
            dataGridView1.Columns[0].HeaderText = "№ рейса";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Станция отправления";
            dataGridView1.Columns[3].HeaderText = "Станция прибытия";
            dataGridView1.Columns[4].HeaderText = "Номер станции отправления";
            dataGridView1.Columns[5].HeaderText = "Переодичность (в часах)";
            label2.Text = "Рейсов доступно: " + dataGridView1.RowCount.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RJDCLick(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            panel3.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PoiskClick(object sender, EventArgs e)
        {

        }

        private void PoiskFocusEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Поиск рейса")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }

        private void PoiskFocusLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Silver;
                textBox1.Text = "Поиск рейса";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                namereis = textBox1.Text;
                if (textBox1.Text != "Поиск рейса" && textBox1.Text != "")
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();

                        dataGridView1.Rows[i].Visible = false;

                        currencyManager1.ResumeBinding();
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;

                        if (dataGridView1.Rows[i].Cells[1].Value != null)
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(namereis))
                            {
                                dataGridView1.Rows[i].Visible = true;
                                break;
                            }

                    }
                }
                else
                {
                    button1_Click(null, null);
                }

            }
            if (radioButton1.Checked)
            {
                idreis = textBox1.Text;
                if (textBox1.Text != "Поиск рейса" && textBox1.Text != "")
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();

                        dataGridView1.Rows[i].Visible = false;

                        currencyManager1.ResumeBinding();
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;

                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(idreis))
                            {
                                dataGridView1.Rows[i].Visible = true;
                                break;
                            }

                    }
                }
                else
                {
                    button1_Click(null, null);
                }
            }
            if (radioButton3.Checked)
            {
                otprav = textBox1.Text;

                if (textBox1.Text != "Поиск рейса" && textBox1.Text != "") 
           
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();

                        dataGridView1.Rows[i].Visible = false;

                        currencyManager1.ResumeBinding();
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;

                        if (dataGridView1.Rows[i].Cells[2].Value != null)
                            if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(otprav))
                            {
                                dataGridView1.Rows[i].Visible = true;
                                break;
                            }

                    }
                }
                else
                {
                    button1_Click(null, null);
                }
            }
            if (radioButton4.Checked)
            {
                pribit = textBox1.Text;
                if (textBox1.Text != "Поиск рейса" && textBox1.Text != "")
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();

                        dataGridView1.Rows[i].Visible = false;

                        currencyManager1.ResumeBinding();
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;

                        if (dataGridView1.Rows[i].Cells[3].Value != null)
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(pribit))
                            {
                                dataGridView1.Rows[i].Visible = true;
                                break;
                            }

                    }
                }
                else
                {
                    button1_Click(null, null);
                }
            }
            if (radioButton5.Checked)
            {
                if (textBox1.Text != "Поиск рейса" && textBox1.Text != "")
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();

                        dataGridView1.Rows[i].Visible = false;

                        currencyManager1.ResumeBinding();
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Selected = false;
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                                if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                                {
                                    dataGridView1.Rows[i].Visible = true;
                                    break;
                                }
                    }
                }
                else
                {
                    button1_Click(null, null);
                }
            }
            dataGridView1.ClearSelection();
            label2.Text = "Рейсов доступно: " + dataGridView1.RowCount.ToString();
        }
        
        public static string[] mounths = new string[13];
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            mounths[1] = "января";
            mounths[2] = "февраля";
            mounths[3] = "марта";
            mounths[4] = "апреля";
            mounths[5] = "мая";
            mounths[6] = "июня";
            mounths[7] = "июля";
            mounths[8] = "августа";
            mounths[9] = "сентября";
            mounths[10] = "октября";
            mounths[11] = "ноября";
            mounths[12] = "декабря";
            if (DateTime.Now.Minute.ToString().Length == 1)
            {
                label3.Text = DateTime.Now.Hour + ":0" + DateTime.Now.Minute;
            }
            else
            {
                label3.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            }
           
            label4.Text = DateTime.Now.Day + " " + mounths[DateTime.Now.Month] + " " + DateTime.Now.Year + " г.";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                int r = dataGridView1.CurrentCell.RowIndex;
               
               
                if (r < dataGridView1.Rows.Count-1) { r++;
            dataGridView1.CurrentCell = dataGridView1.Rows[r].Cells[0];
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;


            if (r >= 1)
            {
                r--;
                dataGridView1.CurrentCell = dataGridView1.Rows[r].Cells[0];
            }

        }
        public static string id_reis;
        private void button6_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            id_reis = Convert.ToString(dataGridView1.Rows[index].Cells[0].Value);
            panel3.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            panel2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            //////////////////////
            //ПОДКЛЮЧЕНИЕ К БАЗЕ//
            //////////////////////
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(Form1.connStr);
            // устанавливаем соединение с БД
            conn.Open();

            //ЗАГРУЖАЕМ ТАБЛИЦУ ПОЛЬЗОВАТЕЛЕЙ
            DataSet ds1 = new DataSet();
            //MessageBox.Show(id_reis.ToString(), "Москва");
            MySqlDataAdapter ad = new MySqlDataAdapter("Select * from Bilet WHERE ID_Reisa = '" + id_reis + "'", conn);// параметры- команда для выполнения + connection;
            ad.Fill(ds1, "Bilet");
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.DataSource = ds1.Tables[0];
            conn.Close();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //переименовываем столбцы
            dataGridView2.Columns[0].HeaderText = "№ билета";
            dataGridView2.Columns[1].HeaderText = "№ рейса";
            dataGridView2.Columns[2].HeaderText = "Время отправления";
            dataGridView2.Columns[3].HeaderText = "Время прибытия";
            dataGridView2.Columns[4].HeaderText = "Стоимость рублей";
            dataGridView2.Columns[5].HeaderText = "Номер места";
            dataGridView2.Columns[6].HeaderText = "Тип места";
            ///////////////ПРОВЕРКА НА ПРОДАННОСТЬ
            MySqlConnection connectaa = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            connectaa.Open();

            //ЗАГРУЖАЕМ ТАБЛИЦУ ПОЛЬЗОВАТЕЛЕЙ
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                
                id_bileta = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                MySqlCommand com = new MySqlCommand("SELECT count(*) FROM Talon_Bilet WHERE ID_Bileta = '" + id_bileta + "'", connectaa);
                int ia = Convert.ToInt32(com.ExecuteScalar());
               // MessageBox.Show(ia.ToString(), id_bileta);
                if (ia == 1)
                {
                    dataGridView2.Rows.RemoveAt(i);
                }
            }
            ////////////////
            label10.Text = "Билетов доступно: " + dataGridView2.RowCount.ToString();
        }
        public static string id_bileta, id_talona;
     
        private void button8_Click(object sender, EventArgs e)
        {
            string rnd_id_sotr= "789456";
            
            int rnd_value, rnd_value2;
            int index = dataGridView1.CurrentCell.RowIndex;
            id_bileta = Convert.ToString(dataGridView2.Rows[index].Cells[0].Value);
            Random rnd = new Random();
            rnd_value = rnd.Next(100001, 999998);
            rnd_value2 = rnd.Next(100001, 999998);
             string[] dates_new = Convert.ToString(System.DateTime.Now.Date).Split(new char[] { '.' });
            string seconds = DateTime.Now.Second.ToString();
            string seconds_upper;
            if (seconds.Length == 1)
            {
                seconds_upper = "0" + seconds;
            }
            else
            {
                seconds_upper = seconds;
            }
        string dates_new_single = dates_new[2].Remove(4) + "-" + dates_new[1] + "-" + dates_new[0];
         string data = dates_new_single + " " + label3.Text + ":" + seconds_upper;
            /////////////////////////////////////////////
            //начинаем запрос
            try
            {
                MySqlConnection conn = new MySqlConnection(Form1.connStr);
                // устанавливаем соединение с БД
                conn.Open();
                string add = "INSERT INTO Talon SET " +
                    "ID_Talona = '" + rnd_value.ToString() + "', " +
                    "ID_Clienta = '" + rnd_value2.ToString() + "', " +
                    "ID_Sotrudnica = '" + rnd_id_sotr.ToString() + "', " +
                    "Vremya_Data_Vidachi = '" + data + "', " +
                    "Usluga = 'Покупка ЖД Билета №" + id_bileta.ToString() + ", Рейса №"+ id_reis.ToString() + "'";
                MySqlCommand adda = new MySqlCommand(add, conn);
               
                MySqlDataReader MyDataReader;
                MyDataReader = adda.ExecuteReader();

                while (MyDataReader.Read())
                {
                }
                MyDataReader.Close();
                conn.Close();
                panel3.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                panel2.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                id_talona = rnd_value.ToString();
                label9.Text = "Ваша заявка №" + id_talona + " успешно зарегистрирована!";
                panel4.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка!\n" + ex, "ЖД Вокзал", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            panel3.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
           

        }

        private void Button2CLick(object sender, EventArgs e)
        {
            panel5.Visible = true;
            button13.Visible = true;
            textBox3.Text = "";
            textBox3.Visible = true;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            







            string rnd_id_sotr = "789456";

            int rnd_value, rnd_value2;
           
          
            Random rnd = new Random();
            rnd_value = rnd.Next(100001, 999998);
            rnd_value2 = rnd.Next(100001, 999998);
            string[] dates_new = Convert.ToString(System.DateTime.Now.Date).Split(new char[] { '.' });
            string seconds = DateTime.Now.Second.ToString();
            string seconds_upper;
            if (seconds.Length == 1)
            {
                seconds_upper = "0" + seconds;
            }
            else
            {
                seconds_upper = seconds;
            }
            string dates_new_single = dates_new[2].Remove(4) + "-" + dates_new[1] + "-" + dates_new[0];
            string data = dates_new_single + " " + label3.Text + ":" + seconds_upper;
            MySqlConnection connectaa = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            connectaa.Open();

            MySqlCommand com = new MySqlCommand("SELECT count(*) FROM Talon_Bilet WHERE ID_Bileta = '" + textBox3.Text + "'", connectaa);
            int ia = Convert.ToInt32(com.ExecuteScalar());
            // MessageBox.Show(ia.ToString(), id_bileta);
            if (ia == 1)
            {
                id_bileta = textBox3.Text;
                string id_clienta="";
                MySqlConnection conn2 = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn2.Open();
                // запрос

                string auth = "SELECT * FROM Talon_Bilet WHERE ID_Bileta = '" + id_bileta + "'";
                string id_reis_upper="";
                try
                {
                    MySqlCommand commandauth = new MySqlCommand(auth, conn2);


                    MySqlDataReader MyDataReader;
                    MyDataReader = commandauth.ExecuteReader();

                    while (MyDataReader.Read())
                    {
                        id_clienta = MyDataReader.GetString(2);
                        id_reis_upper = MyDataReader.GetString(4);
                    }
                    MyDataReader.Close();
                    // закрываем соединение с БД
                    conn2.Close();

                }
                catch
                {

                }



                try
                {
                    MySqlConnection conn = new MySqlConnection(Form1.connStr);
                    // устанавливаем соединение с БД
                    conn.Open();
                    string add = "INSERT INTO Talon SET " +
                        "ID_Talona = '" + rnd_value.ToString() + "', " +
                        "ID_Clienta = '" + id_clienta + "', " +
                        "ID_Sotrudnica = '" + rnd_id_sotr.ToString() + "', " +
                        "Vremya_Data_Vidachi = '" + data + "', " +
                        "Usluga = 'Возврат ЖД Билета №" + id_bileta.ToString() + ", Рейса №" + id_reis_upper + "'";
                    MySqlCommand adda = new MySqlCommand(add, conn);

                    MySqlDataReader MyDataReader;
                    MyDataReader = adda.ExecuteReader();

                    while (MyDataReader.Read())
                    {
                    }
                    MyDataReader.Close();
                    conn.Close();
                    panel3.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    panel2.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button13.Visible = false;
                    label14.Visible = true;
                    label15.Visible = true;
                    label13.Visible = true;
                    label16.Visible = false;
                    label17.Visible = false;
                    textBox3.Visible = false;
                    textBox3.Text = "";
                  id_talona = rnd_value.ToString();
                    label15.Text = "Ваша заявка №" + id_talona + " успешно зарегистрирована!";
                    panel5.Visible = true;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка!\n" + ex, "ЖД Вокзал", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                label17.Visible = true;
            }
        }

        private void textBox3Click(object sender, EventArgs e)
        {
            label17.Visible = false;
        }

        private void button3Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }
    }
}
