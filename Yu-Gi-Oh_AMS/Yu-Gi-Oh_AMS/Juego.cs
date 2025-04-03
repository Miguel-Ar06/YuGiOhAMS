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
        private WaveOutEvent reproductor = new WaveOutEvent();

        private Jugador jugador1;
        private DataGridView manoJ1;
        private DataGridView monstruosJ1;
        private DataGridView hechizosYTrampasJ1;
        private DataGridView cementerioJ1;

        private Jugador jugador2;
        private DataGridView manoJ2;
        private DataGridView monstruosJ2;
        private DataGridView hechizosYTrampasJ2;
        private DataGridView cementerioJ2;

        private EstadoDelJuego estadoDelJuego;
        private int turno = 0;

        public Juego()
        {
            InitializeComponent();
        }

        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            string rutaDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDelAudio = Path.Combine(rutaDeLaAplicacion, "Resources", "Yu Gi Oh! Japanese OST Yugi's Theme.wav");

            reproductor.PlaybackStopped += Reproductor_ReproduccionTerminada;
            AudioFileReader archivoDeAudio = new AudioFileReader(rutaDelAudio);
            reproductor.Init(archivoDeAudio);
            reproductor.Play();

            estadoDelJuego = new EstadoDelJuego();

            manoJ1 = getDataGridManoJ1();
            monstruosJ1 = getDataGridMonstruosJ1();
            hechizosYTrampasJ1 = getDataGridHechizosTrampasJ1();
            CementerioJ1 = getDataGridCementerioJ1();

            manoJ2 = getDataGridManoJ2();

            BindingList<Type> todasLasCartas = InicializarCartas();

            jugador1 = new Jugador(1, "Jugador 1", true);
            jugador2 = new Jugador(2, "Jugador 2", false);
            actualizarBarraVidaJ1(jugador1.lifePoints);
            actualizarBarraVidaJ2(jugador2.lifePoints);

            LlenarMazos(jugador1, todasLasCartas);
            LlenarMazos(jugador2, todasLasCartas);

            RepartirCartasIniciales(jugador1);
            RepartirCartasIniciales(jugador2);

            actualizarManos();

            estadoDelJuego.jugando = true;
            setColorFases(estadoDelJuego);
        }

        private DataGridView ConfigurarDataGridView()
        {
            DataGridView dataGridView = new DataGridView
            {
                RowHeadersVisible = false,
                ColumnHeadersVisible = false
            };
            return dataGridView;
        }

        private BindingList<Type> InicializarCartas()
        {
            return new BindingList<Type>
            {
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
                typeof(TormentaRelampago),
                typeof(RecargaMagica),
                typeof(EspadaDestino),
                typeof(CuracionSuprema),
                typeof(ControlMental),
                typeof(MuroDefensa),
                typeof(EspejoFuerza),
                typeof(RefuerzoDefensivo)
            };
        }

        private void LlenarMazos(Jugador jugador, BindingList<Type> todasLasCartas)
        {
            Random random = new Random();
            for (int i = 0; i < 60; i++)
            {
                int indiceAleatorio = random.Next(0, todasLasCartas.Count);
                Type tipoDeCarta = todasLasCartas[indiceAleatorio];
                Carta carta = (Carta)Activator.CreateInstance(tipoDeCarta);
                jugador.mazo.apilar(carta);
            }
        }

        private void RepartirCartasIniciales(Jugador jugador)
        {
            for (int i = 0; i < 5; i++)
            {
                Carta carta = jugador.mazo.desapilar();
                jugador.mano.agregar(carta);
            }
            if (jugador.numero == 1)
                setLabelMazoJ1(jugador.mazo.tamano);
            else
                setLabelMazoJ2(jugador.mazo.tamano);
        }

        public void actualizarManos()
        {
            ConfigurarDataGridViewManos(manoJ1, jugador1);
            ConfigurarDataGridViewManos(manoJ2, jugador2);
        }

        private void ConfigurarDataGridViewManos(DataGridView dataGridView, Jugador jugador)
        {
            int cartaAlto = 75;
            int cartaAncho = 52;

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            for (int i = 0; i < jugador.mano.tamano; i++)
            {
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                {
                    HeaderText = $"Carta {i + 1}",
                    Name = $"CartaImage{i + 1}",
                    ImageLayout = DataGridViewImageCellLayout.Stretch
                };
                dataGridView.Columns.Add(imageColumn);
                dataGridView.Columns[i].Width = cartaAncho;
            }

            dataGridView.Rows.Add();
            dataGridView.Rows[0].Height = cartaAlto;

            for (int i = 0; i < jugador.mano.tamano; i++)
            {
                Carta carta = jugador.mano.obtenerDatoPorIndice(i);
                string imagenPath = carta.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso");

                try
                {
                    Image image = Image.FromFile(imagenPath);
                    dataGridView.Rows[0].Cells[i].Value = image;
                    dataGridView.Rows[0].Cells[i].Tag = carta;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Error al cargar imagen para {carta.nombre}");
                }
            }
        }

        private void Reproductor_ReproduccionTerminada(object sender, StoppedEventArgs e)
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
            Carta cartaSeleccionada = (Carta)manoJ1.Rows[0].Cells[e.ColumnIndex].Tag;
            mostrarInfoCarta(cartaSeleccionada);
            reiniciarColorTextos();
        }

        private void jugador2Mano_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Carta cartaSeleccionada = (Carta)manoJ2.Rows[0].Cells[e.ColumnIndex].Tag;
            mostrarInfoCarta(cartaSeleccionada);
            reiniciarColorTextos();
        }

        private void jugador1Mano_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (turno % 2 == 0 && (estadoDelJuego.fase == 2 || estadoDelJuego.fase == 4))
            {
                Carta cartaSeleccionada = (Carta)manoJ1.Rows[0].Cells[e.ColumnIndex].Tag;
                if (cartaSeleccionada is Monstruo monstruo && jugador1.campo.monstruos.tamano < 5 && monstruosJ1.Columns.Count < 5)
                {
                    jugador1.campo.agregarMonstruo(monstruo);
                    monstruo.puedeAtacar = false;
                    jugador1.mano.eliminarPorDato(monstruo);
                    monstruosJ1.Columns.Add(new DataGridViewImageColumn
                    {
                        HeaderText = $"Monstruo {monstruosJ1.Columns.Count + 1}",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Image = Image.FromFile(monstruo.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso"))
                    });
                }
                else if (cartaSeleccionada is Hechizo hechizo && jugador1.campo.hechizosYTrampas.tamano < 5 && hechizosYTrampasJ1.Columns.Count < 5)
                {
                    jugador1.campo.agregarHechizoOTrampa(hechizo);
                    jugador1.mano.eliminarPorDato(hechizo);
                    hechizosYTrampasJ1.Columns.Add(new DataGridViewImageColumn
                    {
                        HeaderText = $"Hechizo/Trampa {hechizosYTrampasJ1.Columns.Count + 1}",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Image = Image.FromFile(hechizo.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso"))
                    });
                }
                else if (cartaSeleccionada is Trampa trampa && jugador1.campo.hechizosYTrampas.tamano < 5 && hechizosYTrampasJ1.Columns.Count < 5)
                {
                    jugador1.campo.agregarHechizoOTrampa(trampa);
                    jugador1.mano.eliminarPorDato(trampa);
                    hechizosYTrampasJ1.Columns.Add(new DataGridViewImageColumn
                    {
                        HeaderText = $"Hechizo/Trampa {hechizosYTrampasJ1.Columns.Count + 1}",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Image = Image.FromFile(trampa.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso"))
                    });
                }
                actualizarManos();
                //actualizarCampo();
            }
        }

        private void jugador2Mano_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (turno % 2 != 0 && (estadoDelJuego.fase == 2 || estadoDelJuego.fase == 4))
            {
                Carta cartaSeleccionada = (Carta)manoJ2.Rows[0].Cells[e.ColumnIndex].Tag;
                if (cartaSeleccionada is Monstruo monstruo && jugador2.campo.monstruos.tamano < 5 && monstruosJ2.Columns.Count < 5)
                {
                    jugador2.campo.agregarMonstruo(monstruo);
                    monstruo.puedeAtacar = false;
                    jugador2.mano.eliminarPorDato(monstruo);
                    monstruosJ2.Columns.Add(new DataGridViewImageColumn
                    {
                        HeaderText = $"Monstruo {monstruosJ2.Columns.Count + 1}",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Image = Image.FromFile(monstruo.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso"))
                    });
                }
                else if (cartaSeleccionada is Hechizo hechizo && jugador2.campo.hechizosYTrampas.tamano < 5 && hechizosYTrampasJ2.Columns.Count < 5)
                {
                    jugador2.campo.agregarHechizoOTrampa(hechizo);
                    jugador2.mano.eliminarPorDato(hechizo);
                    hechizosYTrampasJ2.Columns.Add(new DataGridViewImageColumn
                    {
                        HeaderText = $"Hechizo/Trampa {hechizosYTrampasJ2.Columns.Count + 1}",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Image = Image.FromFile(hechizo.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso"))
                    });
                }
                else if (cartaSeleccionada is Trampa trampa && jugador2.campo.hechizosYTrampas.tamano < 5 && hechizosYTrampasJ2.Columns.Count < 5)
                {
                    jugador2.campo.agregarHechizoOTrampa(trampa);
                    jugador2.mano.eliminarPorDato(trampa);
                    hechizosYTrampasJ2.Columns.Add(new DataGridViewImageColumn
                    {
                        HeaderText = $"Hechizo/Trampa {hechizosYTrampasJ2.Columns.Count + 1}",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Image = Image.FromFile(trampa.imagen ?? Carta.ObtenerRutaImagen("YuGiOhCartaReverso"))
                    });
                }
                actualizarManos();
                //actualizarCampo();
            }
        }

        private void botonSiguienteFase_Click_1(object sender, EventArgs e)
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
                    }
                    else
                    {
                        MessageBox.Show("Turno J2: Fase de robo");
                        jugador2.robarCarta();
                        setLabelMazoJ2(jugador2.mazo.tamano);
                    }
                    actualizarManos();
                    break;
                case 1:
                    MessageBox.Show("Fase inicial");
                    break;
                case 2:
                    MessageBox.Show("Fase de preparacion 1");
                    break;
                case 3:
                    MessageBox.Show("Fase batalla");
                    break;
                case 4:
                    MessageBox.Show("Fase de preparacion 2");
                    break;
                case 5:
                    MessageBox.Show("Fase final");
                    break;
            }
        }
    }
}
