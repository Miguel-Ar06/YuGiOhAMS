using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Yu_Gi_Oh_AMS
{
    /* TODO:

        x = falta
        o = listo
        
        o clase carta
        o clase monstruo : carta (con metodo atacar y manejo de stats)
        o clase hechizo : carta
        o clase trampa : carta
        o Nodo y lista simple (con todos los metodos)
        o Nodo y lista doble (con todos los metodos)
        o Cola (con todos los metodos)
        o Pila (con todos los metodos)
        o menu principal
        o pantalla de juego
        o musica (de eso me encargo yo)

        
        (nota, todas las EDD son del tipo generico <T> para poder usarlas con el dato que nos de la gana, 
        y todos los nodos tienen indice para jorungarlos a gusto durante el juego, 
        asi podemos escoger quien ataca a quien como en yugioh real)
        
        x clases individuales de cada carta
        x clase EstadoDelJuego (con bools para las fases y asi)
        x instancia "mano" de lista doble
        x instancia "coleccion" de pila
        x instancia "campoJ1" y "campoJ2" de cola
        x instancia "cementerio" de lista
        x manejo de turnos del juego en el main
        x clase campoDelJugador con 2 colas (que en realidad tienen funcionalidades de listas pero andres pide colas)
        x clase jugador con vida, nombre, mano, coleccion, cementerio, campo etc etc
        x manejo de dano con los metodos "atacar" (o efecto) de cada carta
        x implementar los efectos de todas las cartas
        x efectos en la interfaz para visualizar quien ataca a quien (me encargo yo)
        x una forma mejor de manejar la mano en la interfaz, 
            porque puse 6 picturebox para la mano pero el jugador puede tener mas de 6 cartas 
            en ciertos momentos del turno entonces tengo que ver como manejarlo, 
            tengo pensado con un combobox que albergue las cartas adicionales y al final del turno 
            ese combobox se vacia y solo queden las de la mano
        x los turnos se manejan mostrando las cartas de uno y esocndiendo las del otro y al momento de cambiar de turno se muestra un
            mensaje y se cambia algun color o no se, o simplemente mostramos todas la cartas de todos d=todo el tiempo y ya
     */

    public partial class Juego : Form
    {
        public Juego()
        {
            InitializeComponent();
        }

        public WaveOutEvent reproductor = new WaveOutEvent();

        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            string rutaDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDelAudio = Path.Combine(rutaDeLaAplicacion, "Resources", "Yu Gi Oh! Japanese OST Yugi's Theme.wav");

            reproductor.PlaybackStopped += reproductor_ReproduccionTerminada;
            AudioFileReader archivoDeAudio = new AudioFileReader(rutaDelAudio);
            reproductor.Init(archivoDeAudio);
            reproductor.Play();
        }

        // reproducir la musica de nuevo si llega a su fin
        private void reproductor_ReproduccionTerminada(object sender, StoppedEventArgs e)
        {
            string rutaDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDelAudio = Path.Combine(rutaDeLaAplicacion, "Resources", "Yu Gi Oh! Japanese OST Yugi's Theme.wav");

            WaveOutEvent reproductor = (WaveOutEvent)sender;
            reproductor.Dispose();

            reproductor = new WaveOutEvent();
            AudioFileReader archivoDeAudio = new AudioFileReader(rutaDelAudio);
            reproductor.Init(archivoDeAudio);
            reproductor.Play();
        }
    }
}
