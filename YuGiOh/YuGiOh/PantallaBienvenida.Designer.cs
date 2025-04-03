namespace YuGiOh
{
    partial class PantallaBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaBienvenida));
            panelFondo = new Panel();
            logo = new PictureBox();
            Yugi = new PictureBox();
            Seto = new PictureBox();
            botonDuelo = new Button();
            panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Yugi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Seto).BeginInit();
            SuspendLayout();
            // 
            // panelFondo
            // 
            panelFondo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFondo.BackColor = Color.Transparent;
            panelFondo.BackgroundImage = (Image)resources.GetObject("panelFondo.BackgroundImage");
            panelFondo.BackgroundImageLayout = ImageLayout.Stretch;
            panelFondo.Controls.Add(botonDuelo);
            panelFondo.Controls.Add(Seto);
            panelFondo.Controls.Add(Yugi);
            panelFondo.Controls.Add(logo);
            panelFondo.Location = new Point(1, -1);
            panelFondo.Name = "panelFondo";
            panelFondo.Size = new Size(1110, 649);
            panelFondo.TabIndex = 0;
            // 
            // logo
            // 
            logo.BackgroundImage = (Image)resources.GetObject("logo.BackgroundImage");
            logo.BackgroundImageLayout = ImageLayout.Zoom;
            logo.Location = new Point(274, 25);
            logo.Name = "logo";
            logo.Size = new Size(565, 178);
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // Yugi
            // 
            Yugi.BackgroundImage = (Image)resources.GetObject("Yugi.BackgroundImage");
            Yugi.BackgroundImageLayout = ImageLayout.Zoom;
            Yugi.Location = new Point(680, 245);
            Yugi.Name = "Yugi";
            Yugi.Size = new Size(430, 404);
            Yugi.TabIndex = 1;
            Yugi.TabStop = false;
            // 
            // Seto
            // 
            Seto.BackgroundImage = (Image)resources.GetObject("Seto.BackgroundImage");
            Seto.BackgroundImageLayout = ImageLayout.Zoom;
            Seto.Location = new Point(0, 243);
            Seto.Name = "Seto";
            Seto.Size = new Size(430, 404);
            Seto.TabIndex = 2;
            Seto.TabStop = false;
            // 
            // botonDuelo
            // 
            botonDuelo.BackColor = Color.DarkOrange;
            botonDuelo.BackgroundImageLayout = ImageLayout.None;
            botonDuelo.FlatStyle = FlatStyle.Flat;
            botonDuelo.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            botonDuelo.Location = new Point(490, 371);
            botonDuelo.Name = "botonDuelo";
            botonDuelo.Size = new Size(148, 38);
            botonDuelo.TabIndex = 3;
            botonDuelo.Text = "Duelo!";
            botonDuelo.UseVisualStyleBackColor = false;
            botonDuelo.Click += botonDuelo_Click;
            // 
            // PantallaBienvenida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 647);
            Controls.Add(panelFondo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PantallaBienvenida";
            Text = "YuGiOh!";
            panelFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)Yugi).EndInit();
            ((System.ComponentModel.ISupportInitialize)Seto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFondo;
        private PictureBox Yugi;
        private PictureBox logo;
        private PictureBox Seto;
        private Button botonDuelo;
    }
}
