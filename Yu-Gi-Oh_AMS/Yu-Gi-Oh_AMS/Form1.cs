using NAudio.Wave;

namespace Yu_Gi_Oh_AMS
{
    public partial class Form1 : Form
    {
        public bool loopeandoMusica = true;
        public WaveOutEvent reproductor = new WaveOutEvent();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string rutaDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDelAudio = Path.Combine(rutaDeLaAplicacion, "Resources", "Yu-Gi-Oh! GX Duel Academy - Main Screen.wav");
            reproductor.PlaybackStopped += reproductor_ReproduccionTerminada;
            AudioFileReader archivoDeAudio = new AudioFileReader(rutaDelAudio);

            reproductor.Init(archivoDeAudio);
            reproductor.Play();
        }

        private void botonJugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            loopeandoMusica = false;
            reproductor.Stop();
            Juego juegoForm = new Juego();
            juegoForm.Show();
        }

        private void reproductor_ReproduccionTerminada(object sender, StoppedEventArgs e)
        {
            if (loopeandoMusica)
            {
                string rutaDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
                string rutaDelAudio = Path.Combine(rutaDeLaAplicacion, "Resources", "Yu-Gi-Oh! GX Duel Academy - Main Screen.wav");

                WaveOutEvent reproductor = (WaveOutEvent)sender;
                reproductor.Dispose();

                reproductor = new WaveOutEvent();
                AudioFileReader archivoDeAudio = new AudioFileReader(rutaDelAudio);
                reproductor.Init(archivoDeAudio);
                reproductor.Play();
            }
        }
    }
}
