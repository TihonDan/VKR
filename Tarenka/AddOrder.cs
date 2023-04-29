using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tarenka
{
    public partial class AddOrder : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        string selectClient;
        string selectClient1;
        string selectClient2;
        string selectClient3;
        string selectClient4;
        string selectClient5;
        string selectClient6;
        string selectClient7;

        string selectService;
        string selectService1;
        string selectService2;
        string selectService3;

        string selectStaff;
        string selectStaff1;
        string selectStaff2;
        string selectStaff3;
        string selectStaff4;

        DateTime dateStart;
        DateTime dateEnd;

        int id_contr;

        public AddOrder()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.AutoResizeColumns();
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DateClient();
            DateService();
            DateStaff();

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DateClient()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            

            connection.Open();

            string sql = $"select id, secondname as Фамилия, name as Имя, middlename as Отчество, address as Адресс, phonenumber as Номер_телефона, birthday as Дата_Рождения from client";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            DataColumn dcRowString = dt.Columns.Add("_RowString", typeof(string));
            foreach (DataRow dataRow in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                {
                    sb.Append(dataRow[i].ToString());
                    sb.Append("\t");
                }
                dataRow[dcRowString] = sb.ToString();
            }
            dataGridView1.Columns["_RowString"].Visible = false;
            dataGridView1.Columns[0].Visible = false;

            connection.Close();
        }

        public void DateService()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            

            connection.Open();

            string sql = $"select id, name_services as Услуга, cost as Цена, branchid as Филиал from services";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt1 = ds.Tables[0];
            dataGridView2.DataSource = dt1;

            DataColumn dcRowString = dt1.Columns.Add("_RowString", typeof(string));
            foreach (DataRow dataRow in dt1.Rows)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt1.Columns.Count - 1; i++)
                {
                    sb.Append(dataRow[i].ToString());
                    sb.Append("\t");
                }
                dataRow[dcRowString] = sb.ToString();
            }

            dataGridView2.Columns["_RowString"].Visible = false;

            dataGridView2.Columns[0].Visible = false;


            connection.Close();
        }

        public void DateStaff()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            

            connection.Open();

            string table = "Staff";
            string sql = $"select id, secodname as Фамилия, name as Имя, middlename as Отчество, phonenumber as Номер_телефона from {table} ";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt2 = ds.Tables[0];
            dataGridView3.DataSource = dt2;

            DataColumn dcRowString = dt2.Columns.Add("_RowString", typeof(string));
            foreach (DataRow dataRow in dt2.Rows)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt2.Columns.Count - 1; i++)
                {
                    sb.Append(dataRow[i].ToString());
                    sb.Append("\t");
                }
                dataRow[dcRowString] = sb.ToString();
            }

            dataGridView3.Columns["_RowString"].Visible = false;

            dataGridView3.Columns[0].Visible = false;

            connection.Close();
        }

        public void dateTime()
        {
            dateStart = monthCalendar1.SelectionStart;
            dateEnd = monthCalendar1.SelectionEnd;
        }

        void notChange(DataGridView grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                for (int j = 0; j < grid.ColumnCount; j++)
                {
                    if (Convert.ToString(grid.Rows[i].Cells[j].Value) != "")
                    {
                        grid.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//Client
        {
            selectClient = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            selectClient1 = dataGridView1.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            selectClient2 = dataGridView1.SelectedRows[0].Cells["Имя"].Value.ToString();
            selectClient3 = dataGridView1.SelectedRows[0].Cells["Отчество"].Value.ToString();
            selectClient4 = dataGridView1.SelectedRows[0].Cells["Адресс"].Value.ToString();
            selectClient5 = dataGridView1.SelectedRows[0].Cells["Номер_телефона"].Value.ToString();
            selectClient6 = dataGridView1.SelectedRows[0].Cells["Дата_Рождения"].Value.ToString();

            notChange(dataGridView1);

            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)//Service
        {
           selectService = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
           selectService1 = dataGridView2.SelectedRows[0].Cells["Услуга"].Value.ToString();
           selectService2 = dataGridView2.SelectedRows[0].Cells["Цена"].Value.ToString();
           selectService3 = dataGridView2.SelectedRows[0].Cells["Филиал"].Value.ToString();

           notChange(dataGridView2);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)//Staff
        {
            selectStaff = dataGridView3.SelectedRows[0].Cells["id"].Value.ToString();
            selectStaff1 = dataGridView3.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            selectStaff2 = dataGridView3.SelectedRows[0].Cells["Имя"].Value.ToString();
            selectStaff3 = dataGridView3.SelectedRows[0].Cells["Отчество"].Value.ToString();
            selectStaff4 = dataGridView3.SelectedRows[0].Cells["Номер_телефона"].Value.ToString();

            notChange(dataGridView3);
        }

        private void InsertContract(int staff_id, DateTime start, DateTime end, int client_id)
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "contract (id_staff, start, end_contract, id_client) VALUES(:staff_id, :start, " +
                    ":end, :client_id)", connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("staff_id",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("start",
                    NpgsqlTypes.NpgsqlDbType.Date));
                command.Parameters.Add(new NpgsqlParameter("end",
                    NpgsqlTypes.NpgsqlDbType.Date));
                command.Parameters.Add(new NpgsqlParameter("client_id",
                    NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = staff_id;
                command.Parameters[1].Value = start;
                command.Parameters[2].Value = end;
                command.Parameters[3].Value = client_id;

                // Execute SQL command.
                int recordAffected = command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка");
            }
            connection.Close();
        }

        private void InsertOrder(int client_id, int contract_id, int servicesid)
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "orders (clientid, contractid, servicesid) VALUES(:client_id, :contract_id, " +
                    ":servicesid)", connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("client_id",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("contract_id",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("servicesid",
                    NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = client_id;
                command.Parameters[1].Value = contract_id;
                command.Parameters[2].Value = servicesid;

                // Execute SQL command.
                int recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    MessageBox.Show("Данные успешно добавлены");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка");
            }
            connection.Close();
        }

        private void getIdContarct()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            string sql = $"select MAX(contractid) as id_contr from contract";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            if(dt == null) { 
            }

            string[] id = new string[1];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                id[i] = Convert.ToString(dt.Rows[i]["id_contr"]);
                id_contr = Convert.ToInt32(id[0]);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            dateTime();
            InsertContract(Convert.ToInt32(selectStaff), dateStart, dateEnd, Convert.ToInt32(selectClient));
            getIdContarct();
            InsertOrder(Convert.ToInt32(selectClient), id_contr, Convert.ToInt32(selectService));
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", materialTextBox1.Text);
        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {
            dt1.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", materialTextBox2.Text);
        }

        private void materialTextBox3_TextChanged(object sender, EventArgs e)
        {
            dt2.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", materialTextBox3.Text);
        }
    }
}
