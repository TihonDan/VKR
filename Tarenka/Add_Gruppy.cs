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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tarenka
{
    public partial class Add_Gruppy : Form
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();

        int id_fac;

        public Add_Gruppy()
        {
            InitializeComponent();
        }

        public void insertRecord(String secondname, String name, String middlename, String phonenumber)
        {
            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "staff (secodname, name, middlename, phonenumber) VALUES(:secondname, :name, " +
                    ":middlename, :phonenumber)", connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("secondname",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("middlename",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("phonenumber",
                    NpgsqlTypes.NpgsqlDbType.Varchar));

                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = secondname;
                command.Parameters[1].Value = name;
                command.Parameters[2].Value = middlename;
                command.Parameters[3].Value = phonenumber;

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
            insertRecord(textBox5.Text, textBox4.Text, textBox3.Text, textBox2.Text);
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox5.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox4.Clear();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox3.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox2.Clear();
        }
    }
}
