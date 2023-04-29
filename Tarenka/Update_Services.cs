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
    public partial class Update_Services : Form
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);


        int _id_service;
        public Update_Services(String name_service, String cost, int id_service)
        {
            InitializeComponent();

            textBox5.Text = name_service;
            textBox4.Text = cost;
            _id_service = id_service;
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)//Update
        {
            Update(_id_service, textBox5.Text, Convert.ToInt32(textBox4.Text));
        }

        void Update(int id_service, String service_name, int cost)
        {
            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand($"update services set name_services = '{service_name}', " +
                    $"cost = '{cost}' " +
                    $"where id = '{id_service}' ", connection);

                command.Parameters.Add(new NpgsqlParameter("service_name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("cost",
                    NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("id_service",
                    NpgsqlTypes.NpgsqlDbType.Integer));


                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = service_name;
                command.Parameters[1].Value = cost;
                command.Parameters[2].Value = id_service;

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
    }
}
