using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tarenka
{
    public partial class Form2 : Form
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public Form2()
        {
            InitializeComponent();
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DateNew();
        }

        public string selectGrid;
        public string selectGridIdClient;
        public string selectGridIdService;
        public string selectGridIdContract;
        public string selectGridIdStaff;
        public string selectGrid1;
        public string selectGrid2;
        public string selectGrid3;
        public string selectGridIdOrder;
        public string selectGrid5;

        private void button1_Click(object sender, EventArgs e)//Close
        {
            this.Close();
        }

        public void DateNew()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            

            if (connection.FullState == ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }
            else
            {
                connection.Open();
            }

            try
            {
                string sql = $"select orders.Id as id, Client.Id as clientid, Services.Id as servicesid, contract.id as contractid, " +
                $"staff.Id as staffid, concat(Client.SecondName, ' ', Client.Name, ' ', Client.MiddleName) as Клиенты,Name_Services as Услуга, " +
                $"concat(staff.secodname, ' ', staff.name, ' ', staff.middlename) as Сотрудники, start as Начало, " +
                $"contract.end as Конец from orders, Client, Services, contract, Staff " +
                $"where orders.clientid = Client.Id and orders.contractid = contract.id " +
                $"and orders.servicesid = Services.Id and orders.contractid = contract.id" +
                $"and contract.id_staff = Staff.Id ";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Возникли ошибки подключения к базе данных");
            }

            connection.Close();
        }

        //public void AllDate()
        //{
        //    string conncetionString = "Host=localhost;Port=5432;Database=ComputerFixFilial1;Username=postgres;Password=postgres";

        //    NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        //    NpgsqlCommand comm = new NpgsqlCommand();


        //    if (connection.FullState == ConnectionState.Open)
        //    {
        //        connection.Close();
        //        connection.Open();
        //    }
        //    else
        //    {
        //        connection.Open();
        //    }

        //    string sql = $"select Orders.Id as id, Client.Id as clientid, Services.Id as servicesid, ContractId as contractid, StaffId as staffid, concat(Client.SecodName,' ',Client.Name,' ',Client.MiddleName) as Клиенты, Name_Services as Услуга, concat(staff.secodname,' ',staff.name,' ',staff.middlename) as Сотрудники, ContractStart as Начало, " +
        //        "ContractEnd as Конец from Orders, Client, Services, Contract, Staff " +
        //        "where Orders.ClientId = Client.Id and " +
        //        "Orders.ContractId = Contract.Id and " +
        //        "Orders.ServicesId = Services.Id and " +
        //        "Orders.Contractid = Contract.Id and " +
        //        "Contract.staffId = Staff.Id ";

        //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
        //    //ds.Reset();
        //    da.Fill(ds1);
        //    dt = ds1.Tables[0];
        //    dataGridView1.DataSource = dt;

        //    dataGridView1.Columns[0].Visible = false;
        //    dataGridView1.Columns[1].Visible = false;
        //    dataGridView1.Columns[2].Visible = false;
        //    dataGridView1.Columns[3].Visible = false;
        //    dataGridView1.Columns[4].Visible = false;

        //    connection.Close();
        //}
        public void deleteRecord(int id) 
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();


            if (selectGrid != null)
            {
                connection.Open();

                try
                {
                    // Create insert command.
                    NpgsqlCommand command = new NpgsqlCommand("delete from orders where id = :id", connection);

                    // Add paramaters.
                    command.Parameters.Add(new NpgsqlParameter("id",
                        NpgsqlTypes.NpgsqlDbType.Integer));


                    // Prepare the command.
                    command.Prepare();

                    // Add value to the paramater.
                    command.Parameters[0].Value = id;

                    // Execute SQL command.
                    int recordAffected = command.ExecuteNonQuery();
                    if (Convert.ToBoolean(recordAffected))
                    {
                        MessageBox.Show("Данные успешно удалены");
                    }

                    DateNew();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }

            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectGrid = dataGridView1.SelectedRows[0].Cells["Клиенты"].Value.ToString();
            selectGrid1 = dataGridView1.SelectedRows[0].Cells["Услуга"].Value.ToString();
            selectGrid2 = dataGridView1.SelectedRows[0].Cells["Начало"].Value.ToString();
            selectGrid3 = dataGridView1.SelectedRows[0].Cells["Конец"].Value.ToString();
            selectGrid5 = dataGridView1.SelectedRows[0].Cells["Сотрудники"].Value.ToString();

            selectGridIdOrder = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            selectGridIdStaff = dataGridView1.SelectedRows[0].Cells["staffid"].Value.ToString();
            selectGridIdClient = dataGridView1.SelectedRows[0].Cells["clientid"].Value.ToString();
            selectGridIdContract = dataGridView1.SelectedRows[0].Cells["contractid"].Value.ToString();
            selectGridIdService = dataGridView1.SelectedRows[0].Cells["servicesid"].Value.ToString();



            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) != "")
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            DateNew();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            deleteRecord(Convert.ToInt32(selectGridIdOrder));
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            UpdateFromOpen();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            AddOrder addorder = new AddOrder();
            addorder.ShowDialog();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateFromOpen()
        {
            if (selectGrid != null)
            {
                Form6 form6 = new Form6(selectGrid, selectGrid1, Convert.ToDateTime(selectGrid2), Convert.ToDateTime(selectGrid3), Convert.ToInt32(selectGridIdOrder), Convert.ToInt32(selectGridIdClient), Convert.ToInt32(selectGridIdStaff), Convert.ToInt32(selectGridIdContract), Convert.ToInt32(selectGridIdService), selectGrid5);
                form6.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", "Клиенты", materialTextBox1.Text);
        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", "Услуга", materialTextBox2.Text);
        }

        private void materialTextBox3_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", "Сотрудники", materialTextBox3.Text);
        }

        private void materialButton2_Click_1(object sender, EventArgs e)
        {
            //DateNew();
            //AllDate();
        }
    }
}
