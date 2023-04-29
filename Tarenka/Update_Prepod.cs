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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tarenka
{
    public partial class Update_Prepod : MaterialForm
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();

        int _id_client;

        public Update_Prepod(String fam, String name, String last_name, String address, String number_Phone, DateTime birthday, int id_client)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);

            textBox5.Text = fam;
            textBox4.Text = name; 
            textBox3.Text = last_name;
            textBox1.Text = address;
            textBox2.Text = number_Phone;
            dateTimePicker1.Value = birthday;
            _id_client = id_client;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void updateDate(String fam, String name, String last_name, String address, String pnonenumber, DateTime birthday, int id_client)
        {
            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("update client set secondname = :fam, name = :name, " +
                    "middlename = :last_name, address = :address, phonenumber = :pnonenumber, birthday = :birthday where id = :id_client ", connection);

                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("fam",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("last_name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("address",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("pnonenumber",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("birthday",
                    NpgsqlTypes.NpgsqlDbType.Date));
                command.Parameters.Add(new NpgsqlParameter("id_client",
                    NpgsqlTypes.NpgsqlDbType.Integer));


                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = fam;
                command.Parameters[1].Value = name;
                command.Parameters[2].Value = last_name;
                command.Parameters[3].Value = address;
                command.Parameters[4].Value = pnonenumber;
                command.Parameters[5].Value = birthday;
                command.Parameters[6].Value = id_client;

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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            //comboBox1 = null;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            updateDate(textBox5.Text, textBox4.Text, textBox3.Text, textBox1.Text, textBox2.Text, dateTimePicker1.Value, _id_client);
        }

    }
}
