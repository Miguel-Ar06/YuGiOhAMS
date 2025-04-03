using NAudio.Wave;
using System;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace YuGiOh
{
    public partial class PantallaBienvenida : Form
    {
        private WaveOutEvent reproductor;
        private AudioFileReader lectorAudio;

        public PantallaBienvenida()
        {
            InitializeComponent();
            PlayBackgroundMusic();
        }

        private void PlayBackgroundMusic()
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("YuGiOh.Properties.Resources", Assembly.GetExecutingAssembly());
                byte[] archivoDeAudioBytes = (byte[])resourceManager.GetObject("NombreDeTuArchivoDeAudio"); // Reemplaza "NombreDeTuArchivoDeAudio" con el nombre de tu archivo de audio en Resources.resx

                if (archivoDeAudioBytes == null)
                {
                    MessageBox.Show("No se encontró el archivo de audio en los recursos.");
                    return;
                }

                MemoryStream streamDeAudio = new MemoryStream(archivoDeAudioBytes);
                streamDeAudio.Position = 0;

                lectorAudio = new AudioFileReader(streamDeAudio);
                lectorAudio = new AudioFileReader(new MemoryStream(archivoDeAudioBytes));

                reproductor = new WaveOutEvent();
                reproductor.Init(lectorAudio);
                reproductor.PlaybackStopped += OnPlaybackStopped;
                reproductor.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reproducir audio: {ex.Message}");
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // loopear el sonido
            lectorAudio.Position = 0;
            reproductor.Play();
        }

        private void botonDuelo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Duelo duelo = new Duelo();
            duelo.Show();
        }

    }
}