using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;

namespace Tarenka
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelOrderSubMenu.Visible = false;
            panelClientSubMenu.Visible = false;
            panelStaffSubMenu.Visible = false;
            panelServiceSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelOrderSubMenu.Visible == true)
                panelOrderSubMenu.Visible = false;
            if (panelClientSubMenu.Visible == true)
                panelClientSubMenu.Visible = false;
            if (panelStaffSubMenu.Visible == true)
                panelStaffSubMenu.Visible = false;
            if (panelServiceSubMenu.Visible == true)
                panelServiceSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            showSubMenu(panelOrderSubMenu);
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            showSubMenu(panelClientSubMenu);
        }

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4());
            showSubMenu(panelStaffSubMenu);
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            openChildForm(new Form8());
            showSubMenu(panelServiceSubMenu);
        }

        private void buttonOrder_MouseHover(object sender, EventArgs e)
        {
            buttonOrder.BackColor = Color.LightGray;
        }

        private void buttonOrder_MouseLeave(object sender, EventArgs e)
        {
            buttonOrder.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void buttonClient_MouseHover(object sender, EventArgs e)
        {
            buttonClient.BackColor = Color.LightGray;
        }

        private void buttonClient_MouseLeave(object sender, EventArgs e)
        {
            buttonClient.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void buttonStaff_MouseHover(object sender, EventArgs e)
        {
            buttonStaff.BackColor = Color.LightGray;
        }

        private void buttonStaff_MouseLeave(object sender, EventArgs e)
        {
            buttonStaff.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void buttonService_MouseHover(object sender, EventArgs e)
        {
            buttonService.BackColor = Color.LightGray;
        }

        private void buttonService_MouseLeave(object sender, EventArgs e)
        {
            buttonService.BackColor = Color.FromArgb(240, 240, 240);
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new AddOrder());
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            openChildForm(new Form7());
        }

        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            openChildForm(new Add_Gruppy());
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            openChildForm(new Add_Service());
        }
    }
}
