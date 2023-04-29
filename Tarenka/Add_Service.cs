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
    public partial class Add_Service : Form
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();
        public Add_Service()
        {
            InitializeComponent();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void insertRecord(String name_service, int cost)
        {
            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "services (name_services, cost) VALUES(:name_service, :cost)", connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("name_service",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("cost",
                    NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = name_service;
                command.Parameters[1].Value = cost;

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

        private void materialButton1_Click(object sender, EventArgs e)
        {
            insertRecord(textBox5.Text, Convert.ToInt32(textBox4.Text));
        }
    }
}
