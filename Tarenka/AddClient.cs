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
    public partial class Form7 : Form
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();

        Form3 form3 = new Form3();

        int id_faculty;


        public Form7()
        {
            InitializeComponent();
        }

        public void insertRecord(String secondname, String name, String middlename, String address, String phonenumber, DateTime birthday)
        {
            connection.Open();
            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "client (secondname, name, middlename, address, phonenumber, birthday) VALUES(:secondname, :name, " +
                    ":middlename, :address, :phonenumber, :birthday)", connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("secondname",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("middlename",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("address",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("phonenumber",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("birthday",
                    NpgsqlTypes.NpgsqlDbType.Date));


                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = secondname;
                command.Parameters[1].Value = name;
                command.Parameters[2].Value = middlename;
                command.Parameters[3].Value = address;
                command.Parameters[4].Value = phonenumber;
                command.Parameters[5].Value = birthday;

                // Execute SQL command.
                int recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    MessageBox.Show("Данные успешно добавлены");
                    form3.DateNew();
                    this.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox3.Clear();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            //get_id_faculty(/comboBox1.Text);
            string surname = textBox1.Text;
            string name = textBox2.Text;
            string middle_name = textBox3.Text;
            string address = textBox4.Text;
            string phonenumber = textBox5.Text;
            DateTime birthday = dateTimePicker1.Value;

            insertRecord(surname, name, middle_name, address, phonenumber, birthday);
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
