namespace Tarenka
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelServiceSubMenu = new System.Windows.Forms.Panel();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonService = new System.Windows.Forms.Button();
            this.panelStaffSubMenu = new System.Windows.Forms.Panel();
            this.buttonAddStaff = new System.Windows.Forms.Button();
            this.buttonStaff = new System.Windows.Forms.Button();
            this.panelClientSubMenu = new System.Windows.Forms.Panel();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.panelOrderSubMenu = new System.Windows.Forms.Panel();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelServiceSubMenu.SuspendLayout();
            this.panelStaffSubMenu.SuspendLayout();
            this.panelClientSubMenu.SuspendLayout();
            this.panelOrderSubMenu.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelSideMenu.Controls.Add(this.panelServiceSubMenu);
            this.panelSideMenu.Controls.Add(this.buttonService);
            this.panelSideMenu.Controls.Add(this.panelStaffSubMenu);
            this.panelSideMenu.Controls.Add(this.buttonStaff);
            this.panelSideMenu.Controls.Add(this.panelClientSubMenu);
            this.panelSideMenu.Controls.Add(this.buttonClient);
            this.panelSideMenu.Controls.Add(this.panelOrderSubMenu);
            this.panelSideMenu.Controls.Add(this.buttonOrder);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(220, 615);
            this.panelSideMenu.TabIndex = 8;
            // 
            // panelServiceSubMenu
            // 
            this.panelServiceSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelServiceSubMenu.Controls.Add(this.buttonAddService);
            this.panelServiceSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServiceSubMenu.Location = new System.Drawing.Point(0, 616);
            this.panelServiceSubMenu.Name = "panelServiceSubMenu";
            this.panelServiceSubMenu.Size = new System.Drawing.Size(203, 67);
            this.panelServiceSubMenu.TabIndex = 8;
            // 
            // buttonAddService
            // 
            this.buttonAddService.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddService.FlatAppearance.BorderSize = 0;
            this.buttonAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddService.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddService.Location = new System.Drawing.Point(0, 0);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonAddService.Size = new System.Drawing.Size(203, 59);
            this.buttonAddService.TabIndex = 0;
            this.buttonAddService.Text = "Добавить Услугу";
            this.buttonAddService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // buttonService
            // 
            this.buttonService.BackColor = System.Drawing.SystemColors.Control;
            this.buttonService.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonService.FlatAppearance.BorderSize = 0;
            this.buttonService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonService.ForeColor = System.Drawing.Color.Black;
            this.buttonService.Location = new System.Drawing.Point(0, 540);
            this.buttonService.Name = "buttonService";
            this.buttonService.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonService.Size = new System.Drawing.Size(203, 76);
            this.buttonService.TabIndex = 7;
            this.buttonService.Text = "Услуги";
            this.buttonService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonService.UseVisualStyleBackColor = false;
            this.buttonService.Click += new System.EventHandler(this.buttonService_Click);
            this.buttonService.MouseLeave += new System.EventHandler(this.buttonService_MouseLeave);
            this.buttonService.MouseHover += new System.EventHandler(this.buttonService_MouseHover);
            // 
            // panelStaffSubMenu
            // 
            this.panelStaffSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelStaffSubMenu.Controls.Add(this.buttonAddStaff);
            this.panelStaffSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStaffSubMenu.Location = new System.Drawing.Point(0, 468);
            this.panelStaffSubMenu.Name = "panelStaffSubMenu";
            this.panelStaffSubMenu.Size = new System.Drawing.Size(203, 72);
            this.panelStaffSubMenu.TabIndex = 6;
            // 
            // buttonAddStaff
            // 
            this.buttonAddStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddStaff.FlatAppearance.BorderSize = 0;
            this.buttonAddStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddStaff.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAddStaff.Location = new System.Drawing.Point(0, 0);
            this.buttonAddStaff.Name = "buttonAddStaff";
            this.buttonAddStaff.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonAddStaff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonAddStaff.Size = new System.Drawing.Size(203, 66);
            this.buttonAddStaff.TabIndex = 1;
            this.buttonAddStaff.Text = "Добавить Сотрудника";
            this.buttonAddStaff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddStaff.UseVisualStyleBackColor = true;
            this.buttonAddStaff.Click += new System.EventHandler(this.buttonAddStaff_Click);
            // 
            // buttonStaff
            // 
            this.buttonStaff.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStaff.FlatAppearance.BorderSize = 0;
            this.buttonStaff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStaff.ForeColor = System.Drawing.Color.Black;
            this.buttonStaff.Location = new System.Drawing.Point(0, 390);
            this.buttonStaff.Name = "buttonStaff";
            this.buttonStaff.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonStaff.Size = new System.Drawing.Size(203, 78);
            this.buttonStaff.TabIndex = 5;
            this.buttonStaff.Text = "Сотрудники";
            this.buttonStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStaff.UseVisualStyleBackColor = false;
            this.buttonStaff.Click += new System.EventHandler(this.buttonStaff_Click);
            this.buttonStaff.MouseLeave += new System.EventHandler(this.buttonStaff_MouseLeave);
            this.buttonStaff.MouseHover += new System.EventHandler(this.buttonStaff_MouseHover);
            // 
            // panelClientSubMenu
            // 
            this.panelClientSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelClientSubMenu.Controls.Add(this.buttonAddClient);
            this.panelClientSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClientSubMenu.Location = new System.Drawing.Point(0, 313);
            this.panelClientSubMenu.Name = "panelClientSubMenu";
            this.panelClientSubMenu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.panelClientSubMenu.Size = new System.Drawing.Size(203, 77);
            this.panelClientSubMenu.TabIndex = 4;
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddClient.FlatAppearance.BorderSize = 0;
            this.buttonAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddClient.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAddClient.Location = new System.Drawing.Point(35, 0);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(168, 71);
            this.buttonAddClient.TabIndex = 0;
            this.buttonAddClient.Text = "Добавить Клиента";
            this.buttonAddClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.BackColor = System.Drawing.SystemColors.Control;
            this.buttonClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonClient.FlatAppearance.BorderSize = 0;
            this.buttonClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClient.ForeColor = System.Drawing.Color.Black;
            this.buttonClient.Location = new System.Drawing.Point(0, 236);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonClient.Size = new System.Drawing.Size(203, 77);
            this.buttonClient.TabIndex = 3;
            this.buttonClient.Text = "Клиенты";
            this.buttonClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClient.UseVisualStyleBackColor = false;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            this.buttonClient.MouseLeave += new System.EventHandler(this.buttonClient_MouseLeave);
            this.buttonClient.MouseHover += new System.EventHandler(this.buttonClient_MouseHover);
            // 
            // panelOrderSubMenu
            // 
            this.panelOrderSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelOrderSubMenu.Controls.Add(this.buttonAddOrder);
            this.panelOrderSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrderSubMenu.Location = new System.Drawing.Point(0, 158);
            this.panelOrderSubMenu.Name = "panelOrderSubMenu";
            this.panelOrderSubMenu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.panelOrderSubMenu.Size = new System.Drawing.Size(203, 78);
            this.panelOrderSubMenu.TabIndex = 2;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddOrder.FlatAppearance.BorderSize = 0;
            this.buttonAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddOrder.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAddOrder.Location = new System.Drawing.Point(35, 0);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(168, 71);
            this.buttonAddOrder.TabIndex = 0;
            this.buttonAddOrder.Text = "Добавить заказ";
            this.buttonAddOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonAddOrder_Click);
            // 
            // buttonOrder
            // 
            this.buttonOrder.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOrder.FlatAppearance.BorderSize = 0;
            this.buttonOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOrder.ForeColor = System.Drawing.Color.Black;
            this.buttonOrder.Location = new System.Drawing.Point(0, 87);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonOrder.Size = new System.Drawing.Size(203, 71);
            this.buttonOrder.TabIndex = 1;
            this.buttonOrder.Text = "Заказы";
            this.buttonOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOrder.UseVisualStyleBackColor = false;
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            this.buttonOrder.MouseLeave += new System.EventHandler(this.buttonOrder_MouseLeave);
            this.buttonOrder.MouseHover += new System.EventHandler(this.buttonOrder_MouseHover);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(203, 87);
            this.panelLogo.TabIndex = 0;
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayer.Location = new System.Drawing.Point(220, 515);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(998, 100);
            this.panelPlayer.TabIndex = 9;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.SystemColors.Control;
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(220, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(998, 515);
            this.panelChildForm.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(239, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 313);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 615);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.panelSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Menu";
            this.Text = "Меню";
            this.panelSideMenu.ResumeLayout(false);
            this.panelServiceSubMenu.ResumeLayout(false);
            this.panelStaffSubMenu.ResumeLayout(false);
            this.panelClientSubMenu.ResumeLayout(false);
            this.panelOrderSubMenu.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonService;
        private System.Windows.Forms.Panel panelStaffSubMenu;
        private System.Windows.Forms.Button buttonAddStaff;
        private System.Windows.Forms.Button buttonStaff;
        private System.Windows.Forms.Panel panelClientSubMenu;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Panel panelOrderSubMenu;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.Panel panelServiceSubMenu;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Panel panelPlayer;
        public  System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

