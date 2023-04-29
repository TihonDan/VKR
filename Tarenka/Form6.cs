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
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tarenka
{
    public partial class Form6 : MaterialForm
    {
        

        int _id_order;
        int _id_client;
        int _id_staff;
        int _id_contract;
        int _id_service;

        int _id_client_update;
        int _id_staff_update;
        int _id_service_update;

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

        public Form6(String client, String service, DateTime startDate, DateTime endDate, int id_order, int id_client, int id_staff, int id_contract, int id_service, String staff)
        {
            InitializeComponent();

            DateClient();
            DateService();
            DateStaff();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.AutoResizeColumns();
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);


            textBox1.Text = client;
            textBox2.Text = service;
            textBox3.Text = staff;
            _id_order = id_order;
            _id_client = id_client;
            _id_contract = id_contract;
            _id_staff = id_staff;
            _id_service = id_service;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = endDate;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void updateDate(int clientid, int contractid, int servicesid, int id)
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand($"update orders set clientid = '{clientid}', " +
                    $"contractid = '{contractid}', servicesid = '{servicesid}' "+
                    $"where id = '{id}' ", connection); 

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("clientid",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("contractid",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("servicesid",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("id",
                    NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = clientid;
                command.Parameters[1].Value = contractid;
                command.Parameters[2].Value = servicesid;
                command.Parameters[3].Value = id;

                // Execute SQL command.
                int recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    MessageBox.Show("Данные успешно обновлены");
                }        
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка");
            }
            connection.Close();
            this.Close();
        }

        public void DateClient()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            connection.Open();

            string sql = $"select id, secondname as Фамилия, name as Имя, middlename as Отчество, address as Адресс, phonenumber as Номер_телефона, birthday as Дата_Рождения from client";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[5].Visible = false;

            connection.Close();
        }

        public void DateService()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            DataTable dt1 = new DataTable();

            connection.Open();

            string sql = $"select id, name_services as Услуга, cost as Цена, branchid as Филиал from services";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt1 = ds.Tables[0];
            dataGridView2.DataSource = dt1;

            dataGridView2.Columns[0].Visible = false;
            //dataGridView2.Columns[4].Visible = false;


            connection.Close();
        }

        public void DateStaff()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            DataTable dt2 = new DataTable();

            connection.Open();

            string table = "Staff";
            string sql = $"select id, secodname as Фамилия, name as Имя, middlename as Отчество, phonenumber as Номер_телефона from {table} ";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt2 = ds.Tables[0];
            dataGridView3.DataSource = dt2;

            dataGridView3.Columns[0].Visible = false;
            //dataGridView1.Columns[3].Visible = false;

            connection.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)//Update
        {
            if (textBox4.Text == null)
                _id_client_update = _id_client;
            else
                _id_client_update = Convert.ToInt32(selectClient);
            if(_id_client_update == 0)
                _id_client_update = _id_client;
            //
            if (textBox5.Text == null)
                _id_service_update = _id_service;
            else
                _id_service_update = Convert.ToInt32(selectService);
            if (_id_service_update == 0)
                _id_service_update = _id_service; 
            //
            if (textBox6.Text == null)
                _id_staff_update = _id_staff;
            else
                _id_staff_update = Convert.ToInt32(selectStaff);
            if(_id_staff_update == 0)
                _id_staff_update = _id_staff;

            UpdateContract(_id_contract, _id_staff_update, dateTimePicker1.Value, dateTimePicker2.Value, _id_client_update);

            updateDate(_id_client_update, _id_contract, _id_service_update, _id_order);
        }

        public void UpdateContract(int id, int staff_id, DateTime start, DateTime end, int client_id)
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            connection.Open();

            try
            {
                string sql = "update contract set staffid = :staff_id, " +
                    $"contractstart = '{start}', " +
                    $"contractend = '{end}', " +
                    "clientid = :client_id " +
                    "where id = :id ";

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("staff_id",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("id",
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
                command.Parameters[2].Value = start;
                command.Parameters[3].Value = end;
                command.Parameters[4].Value = client_id;
                command.Parameters[1].Value = id;

                // Execute SQL command.
                int recordAffected = command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка создания контракта");
            }
            connection.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox1.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox2.Clear();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectClient = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            selectClient1 = dataGridView1.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            selectClient2 = dataGridView1.SelectedRows[0].Cells["Имя"].Value.ToString();
            selectClient3 = dataGridView1.SelectedRows[0].Cells["Отчество"].Value.ToString();
            selectClient4 = dataGridView1.SelectedRows[0].Cells["Адресс"].Value.ToString();
            selectClient5 = dataGridView1.SelectedRows[0].Cells["Номер_телефона"].Value.ToString();
            selectClient6 = dataGridView1.SelectedRows[0].Cells["Дата_Рождения"].Value.ToString();

            notChange(dataGridView1);

            textBox4.Text = selectClient1 + " " + selectClient2 + " " + selectClient3;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectService = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
            selectService1 = dataGridView2.SelectedRows[0].Cells["Услуга"].Value.ToString();
            selectService2 = dataGridView2.SelectedRows[0].Cells["Цена"].Value.ToString();
            selectService3 = dataGridView2.SelectedRows[0].Cells["Филиал"].Value.ToString();

            notChange(dataGridView2);

            textBox5.Text = selectService1;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectStaff = dataGridView3.SelectedRows[0].Cells["id"].Value.ToString();
            selectStaff1 = dataGridView3.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            selectStaff2 = dataGridView3.SelectedRows[0].Cells["Имя"].Value.ToString();
            selectStaff3 = dataGridView3.SelectedRows[0].Cells["Отчество"].Value.ToString();
            selectStaff4 = dataGridView3.SelectedRows[0].Cells["Номер_телефона"].Value.ToString();

            notChange(dataGridView3);

            textBox6.Text = selectStaff1 + " " + selectStaff2 + " " + selectStaff3;
        }
    }
}
