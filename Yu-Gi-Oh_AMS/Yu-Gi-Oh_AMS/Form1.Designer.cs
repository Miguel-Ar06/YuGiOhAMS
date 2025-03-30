namespace Yu_Gi_Oh_AMS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelFondoMenu = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            botonJugar = new Button();
            label1 = new Label();
            logoMenu = new PictureBox();
            panelFondoMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoMenu).BeginInit();
            SuspendLayout();
            // 
            // panelFondoMenu
            // 
            panelFondoMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFondoMenu.BackColor = Color.Transparent;
            panelFondoMenu.BackgroundImage = (Image)resources.GetObject("panelFondoMenu.BackgroundImage");
            panelFondoMenu.BackgroundImageLayout = ImageLayout.Stretch;
            panelFondoMenu.Controls.Add(pictureBox2);
            panelFondoMenu.Controls.Add(pictureBox1);
            panelFondoMenu.Controls.Add(botonJugar);
            panelFondoMenu.Controls.Add(label1);
            panelFondoMenu.Controls.Add(logoMenu);
            panelFondoMenu.Location = new Point(-3, -7);
            panelFondoMenu.Name = "panelFondoMenu";
            panelFondoMenu.Size = new Size(1172, 688);
            panelFondoMenu.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-17, 209);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(389, 540);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(715, 199);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(457, 573);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // botonJugar
            // 
            botonJugar.Anchor = AnchorStyles.Bottom;
            botonJugar.BackColor = Color.Tomato;
            botonJugar.BackgroundImageLayout = ImageLayout.None;
            botonJugar.FlatStyle = FlatStyle.Flat;
            botonJugar.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            botonJugar.Location = new Point(505, 323);
            botonJugar.Name = "botonJugar";
            botonJugar.Size = new Size(174, 44);
            botonJugar.TabIndex = 3;
            botonJugar.Text = "Jugar";
            botonJugar.UseVisualStyleBackColor = false;
            botonJugar.Click += botonJugar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(15, 663);
            label1.Name = "label1";
            label1.Size = new Size(315, 12);
            label1.TabIndex = 2;
            label1.Text = "Ver 0.1 - Miguel Arismendi, Angel Marin, Sebastian Martinez / EdD 2025";
            // 
            // logoMenu
            // 
            logoMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logoMenu.Image = (Image)resources.GetObject("logoMenu.Image");
            logoMenu.Location = new Point(198, 30);
            logoMenu.Name = "logoMenu";
            logoMenu.Size = new Size(787, 170);
            logoMenu.SizeMode = PictureBoxSizeMode.Zoom;
            logoMenu.TabIndex = 1;
            logoMenu.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1166, 677);
            Controls.Add(panelFondoMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panelFondoMenu.ResumeLayout(false);
            panelFondoMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelFondoMenu;
        private PictureBox logoMenu;
        private Label label1;
        private Button botonJugar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
