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
    public partial class Update_gruppy : MaterialForm
    {
        static string conncetionString = "Host=localhost;Port=5432;Database=ComputerFix;Username=postgres;Password=postgres";

        NpgsqlConnection connection = new NpgsqlConnection(conncetionString);

        private DataSet ds = new DataSet();

        private DataTable dt = new DataTable();

        int _id_staff;
        public Update_gruppy(String second_name, String name, String middle_name, String phone_number, int id_staff)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);

            _id_staff = id_staff;

            textBox5.Text = second_name;
            textBox4.Text = name;
            textBox3.Text = middle_name;
            textBox2.Text = phone_number;
        }

        void Update(int id_staff, String second_name, String name, String middle_name, String phone_number)
        {
            connection.Open();

            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("update staff set secodname = :second_name, " + 
                    "name = :name, " +
                    "middlename = :middle_name, " +
                    "phonenumber = :phone_number " +
                    "where id = :id_staff", connection);

                command.Parameters.Add(new NpgsqlParameter("second_name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("middle_name",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("phone_number",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("id_staff",
                    NpgsqlTypes.NpgsqlDbType.Integer));


                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = second_name;
                command.Parameters[1].Value = name;
                command.Parameters[2].Value = middle_name;
                command.Parameters[3].Value = phone_number;
                command.Parameters[4].Value = id_staff;

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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            //textBox1.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;

            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;

            e.Handled = true;

            textBox2.Clear();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Update(_id_staff, textBox5.Text, textBox4.Text, textBox3.Text, textBox2.Text);
        }
    }
}
