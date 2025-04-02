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
using Yu_Gi_Oh_AMS.Cartas;

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
        o clase jugador con vida, nombre, mano, coleccion, cementerio, campo etc etc
            o clase campo (que en realidad tienen funcionalidades de listas pero andres pide colas)
                o instancia "mano" de lista doble
                o instancia "mazo" de pila
                o instancia "campoJ1" y "campoJ2" de cola
                o instancia "cementerio" de lista
        o clase EstadoDelJuego (con bools para las fases y asi)

        
        (nota, todas las EDD son del tipo generico <T> para poder usarlas con el dato que nos de la gana, 
        y todos los nodos tienen indice para jorungarlos a gusto durante el juego, 
        asi podemos escoger quien ataca a quien como en yugioh real)
        
        x clases individuales de cada carta
        x manejo de turnos del juego en el main
        x manejo de dano con los metodos "atacar" (o efecto) de cada carta
        x implementar los efectos de todas las cartas
        x efectos en la interfaz para visualizar quien ataca a quien (me encargo yo)
        x crear un bindginList para las cartas de cada jugador y asociarlas al datagrid de la mano de cada jugador
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

        Jugador jugador1;
        Jugador jugador2;
        DataGridView manoJugador1;
        DataGridView manoJugador2;
        EstadoDelJuego estadoDelJuego;

        int turno = 0;


        private void Juego_Load(object sender, EventArgs e)
        {

            string rutaDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDelAudio = Path.Combine(rutaDeLaAplicacion, "Resources", "Yu Gi Oh! Japanese OST Yugi's Theme.wav");

            reproductor.PlaybackStopped += reproductor_ReproduccionTerminada;
            AudioFileReader archivoDeAudio = new AudioFileReader(rutaDelAudio);
            reproductor.Init(archivoDeAudio);
            reproductor.Play();

            estadoDelJuego = new EstadoDelJuego();

            manoJugador1 = getDataGridManoJ1();
            manoJugador1.RowHeadersVisible = false;
            manoJugador1.ColumnHeadersVisible = false;

            manoJugador2 = getDataGridManoJ2();
            manoJugador2.RowHeadersVisible = false;
            manoJugador2.ColumnHeadersVisible = false;

            // lista de clases con modelos de cartas
            #region cartas inicializadas
            BindingList<Type> todasLasCartas = new BindingList<Type>
            {

                // monstruos
                typeof(DragonDeFuego),
                typeof(CaballeroOscuro),
                typeof(GuerreroRelampago),
                typeof(LadronFantasma),
                typeof(GolemPiedra),
                typeof(MagoSombrio),
                typeof(DragonDeLava),
                typeof(CazadorSigiloso),
                typeof(GolemDeGranito),
                typeof(HadaSanadora),
                typeof(GuerreroDeLaEspada),
                typeof(AsaltanteNocturno),
                typeof(LoboDelEclipse),
                typeof(SerpienteVenenosa),
                typeof(SabioDeLosSecretos),
                typeof(DemonioMenor),
                typeof(TigreBlanco),

                // hechizos
                typeof(TormentaRelampago),
                typeof(RecargaMagica),
                typeof(EspadaDestino),
                typeof(CuracionSuprema),
                typeof(ControlMental),

                // trampas
                typeof(MuroDefensa),
                typeof(EspejoFuerza),
                typeof(RefuerzoDefensivo),
            };
            #endregion

            // inicializar jugadores
            jugador1 = new Jugador(8000, "Jugador 1", true);
            jugador2 = new Jugador(8000, "Jugador 2", false);
            actualizarBarraVidaJ1(jugador1.lifePoints);
            actualizarBarraVidaJ2(jugador2.lifePoints);

            // llenar los mazos con 60 cartas aleatorias para cada jugador
            for (int i = 0; i < 60; i++)
            {
                Random random = new Random();
                int indiceAleatorio = random.Next(0, todasLasCartas.Count);

                Type tipoDeCarta = todasLasCartas[indiceAleatorio];
                Carta carta = (Carta)Activator.CreateInstance(tipoDeCarta);

                jugador1.mazo.apilar(carta);
            }
            for (int i = 0; i < 60; i++)
            {
                Random random = new Random();
                int indiceAleatorio = random.Next(0, todasLasCartas.Count);

                Type tipoDeCarta = todasLasCartas[indiceAleatorio];
                Carta carta = (Carta)Activator.CreateInstance(tipoDeCarta);

                jugador2.mazo.apilar(carta);
            }

            // repartir 5 cartas a cada jugador
            for (int i = 0; i < 5; i++)
            {
                Carta carta = jugador1.mazo.desapilar();
                jugador1.mano.agregar(carta);
            }
            setLabelMazoJ1(jugador1.mazo.tamano);

            for (int i = 0; i < 5; i++)
            {
                Carta carta = jugador2.mazo.desapilar();
                jugador2.mano.agregar(carta);
            }
            setLabelMazoJ2(jugador2.mazo.tamano);

            actualizarManos();

            //comenzar el juego
            estadoDelJuego.jugando = true;
            setColorFases(estadoDelJuego);
        }

        public void actualizarManos()
        {
            // llenar los datagrid con las imagenes de la mano de los jugadores
            int cartaAlto = 75;
            int cartaAncho = 52;


            manoJugador1.Columns.Clear();
            manoJugador1.Rows.Clear();
            manoJugador2.Columns.Clear();
            manoJugador2.Rows.Clear();

            // agregar columnas para cada carta del jugador
            for (int i = 0; i < jugador1.mano.tamano; i++)
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.HeaderText = $"Carta {i + 1}";
                imageColumn.Name = $"CartaImage{i + 1}";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                manoJugador1.Columns.Add(imageColumn);
                manoJugador1.Columns[i].Width = cartaAncho;

            }

            for (int i = 0; i < jugador2.mano.tamano; i++)
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.HeaderText = $"Carta {i + 1}";
                imageColumn.Name = $"CartaImage{i + 1}";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                manoJugador2.Columns.Add(imageColumn);
                manoJugador2.Columns[i].Width = cartaAncho;
            }

            // agregar una sola fila para cada datagrid
            manoJugador1.Rows.Add();
            manoJugador2.Rows.Add();

            manoJugador1.Rows[0].Height = cartaAlto;
            manoJugador2.Rows[0].Height = cartaAlto;

            // poblar esa fila con la imagen de una carta por columna
            for (int i = 0; i < jugador1.mano.tamano; i++)
            {
                Image image;
                Carta carta = jugador1.mano.obtenerDatoPorIndice(i);
                if (jugador1.mano.obtenerDatoPorIndice(i).imagen == null || jugador1.mano.obtenerDatoPorIndice(i) == null)
                {
                    image = Image.FromFile(jugador1.mano.obtenerDatoPorIndice(i).imagenReverso);
                }
                else
                {
                    try
                    {
                        image = Image.FromFile(jugador1.mano.obtenerDatoPorIndice(i).imagen);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al Cargar imagen para " + jugador1.mano.obtenerDatoPorIndice(i).nombre);
                        image = Image.FromFile(jugador1.mano.obtenerDatoPorIndice(i).imagenReverso);
                    }
                }
                manoJugador1.Rows[0].Cells[i].Value = image;
                manoJugador1.Rows[0].Cells[i].Tag = carta;

            }

            for (int i = 0; i < jugador2.mano.tamano; i++)
            {
                Image image;
                Carta carta = jugador2.mano.obtenerDatoPorIndice(i);
                if (jugador2.mano.obtenerDatoPorIndice(i).imagen == null || jugador2.mano.obtenerDatoPorIndice(i) == null)
                {
                    image = Image.FromFile(jugador2.mano.obtenerDatoPorIndice(i).imagenReverso);
                }
                else
                {
                    try
                    {
                        image = Image.FromFile(jugador2.mano.obtenerDatoPorIndice(i).imagen);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al Cargar imagen para " + jugador2.mano.obtenerDatoPorIndice(i).nombre);
                        image = Image.FromFile(jugador2.mano.obtenerDatoPorIndice(i).imagenReverso);
                    }
                }
                manoJugador2.Rows[0].Cells[i].Value = image;
                manoJugador2.Rows[0].Cells[i].Tag = carta;
            }

        }

        public void actualizarCampo()
        {
            // asignarle a cada picture box las imagenes correspondientes segun el campo del jugador

            setImagenJugador1Monstruo1(jugador1.campo.monstruos.extraerPorIndice(0).imagen);
            setImagenJugador1Monstruo2(jugador1.campo.monstruos.extraerPorIndice(1).imagen);
            setImagenJugador1Monstruo3(jugador1.campo.monstruos.extraerPorIndice(2).imagen);
            setImagenJugador1Monstruo4(jugador1.campo.monstruos.extraerPorIndice(3).imagen);
            setImagenJugador1Monstruo5(jugador1.campo.monstruos.extraerPorIndice(4).imagen);

            setImagenJugador1HT1(jugador1.campo.hechizosYTrampas.extraerPorIndice(0).imagen);
            setImagenJugador1HT2(jugador1.campo.hechizosYTrampas.extraerPorIndice(1).imagen);
            setImagenJugador1HT3(jugador1.campo.hechizosYTrampas.extraerPorIndice(2).imagen);
            setImagenJugador1HT4(jugador1.campo.hechizosYTrampas.extraerPorIndice(3).imagen);
            setImagenJugador1HT5(jugador1.campo.hechizosYTrampas.extraerPorIndice(4).imagen);

            setImagenJugador2Monstruo1(jugador2.campo.monstruos.extraerPorIndice(0).imagen);
            setImagenJugador2Monstruo2(jugador2.campo.monstruos.extraerPorIndice(1).imagen);
            setImagenJugador2Monstruo3(jugador2.campo.monstruos.extraerPorIndice(2).imagen);
            setImagenJugador2Monstruo4(jugador2.campo.monstruos.extraerPorIndice(3).imagen);
            setImagenJugador2Monstruo5(jugador2.campo.monstruos.extraerPorIndice(4).imagen);

            setImagenJugador2HT1(jugador2.campo.hechizosYTrampas.extraerPorIndice(0).imagen);
            setImagenJugador2HT2(jugador2.campo.hechizosYTrampas.extraerPorIndice(1).imagen);
            setImagenJugador2HT3(jugador2.campo.hechizosYTrampas.extraerPorIndice(2).imagen);
            setImagenJugador2HT4(jugador2.campo.hechizosYTrampas.extraerPorIndice(3).imagen);
            setImagenJugador2HT5(jugador2.campo.hechizosYTrampas.extraerPorIndice(4).imagen);

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

        private void jugador1Mano_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Carta cartaSeleccionada = (Carta)manoJugador1.Rows[0].Cells[e.ColumnIndex].Tag;
            mostrarInfoCarta(cartaSeleccionada);
            reiniciarColorTextos();
        }

        private void jugador2Mano_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Carta cartaSeleccionada = (Carta)manoJugador2.Rows[0].Cells[e.ColumnIndex].Tag;
            mostrarInfoCarta(cartaSeleccionada);
            reiniciarColorTextos();
        }

        private void botonSiguienteFase_Click(object sender, EventArgs e)
        {
            estadoDelJuego.siguienteFase();
            setColorFases(estadoDelJuego);

            switch (estadoDelJuego.fase)
            {
                case 0:
                    turno++;

                    if (turno % 2 == 0)
                    {
                        MessageBox.Show("Turno J1: Fase de robo");

                        jugador1.robarCarta();
                        setLabelMazoJ1(jugador1.mazo.tamano);
                        actualizarManos();
                    }
                    else
                    {
                        MessageBox.Show("Turno J2: Fase de robo");

                        jugador2.robarCarta();
                        setLabelMazoJ2(jugador2.mazo.tamano);
                        actualizarManos();
                    }

                    break;
                case 1:
                    MessageBox.Show("Fase inicial");
                    break;
                case 2:
                    MessageBox.Show("Fase de preparacion 1");
                    if (turno % 2 == 0)
                    {
                        setColorCampos(Color.MidnightBlue, Color.MidnightBlue, Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32));
                    }
                    else
                    {
                        setColorCampos(Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32), Color.MidnightBlue, Color.MidnightBlue);
                    }
                    break;
                case 3:
                    MessageBox.Show("Fase batalla");
                    if (turno % 2 == 0)
                    {
                        setColorCampos(Color.MidnightBlue, Color.MidnightBlue, Color.Firebrick, Color.FromArgb(32, 32, 32));
                    }
                    else
                    {
                        setColorCampos(Color.Firebrick, Color.FromArgb(32, 32, 32), Color.MidnightBlue, Color.MidnightBlue);
                    }
                    break;
                case 4:
                    MessageBox.Show("Fase de preparacion 2");
                    if (turno % 2 == 0)
                    {
                        setColorCampos(Color.MidnightBlue, Color.MidnightBlue, Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32));
                    }
                    else
                    {
                        setColorCampos(Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32), Color.MidnightBlue, Color.MidnightBlue);
                    }
                    break;
                case 5:
                    setColorCampos(Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32), Color.FromArgb(32, 32, 32));
                    MessageBox.Show("Fase final");
                    if (turno % 2 == 0)
                    {
                        // dejar solo 6 cartas en mano j1
                    }
                    else
                    {
                        // dejar solo 6 cartas en mano j2
                    }
                    break;
            }
        }

        private void jugador1Mano_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (turno % 2 == 0)
            {
                if (estadoDelJuego.fase == 2)
                {
                    // agregar cartas a su area respectiva del campo
                    Carta cartaSeleccionada = (Carta)manoJugador1.Rows[0].Cells[e.ColumnIndex].Tag;
                    if (cartaSeleccionada is Monstruo monstruo && jugador1.campo.monstruos.tamano < 5)
                    {
                        jugador1.campo.agregarMonstruo(monstruo);
                        monstruo.puedeAtacar = false;
                        jugador1.mano.eliminarPorDato(monstruo);
                        actualizarManos();
                    }
                    else if (cartaSeleccionada is Hechizo hechizo && jugador1.campo.hechizosYTrampas.tamano < 5)
                    {
                        jugador1.campo.agregarHechizoOTrampa(hechizo);
                        jugador1.mano.eliminarPorDato(hechizo);
                        actualizarManos();
                    }
                    else if (cartaSeleccionada is Trampa trampa && jugador1.campo.hechizosYTrampas.tamano < 5)
                    {
                        jugador1.campo.agregarHechizoOTrampa(trampa);
                        jugador1.mano.eliminarPorDato(trampa);
                        actualizarManos();
                    }

                    actualizarCampo();
                }
            }
        }
    }
}
