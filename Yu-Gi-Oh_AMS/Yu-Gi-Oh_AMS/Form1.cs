namespace Yu_Gi_Oh_AMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void botonJugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Juego juegoForm = new Juego();
            juegoForm.Show();
        }
    }
}
