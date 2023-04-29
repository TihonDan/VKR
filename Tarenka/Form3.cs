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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Net;

namespace Tarenka
{
    public partial class Form3 : Form
    {
        DataTable dt_all = new DataTable();
        string filterField = "Фамилия";

        string selectGrid;
        string selectGrid1;
        string selectGrid2;
        string selectGrid3;
        string selectGrid4;
        string selectGrid5;
        string selectGrid6;


        public Form3()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DateNew();
        }

        public void DateNew()
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            string sql = $"select id, secondname as Фамилия, name as Имя, middlename as Отчество, address as Адресс, phonenumber as Номер_телефона, birthday as Дата_Рождения from client";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
            ds.Reset();
            da.Fill(ds);
            dt_all = ds.Tables[0];
            dataGridView1.DataSource = dt_all;            

            DataColumn dcRowString = dt_all.Columns.Add("_RowString", typeof(string));
            foreach (DataRow dataRow in dt_all.Rows)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt_all.Columns.Count - 1; i++)
                {
                    sb.Append(dataRow[i].ToString());
                    sb.Append("\t");
                }
                dataRow[dcRowString] = sb.ToString();
            }

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            connection.Close();
        }

        public void deleteRecord(int id)
        {
            string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

            NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

            NpgsqlCommand comm = new NpgsqlCommand();

            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            if (selectGrid != null)
            {
                connection.Open();

                try
                {
                    // Create insert command.
                    NpgsqlCommand command = new NpgsqlCommand("delete from client where id = :id", connection);

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
                        DateNew();
                    }

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
            selectGrid = dataGridView1.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            selectGrid1 = dataGridView1.SelectedRows[0].Cells["Имя"].Value.ToString();
            selectGrid2 = dataGridView1.SelectedRows[0].Cells["Отчество"].Value.ToString();
            selectGrid3 = dataGridView1.SelectedRows[0].Cells["Адресс"].Value.ToString();
            selectGrid4 = dataGridView1.SelectedRows[0].Cells["Номер_телефона"].Value.ToString();
            selectGrid5 = dataGridView1.SelectedRows[0].Cells["Дата_Рождения"].Value.ToString();
            selectGrid6 = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();

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

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectGrid != null)
            {
                Update_Prepod update_form = new Update_Prepod(selectGrid, selectGrid1, selectGrid2, selectGrid3, selectGrid4, Convert.ToDateTime(selectGrid5), Convert.ToInt32(selectGrid6));
                update_form.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Выберите элемент");
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            DateNew();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            deleteRecord(Convert.ToInt32(selectGrid6));
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (selectGrid != null)
            {
                Update_Prepod update_form = new Update_Prepod(selectGrid, selectGrid1, selectGrid2, selectGrid3, selectGrid4, Convert.ToDateTime(selectGrid5), Convert.ToInt32(selectGrid6));
                update_form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            dt_all.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", materialTextBox1.Text);
        }
    }
}
