using System.Runtime.CompilerServices;
using Yu_Gi_Oh_AMS.Cartas;

namespace Yu_Gi_Oh_AMS
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            cartaSeleccionadaZoom = new PictureBox();
            infoCarta = new TextBox();
            descripcionCartaSeleccionada = new TextBox();
            barraVidaJ1 = new ProgressBar();
            barraVidaJ2 = new ProgressBar();
            pictureBox34 = new PictureBox();
            pictureBox35 = new PictureBox();
            jugador1Deck = new PictureBox();
            pictureBox38 = new PictureBox();
            pictureBox39 = new PictureBox();
            jugador2Deck = new PictureBox();
            pictureBox42 = new PictureBox();
            pictureBox43 = new PictureBox();
            labelJugador1 = new Label();
            labelJugador2 = new Label();
            labelDP = new Label();
            labelSP = new Label();
            labelBP = new Label();
            labelM1 = new Label();
            labelEP = new Label();
            labelM2 = new Label();
            jugador1Mano = new DataGridView();
            prueba = new DataGridViewTextBoxColumn();
            prueba2 = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            jugador2Mano = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            labelMazoJugador1 = new Label();
            labelMazoJugador2 = new Label();
            HechizosTrampasJ1 = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            MonsrtuosJ1 = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            HechizosTrampasJ2 = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            MonstruosJ2 = new DataGridView();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            CementerioJ1 = new DataGridView();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            CementerioJ2 = new DataGridView();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            botonSiguienteFase = new Button();
            ((System.ComponentModel.ISupportInitialize)cartaSeleccionadaZoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox34).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox35).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jugador1Deck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox38).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox39).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jugador2Deck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox42).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox43).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jugador1Mano).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jugador2Mano).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HechizosTrampasJ1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonsrtuosJ1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HechizosTrampasJ2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonstruosJ2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CementerioJ1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CementerioJ2).BeginInit();
            SuspendLayout();
            // 
            // cartaSeleccionadaZoom
            // 
            cartaSeleccionadaZoom.Image = (Image)resources.GetObject("cartaSeleccionadaZoom.Image");
            cartaSeleccionadaZoom.Location = new Point(28, 27);
            cartaSeleccionadaZoom.Name = "cartaSeleccionadaZoom";
            cartaSeleccionadaZoom.Size = new Size(197, 283);
            cartaSeleccionadaZoom.SizeMode = PictureBoxSizeMode.Zoom;
            cartaSeleccionadaZoom.TabIndex = 1;
            cartaSeleccionadaZoom.TabStop = false;
            // 
            // infoCarta
            // 
            infoCarta.BackColor = Color.DarkOrange;
            infoCarta.Enabled = false;
            infoCarta.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            infoCarta.Location = new Point(28, 328);
            infoCarta.Multiline = true;
            infoCarta.Name = "infoCarta";
            infoCarta.ReadOnly = true;
            infoCarta.Size = new Size(197, 73);
            infoCarta.TabIndex = 2;
            infoCarta.Text = "Nombre \r\nATK: \r\nDEF:";
            // 
            // descripcionCartaSeleccionada
            // 
            descripcionCartaSeleccionada.BackColor = SystemColors.InactiveCaptionText;
            descripcionCartaSeleccionada.Enabled = false;
            descripcionCartaSeleccionada.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descripcionCartaSeleccionada.ForeColor = SystemColors.Window;
            descripcionCartaSeleccionada.Location = new Point(28, 415);
            descripcionCartaSeleccionada.Multiline = true;
            descripcionCartaSeleccionada.Name = "descripcionCartaSeleccionada";
            descripcionCartaSeleccionada.ReadOnly = true;
            descripcionCartaSeleccionada.ScrollBars = ScrollBars.Vertical;
            descripcionCartaSeleccionada.Size = new Size(197, 174);
            descripcionCartaSeleccionada.TabIndex = 3;
            descripcionCartaSeleccionada.Text = "Descripcion y efectos de la carta";
            // 
            // barraVidaJ1
            // 
            barraVidaJ1.Anchor = AnchorStyles.Bottom;
            barraVidaJ1.Location = new Point(537, 609);
            barraVidaJ1.Maximum = 8000;
            barraVidaJ1.Name = "barraVidaJ1";
            barraVidaJ1.Size = new Size(302, 29);
            barraVidaJ1.TabIndex = 4;
            barraVidaJ1.Value = 4000;
            // 
            // barraVidaJ2
            // 
            barraVidaJ2.Anchor = AnchorStyles.Top;
            barraVidaJ2.Location = new Point(537, 27);
            barraVidaJ2.Maximum = 8000;
            barraVidaJ2.Name = "barraVidaJ2";
            barraVidaJ2.Size = new Size(302, 29);
            barraVidaJ2.TabIndex = 5;
            barraVidaJ2.Value = 5000;
            // 
            // pictureBox34
            // 
            pictureBox34.Anchor = AnchorStyles.Bottom;
            pictureBox34.BackColor = Color.FromArgb(32, 32, 32);
            pictureBox34.Location = new Point(401, 422);
            pictureBox34.Name = "pictureBox34";
            pictureBox34.Size = new Size(52, 75);
            pictureBox34.TabIndex = 38;
            pictureBox34.TabStop = false;
            // 
            // pictureBox35
            // 
            pictureBox35.Anchor = AnchorStyles.Bottom;
            pictureBox35.BackColor = Color.FromArgb(32, 32, 32);
            pictureBox35.Location = new Point(401, 341);
            pictureBox35.Name = "pictureBox35";
            pictureBox35.Size = new Size(52, 75);
            pictureBox35.TabIndex = 39;
            pictureBox35.TabStop = false;
            // 
            // jugador1Deck
            // 
            jugador1Deck.Anchor = AnchorStyles.Bottom;
            jugador1Deck.BackColor = Color.FromArgb(32, 32, 32);
            jugador1Deck.Image = (Image)resources.GetObject("jugador1Deck.Image");
            jugador1Deck.Location = new Point(914, 422);
            jugador1Deck.Name = "jugador1Deck";
            jugador1Deck.Size = new Size(52, 75);
            jugador1Deck.SizeMode = PictureBoxSizeMode.Zoom;
            jugador1Deck.TabIndex = 40;
            jugador1Deck.TabStop = false;
            // 
            // pictureBox38
            // 
            pictureBox38.Anchor = AnchorStyles.Top;
            pictureBox38.BackColor = Color.FromArgb(32, 32, 32);
            pictureBox38.Location = new Point(914, 162);
            pictureBox38.Name = "pictureBox38";
            pictureBox38.Size = new Size(52, 75);
            pictureBox38.TabIndex = 43;
            pictureBox38.TabStop = false;
            // 
            // pictureBox39
            // 
            pictureBox39.Anchor = AnchorStyles.Top;
            pictureBox39.BackColor = Color.FromArgb(32, 32, 32);
            pictureBox39.Location = new Point(914, 243);
            pictureBox39.Name = "pictureBox39";
            pictureBox39.Size = new Size(52, 75);
            pictureBox39.TabIndex = 42;
            pictureBox39.TabStop = false;
            // 
            // jugador2Deck
            // 
            jugador2Deck.Anchor = AnchorStyles.Top;
            jugador2Deck.BackColor = Color.FromArgb(32, 32, 32);
            jugador2Deck.Image = (Image)resources.GetObject("jugador2Deck.Image");
            jugador2Deck.Location = new Point(401, 162);
            jugador2Deck.Name = "jugador2Deck";
            jugador2Deck.Size = new Size(52, 75);
            jugador2Deck.SizeMode = PictureBoxSizeMode.Zoom;
            jugador2Deck.TabIndex = 45;
            jugador2Deck.TabStop = false;
            // 
            // pictureBox42
            // 
            pictureBox42.Anchor = AnchorStyles.Bottom;
            pictureBox42.BackColor = Color.FromArgb(32, 32, 32);
            pictureBox42.Location = new Point(343, 341);
            pictureBox42.Name = "pictureBox42";
            pictureBox42.Size = new Size(52, 75);
            pictureBox42.TabIndex = 46;
            pictureBox42.TabStop = false;
            // 
            // pictureBox43
            // 
            pictureBox43.Anchor = AnchorStyles.Top;
            pictureBox43.BackColor = Color.FromArgb(32, 32, 32);
            pictureBox43.Location = new Point(974, 243);
            pictureBox43.Name = "pictureBox43";
            pictureBox43.Size = new Size(52, 75);
            pictureBox43.TabIndex = 47;
            pictureBox43.TabStop = false;
            // 
            // labelJugador1
            // 
            labelJugador1.Anchor = AnchorStyles.Bottom;
            labelJugador1.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelJugador1.Location = new Point(537, 609);
            labelJugador1.Name = "labelJugador1";
            labelJugador1.Size = new Size(110, 22);
            labelJugador1.TabIndex = 48;
            labelJugador1.Text = "Jugador 1";
            // 
            // labelJugador2
            // 
            labelJugador2.Anchor = AnchorStyles.Top;
            labelJugador2.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelJugador2.Location = new Point(537, 27);
            labelJugador2.Name = "labelJugador2";
            labelJugador2.Size = new Size(118, 22);
            labelJugador2.TabIndex = 49;
            labelJugador2.Text = "Jugador 2";
            // 
            // labelDP
            // 
            labelDP.AutoSize = true;
            labelDP.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDP.Location = new Point(243, 27);
            labelDP.Name = "labelDP";
            labelDP.Size = new Size(35, 22);
            labelDP.TabIndex = 50;
            labelDP.Text = "DP";
            // 
            // labelSP
            // 
            labelSP.AutoSize = true;
            labelSP.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSP.Location = new Point(243, 65);
            labelSP.Name = "labelSP";
            labelSP.Size = new Size(34, 22);
            labelSP.TabIndex = 51;
            labelSP.Text = "SP";
            // 
            // labelBP
            // 
            labelBP.AutoSize = true;
            labelBP.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelBP.Location = new Point(243, 142);
            labelBP.Name = "labelBP";
            labelBP.Size = new Size(34, 22);
            labelBP.TabIndex = 53;
            labelBP.Text = "BP";
            // 
            // labelM1
            // 
            labelM1.AutoSize = true;
            labelM1.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelM1.Location = new Point(243, 104);
            labelM1.Name = "labelM1";
            labelM1.Size = new Size(37, 22);
            labelM1.TabIndex = 52;
            labelM1.Text = "M1";
            // 
            // labelEP
            // 
            labelEP.AutoSize = true;
            labelEP.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEP.Location = new Point(242, 223);
            labelEP.Name = "labelEP";
            labelEP.Size = new Size(34, 22);
            labelEP.TabIndex = 55;
            labelEP.Text = "EP";
            // 
            // labelM2
            // 
            labelM2.AutoSize = true;
            labelM2.Font = new Font("Nasalization", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelM2.Location = new Point(242, 185);
            labelM2.Name = "labelM2";
            labelM2.Size = new Size(45, 22);
            labelM2.TabIndex = 54;
            labelM2.Text = "M2";
            // 
            // jugador1Mano
            // 
            jugador1Mano.AllowUserToAddRows = false;
            jugador1Mano.AllowUserToOrderColumns = true;
            jugador1Mano.AllowUserToResizeColumns = false;
            jugador1Mano.AllowUserToResizeRows = false;
            jugador1Mano.Anchor = AnchorStyles.Bottom;
            jugador1Mano.BackgroundColor = Color.FromArgb(32, 32, 32);
            jugador1Mano.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jugador1Mano.ColumnHeadersVisible = false;
            jugador1Mano.Columns.AddRange(new DataGridViewColumn[] { prueba, prueba2 });
            jugador1Mano.GridColor = Color.BlueViolet;
            jugador1Mano.Location = new Point(469, 514);
            jugador1Mano.Name = "jugador1Mano";
            jugador1Mano.ReadOnly = true;
            jugador1Mano.RowHeadersWidth = 51;
            jugador1Mano.Size = new Size(429, 75);
            jugador1Mano.TabIndex = 56;
            jugador1Mano.CellContentClick += jugador1Mano_CellContentClick;
            jugador1Mano.CellContentDoubleClick += jugador1Mano_CellContentDoubleClick;
            // 
            // prueba
            // 
            prueba.HeaderText = "prueba";
            prueba.MinimumWidth = 75;
            prueba.Name = "prueba";
            prueba.ReadOnly = true;
            prueba.Resizable = DataGridViewTriState.False;
            prueba.Width = 75;
            // 
            // prueba2
            // 
            prueba2.HeaderText = "prueba2";
            prueba2.MinimumWidth = 75;
            prueba2.Name = "prueba2";
            prueba2.ReadOnly = true;
            prueba2.Resizable = DataGridViewTriState.False;
            prueba2.Width = 75;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1143, 666);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // jugador2Mano
            // 
            jugador2Mano.AllowUserToAddRows = false;
            jugador2Mano.AllowUserToOrderColumns = true;
            jugador2Mano.Anchor = AnchorStyles.Top;
            jugador2Mano.BackgroundColor = Color.FromArgb(32, 32, 32);
            jugador2Mano.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jugador2Mano.ColumnHeadersVisible = false;
            jugador2Mano.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            jugador2Mano.GridColor = Color.BlueViolet;
            jugador2Mano.Location = new Point(469, 71);
            jugador2Mano.Name = "jugador2Mano";
            jugador2Mano.ReadOnly = true;
            jugador2Mano.RowHeadersWidth = 51;
            jugador2Mano.Size = new Size(429, 75);
            jugador2Mano.TabIndex = 57;
            jugador2Mano.CellContentClick += jugador2Mano_CellContentClick;
            jugador2Mano.CellContentDoubleClick += jugador2Mano_CellContentDoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "prueba";
            dataGridViewTextBoxColumn1.MinimumWidth = 75;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "prueba2";
            dataGridViewTextBoxColumn2.MinimumWidth = 75;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn2.Width = 75;
            // 
            // labelMazoJugador1
            // 
            labelMazoJugador1.AutoSize = true;
            labelMazoJugador1.BackColor = SystemColors.ActiveCaptionText;
            labelMazoJugador1.BorderStyle = BorderStyle.FixedSingle;
            labelMazoJugador1.ForeColor = SystemColors.ButtonHighlight;
            labelMazoJugador1.Location = new Point(927, 450);
            labelMazoJugador1.Name = "labelMazoJugador1";
            labelMazoJugador1.Size = new Size(27, 22);
            labelMazoJugador1.TabIndex = 58;
            labelMazoJugador1.Text = "00";
            // 
            // labelMazoJugador2
            // 
            labelMazoJugador2.AutoSize = true;
            labelMazoJugador2.BackColor = SystemColors.ActiveCaptionText;
            labelMazoJugador2.BorderStyle = BorderStyle.FixedSingle;
            labelMazoJugador2.ForeColor = SystemColors.ButtonHighlight;
            labelMazoJugador2.Location = new Point(413, 186);
            labelMazoJugador2.Name = "labelMazoJugador2";
            labelMazoJugador2.Size = new Size(27, 22);
            labelMazoJugador2.TabIndex = 59;
            labelMazoJugador2.Text = "00";
            // 
            // HechizosTrampasJ1
            // 
            HechizosTrampasJ1.AllowUserToAddRows = false;
            HechizosTrampasJ1.AllowUserToOrderColumns = true;
            HechizosTrampasJ1.AllowUserToResizeColumns = false;
            HechizosTrampasJ1.AllowUserToResizeRows = false;
            HechizosTrampasJ1.Anchor = AnchorStyles.Bottom;
            HechizosTrampasJ1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HechizosTrampasJ1.BackgroundColor = Color.FromArgb(32, 32, 32);
            HechizosTrampasJ1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HechizosTrampasJ1.ColumnHeadersVisible = false;
            HechizosTrampasJ1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            HechizosTrampasJ1.GridColor = Color.BlueViolet;
            HechizosTrampasJ1.Location = new Point(469, 422);
            HechizosTrampasJ1.Name = "HechizosTrampasJ1";
            HechizosTrampasJ1.ReadOnly = true;
            HechizosTrampasJ1.RowHeadersVisible = false;
            HechizosTrampasJ1.RowHeadersWidth = 51;
            HechizosTrampasJ1.Size = new Size(429, 75);
            HechizosTrampasJ1.TabIndex = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "prueba";
            dataGridViewTextBoxColumn3.MinimumWidth = 75;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "prueba2";
            dataGridViewTextBoxColumn4.MinimumWidth = 75;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.False;
            // 
            // MonsrtuosJ1
            // 
            MonsrtuosJ1.AllowUserToAddRows = false;
            MonsrtuosJ1.AllowUserToOrderColumns = true;
            MonsrtuosJ1.AllowUserToResizeColumns = false;
            MonsrtuosJ1.AllowUserToResizeRows = false;
            MonsrtuosJ1.Anchor = AnchorStyles.Bottom;
            MonsrtuosJ1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MonsrtuosJ1.BackgroundColor = Color.FromArgb(32, 32, 32);
            MonsrtuosJ1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MonsrtuosJ1.ColumnHeadersVisible = false;
            MonsrtuosJ1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            MonsrtuosJ1.GridColor = Color.BlueViolet;
            MonsrtuosJ1.Location = new Point(469, 341);
            MonsrtuosJ1.Name = "MonsrtuosJ1";
            MonsrtuosJ1.ReadOnly = true;
            MonsrtuosJ1.RowHeadersVisible = false;
            MonsrtuosJ1.RowHeadersWidth = 51;
            MonsrtuosJ1.Size = new Size(429, 75);
            MonsrtuosJ1.TabIndex = 61;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "prueba";
            dataGridViewTextBoxColumn5.MinimumWidth = 75;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "prueba2";
            dataGridViewTextBoxColumn6.MinimumWidth = 75;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.False;
            // 
            // HechizosTrampasJ2
            // 
            HechizosTrampasJ2.AllowUserToAddRows = false;
            HechizosTrampasJ2.AllowUserToOrderColumns = true;
            HechizosTrampasJ2.AllowUserToResizeColumns = false;
            HechizosTrampasJ2.AllowUserToResizeRows = false;
            HechizosTrampasJ2.Anchor = AnchorStyles.Bottom;
            HechizosTrampasJ2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HechizosTrampasJ2.BackgroundColor = Color.FromArgb(32, 32, 32);
            HechizosTrampasJ2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HechizosTrampasJ2.ColumnHeadersVisible = false;
            HechizosTrampasJ2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            HechizosTrampasJ2.GridColor = Color.BlueViolet;
            HechizosTrampasJ2.Location = new Point(469, 162);
            HechizosTrampasJ2.Name = "HechizosTrampasJ2";
            HechizosTrampasJ2.ReadOnly = true;
            HechizosTrampasJ2.RowHeadersVisible = false;
            HechizosTrampasJ2.RowHeadersWidth = 51;
            HechizosTrampasJ2.Size = new Size(429, 75);
            HechizosTrampasJ2.TabIndex = 62;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "prueba";
            dataGridViewTextBoxColumn7.MinimumWidth = 75;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "prueba2";
            dataGridViewTextBoxColumn8.MinimumWidth = 75;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Resizable = DataGridViewTriState.False;
            // 
            // MonstruosJ2
            // 
            MonstruosJ2.AllowUserToAddRows = false;
            MonstruosJ2.AllowUserToOrderColumns = true;
            MonstruosJ2.AllowUserToResizeColumns = false;
            MonstruosJ2.AllowUserToResizeRows = false;
            MonstruosJ2.Anchor = AnchorStyles.Bottom;
            MonstruosJ2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MonstruosJ2.BackgroundColor = Color.FromArgb(32, 32, 32);
            MonstruosJ2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MonstruosJ2.ColumnHeadersVisible = false;
            MonstruosJ2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10 });
            MonstruosJ2.GridColor = Color.BlueViolet;
            MonstruosJ2.Location = new Point(469, 243);
            MonstruosJ2.Name = "MonstruosJ2";
            MonstruosJ2.ReadOnly = true;
            MonstruosJ2.RowHeadersVisible = false;
            MonstruosJ2.RowHeadersWidth = 51;
            MonstruosJ2.Size = new Size(429, 75);
            MonstruosJ2.TabIndex = 63;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "prueba";
            dataGridViewTextBoxColumn9.MinimumWidth = 75;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "prueba2";
            dataGridViewTextBoxColumn10.MinimumWidth = 75;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            dataGridViewTextBoxColumn10.Resizable = DataGridViewTriState.False;
            // 
            // CementerioJ1
            // 
            CementerioJ1.AllowUserToAddRows = false;
            CementerioJ1.AllowUserToOrderColumns = true;
            CementerioJ1.AllowUserToResizeColumns = false;
            CementerioJ1.AllowUserToResizeRows = false;
            CementerioJ1.Anchor = AnchorStyles.Bottom;
            CementerioJ1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CementerioJ1.BackgroundColor = Color.FromArgb(32, 32, 32);
            CementerioJ1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CementerioJ1.ColumnHeadersVisible = false;
            CementerioJ1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12 });
            CementerioJ1.GridColor = Color.BlueViolet;
            CementerioJ1.Location = new Point(914, 341);
            CementerioJ1.Name = "CementerioJ1";
            CementerioJ1.ReadOnly = true;
            CementerioJ1.RowHeadersVisible = false;
            CementerioJ1.RowHeadersWidth = 51;
            CementerioJ1.Size = new Size(112, 75);
            CementerioJ1.TabIndex = 64;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "prueba";
            dataGridViewTextBoxColumn11.MinimumWidth = 75;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            dataGridViewTextBoxColumn11.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "prueba2";
            dataGridViewTextBoxColumn12.MinimumWidth = 75;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            dataGridViewTextBoxColumn12.Resizable = DataGridViewTriState.False;
            // 
            // CementerioJ2
            // 
            CementerioJ2.AllowUserToAddRows = false;
            CementerioJ2.AllowUserToOrderColumns = true;
            CementerioJ2.AllowUserToResizeColumns = false;
            CementerioJ2.AllowUserToResizeRows = false;
            CementerioJ2.Anchor = AnchorStyles.Bottom;
            CementerioJ2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CementerioJ2.BackgroundColor = Color.FromArgb(32, 32, 32);
            CementerioJ2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CementerioJ2.ColumnHeadersVisible = false;
            CementerioJ2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14 });
            CementerioJ2.GridColor = Color.BlueViolet;
            CementerioJ2.Location = new Point(341, 243);
            CementerioJ2.Name = "CementerioJ2";
            CementerioJ2.ReadOnly = true;
            CementerioJ2.RowHeadersVisible = false;
            CementerioJ2.RowHeadersWidth = 51;
            CementerioJ2.Size = new Size(112, 75);
            CementerioJ2.TabIndex = 65;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "prueba";
            dataGridViewTextBoxColumn13.MinimumWidth = 75;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            dataGridViewTextBoxColumn13.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "prueba2";
            dataGridViewTextBoxColumn14.MinimumWidth = 75;
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            dataGridViewTextBoxColumn14.Resizable = DataGridViewTriState.False;
            // 
            // botonSiguienteFase
            // 
            botonSiguienteFase.BackColor = Color.Tomato;
            botonSiguienteFase.BackgroundImageLayout = ImageLayout.None;
            botonSiguienteFase.FlatStyle = FlatStyle.Flat;
            botonSiguienteFase.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            botonSiguienteFase.Location = new Point(28, 609);
            botonSiguienteFase.Name = "botonSiguienteFase";
            botonSiguienteFase.Size = new Size(197, 29);
            botonSiguienteFase.TabIndex = 66;
            botonSiguienteFase.Text = "Siguiente Fase";
            botonSiguienteFase.UseVisualStyleBackColor = false;
            botonSiguienteFase.Click += botonSiguienteFase_Click_1;
            // 
            // Juego
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 666);
            Controls.Add(botonSiguienteFase);
            Controls.Add(CementerioJ2);
            Controls.Add(CementerioJ1);
            Controls.Add(MonstruosJ2);
            Controls.Add(HechizosTrampasJ2);
            Controls.Add(MonsrtuosJ1);
            Controls.Add(HechizosTrampasJ1);
            Controls.Add(labelMazoJugador2);
            Controls.Add(labelMazoJugador1);
            Controls.Add(jugador2Mano);
            Controls.Add(jugador1Mano);
            Controls.Add(labelEP);
            Controls.Add(labelM2);
            Controls.Add(labelBP);
            Controls.Add(labelM1);
            Controls.Add(labelSP);
            Controls.Add(labelDP);
            Controls.Add(labelJugador2);
            Controls.Add(labelJugador1);
            Controls.Add(pictureBox43);
            Controls.Add(pictureBox42);
            Controls.Add(jugador2Deck);
            Controls.Add(pictureBox38);
            Controls.Add(pictureBox39);
            Controls.Add(jugador1Deck);
            Controls.Add(pictureBox35);
            Controls.Add(pictureBox34);
            Controls.Add(barraVidaJ2);
            Controls.Add(barraVidaJ1);
            Controls.Add(descripcionCartaSeleccionada);
            Controls.Add(infoCarta);
            Controls.Add(cartaSeleccionadaZoom);
            Controls.Add(pictureBox1);
            Name = "Juego";
            Text = "Juego";
            FormClosing += Juego_FormClosing;
            Load += Juego_Load;
            ((System.ComponentModel.ISupportInitialize)cartaSeleccionadaZoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox34).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox35).EndInit();
            ((System.ComponentModel.ISupportInitialize)jugador1Deck).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox38).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox39).EndInit();
            ((System.ComponentModel.ISupportInitialize)jugador2Deck).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox42).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox43).EndInit();
            ((System.ComponentModel.ISupportInitialize)jugador1Mano).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jugador2Mano).EndInit();
            ((System.ComponentModel.ISupportInitialize)HechizosTrampasJ1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MonsrtuosJ1).EndInit();
            ((System.ComponentModel.ISupportInitialize)HechizosTrampasJ2).EndInit();
            ((System.ComponentModel.ISupportInitialize)MonstruosJ2).EndInit();
            ((System.ComponentModel.ISupportInitialize)CementerioJ1).EndInit();
            ((System.ComponentModel.ISupportInitialize)CementerioJ2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox cartaSeleccionadaZoom;
        private TextBox infoCarta;
        private TextBox descripcionCartaSeleccionada;
        private ProgressBar barraVidaJ1;
        private ProgressBar barraVidaJ2;
        private PictureBox pictureBox34;
        private PictureBox pictureBox35;
        private PictureBox jugador1Deck;
        private PictureBox pictureBox38;
        private PictureBox pictureBox39;
        private PictureBox jugador2Deck;
        private PictureBox pictureBox42;
        private PictureBox pictureBox43;
        private Label labelJugador1;
        private Label labelJugador2;
        private Label labelDP;
        private Label labelSP;
        private Label labelBP;
        private Label labelM1;
        private Label labelEP;
        private Label labelM2;
        private DataGridView jugador1Mano;
        private DataGridViewTextBoxColumn prueba;
        private DataGridViewTextBoxColumn prueba2;
        private PictureBox pictureBox1;
        private DataGridView jugador2Mano;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Label labelMazoJugador1;
        private Label labelMazoJugador2;

        public void setLabelMazoJ1(int cantidad)
        {
            labelMazoJugador1.Text = cantidad.ToString();
        }
        public void setLabelMazoJ2(int cantidad)
        {
            labelMazoJugador2.Text = cantidad.ToString();
        }
        public void setColorFases(EstadoDelJuego estadoDelJuego)
        {
            int faseActual = estadoDelJuego.fase;

            switch (faseActual)
            {
                case 0:
                    labelDP.BackColor = Color.Tomato;
                    labelSP.BackColor = Color.White;
                    labelM1.BackColor = Color.White;
                    labelBP.BackColor = Color.White;
                    labelM2.BackColor = Color.White;
                    labelEP.BackColor = Color.White;
                    break;
                case 1:
                    labelDP.BackColor = Color.White;
                    labelSP.BackColor = Color.Tomato;
                    labelM1.BackColor = Color.White;
                    labelBP.BackColor = Color.White;
                    labelM2.BackColor = Color.White;
                    labelEP.BackColor = Color.White;
                    break;
                case 2:
                    labelDP.BackColor = Color.White;
                    labelSP.BackColor = Color.White;
                    labelM1.BackColor = Color.Tomato;
                    labelBP.BackColor = Color.White;
                    labelM2.BackColor = Color.White;
                    labelEP.BackColor = Color.White;
                    break;
                case 3:
                    labelDP.BackColor = Color.White;
                    labelSP.BackColor = Color.White;
                    labelM1.BackColor = Color.White;
                    labelBP.BackColor = Color.Tomato;
                    labelM2.BackColor = Color.White;
                    labelEP.BackColor = Color.White;
                    break;
                case 4:
                    labelDP.BackColor = Color.White;
                    labelSP.BackColor = Color.White;
                    labelM1.BackColor = Color.White;
                    labelBP.BackColor = Color.White;
                    labelM2.BackColor = Color.Tomato;
                    labelEP.BackColor = Color.White;
                    break;
                case 5:
                
                    labelDP.BackColor = Color.White;
                    labelSP.BackColor = Color.White;
                    labelM1.BackColor = Color.White;
                    labelBP.BackColor = Color.White;
                    labelM2.BackColor = Color.White;
                    labelEP.BackColor = Color.Tomato;
                    break;
            }
        }
        public DataGridView getDataGridManoJ1()
        {
            return jugador1Mano;
        }
        public DataGridView getDataGridManoJ2()
        {
            return jugador2Mano;
        }
        public void actualizarBarraVidaJ1(int vida)
        {
            barraVidaJ1.Value = vida;
        }
        public void actualizarBarraVidaJ2(int vida)
        {
            barraVidaJ2.Value = vida;
        }

        public void mostrarInfoCarta(Carta cartaSeleccionada)
        {
            if (cartaSeleccionada is null)
            {
                infoCarta.Text = "Nombre \r\nATK: \r\nDEF:";
                descripcionCartaSeleccionada.Text = "Descripcion y efectos de la carta";
                cartaSeleccionadaZoom.Image = Image.FromFile(cartaSeleccionada.imagenReverso);
                infoCarta.ForeColor = Color.Black;
                descripcionCartaSeleccionada.ForeColor = Color.White;
                return;
            }

            if (cartaSeleccionada is Monstruo monstruo)
            {
                infoCarta.Text = cartaSeleccionada.nombre + "\r\nATK: " + monstruo.ataque + "\r\nDEF: " + monstruo.defensa;
            }
            else
            {
                infoCarta.Text = cartaSeleccionada.nombre;
            }

            infoCarta.BackColor = cartaSeleccionada.color;
            infoCarta.ForeColor = Color.Black;
            descripcionCartaSeleccionada.Text = cartaSeleccionada.descripcion;
            descripcionCartaSeleccionada.ForeColor = Color.White;
            cartaSeleccionadaZoom.Image = Image.FromFile(cartaSeleccionada.imagen);
        }

        /* 
        */
        public void reiniciarColorTextos()
        {
            infoCarta.ForeColor = Color.Black;
            descripcionCartaSeleccionada.ForeColor = Color.White;
        }

        private DataGridView HechizosTrampasJ1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridView MonsrtuosJ1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView HechizosTrampasJ2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridView MonstruosJ2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridView CementerioJ1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridView CementerioJ2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

        public DataGridView getDataGridHechizosTrampasJ1()
        {
            return HechizosTrampasJ1;
        }
        public DataGridView getDataGridHechizosTrampasJ2()
        {
            return HechizosTrampasJ2;
        }
        public DataGridView getDataGridMonstruosJ1()
        {
            return MonsrtuosJ1;
        }
        public DataGridView getDataGridMonstruosJ2()
        {
            return MonstruosJ2;
        }
        public DataGridView getDataGridCementerioJ1()
        {
            return CementerioJ1;
        }
        public DataGridView getDataGridCementerioJ2()
        {
            return CementerioJ2;
        }

        private Button botonSiguienteFase;
    }

}