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

namespace Tarenka
{
    public partial class Form8 : Form
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        NpgsqlCommand comm = new NpgsqlCommand();

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();

        string selectGrid;
        string selectGrid1;
        string selectGrid2;
        string selectGrid3;

        public Form8()
        {
            InitializeComponent();
            DateNew();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateNew()
        {
            if (connection.FullState == ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }
            else
            {
                connection.Open();
            }

            string sql = $"select id, name_services as Услуга, cost as Цена, branchid as Филиал from services";

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

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns["_RowString"].Visible = false;

            connection.Close();
        }

        public void deleteRecord(int id)
        {
            if (selectGrid != null)
            {
                connection.Open();

                try
                {
                    // Create insert command.
                    NpgsqlCommand command = new NpgsqlCommand("delete from services where id = :id", connection);

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
            selectGrid = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            selectGrid1 = dataGridView1.SelectedRows[0].Cells["Услуга"].Value.ToString();
            selectGrid2 = dataGridView1.SelectedRows[0].Cells["Цена"].Value.ToString();
            selectGrid3 = dataGridView1.SelectedRows[0].Cells["Филиал"].Value.ToString();


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

        private void materialButton3_Click(object sender, EventArgs e)
        {
            deleteRecord(Convert.ToInt32(selectGrid));
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Update_Services update_Services = new Update_Services(selectGrid1, selectGrid2, Convert.ToInt32(selectGrid));
            update_Services.ShowDialog();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            DateNew();
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", materialTextBox1.Text);
        }
    }
}
