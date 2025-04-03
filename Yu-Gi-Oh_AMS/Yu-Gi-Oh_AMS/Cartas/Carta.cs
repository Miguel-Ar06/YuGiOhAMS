using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace Yu_Gi_Oh_AMS.Cartas
{


    public class Carta
    {
        protected string Nombre;
        public string nombre 
        { 
            get { return Nombre; }
            set { Nombre = value; }
        }

        protected string Descripcion;
        public string descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        protected Color Color;
        public Color color 
        {
            get { return Color; }
            set { Color = value; }
        }

        protected string Tipo;
        public string tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }

        protected bool EnMano;
        public bool enMano 
        {
            get { return EnMano; }
            set { EnMano = value; }
        }

        protected bool EnCampo;
        public bool enCampo
        {
            get { return EnCampo; }
            set { EnCampo = value; }
        }

        protected bool EnCementerio;
        public bool enCementerio 
        {
            get { return EnCementerio; }
            set { EnCementerio = value; }
        }

        protected bool EnMazo;
        public bool enMazo
        {
            get { return EnMazo; }
            set { EnMazo = value; }
        }

        protected bool Activada;
        public bool activada
        {
            get { return Activada; }
            set { Activada = value; }
        }

        protected bool Volteada;
        public bool volteada
        {
            get { return Volteada; }
            set { Volteada = value; }
        }

        protected string ImagenReverso = ObtenerRutaImagen("YuGiOhCartaReverso.png");
        public string imagenReverso 
        {
            get { return ImagenReverso; }
            set { ImagenReverso = value; }
        }

        protected string Imagen;
        public string imagen 
        {
            get { return Imagen; }
            set { Imagen = value; } 
        }

        public virtual void ActivarEfecto(Jugador jugador, Jugador oponente) { }

        public static string ObtenerRutaImagen(string nombre)
        {
            string ruta;
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            ruta = Path.Combine(rutaAplicacion, "Img", nombre);

            return ruta;
        }
    }

    public class Monstruo : Carta
    {
        protected int Ataque; 
        public int ataque
        {
            get { return Ataque; }
            set { Ataque = value; }
        }

        protected int AtaqueOriginal;
        public int ataqueOriginal
        {
            get { return ataqueOriginal; }
        }

        protected int Defensa;
        public int defensa
        {
            get { return Defensa; }
            set { Defensa = value; }
        }

        protected int DefensaOriginal;
        public int defensaOriginal
        {
            get { return DefensaOriginal; }
        }

        protected bool PuedeAtacar;
        public bool puedeAtacar
        {
            get { return PuedeAtacar; }
            set { PuedeAtacar = value; }
        }
    
        protected bool EnModoAtaque; // (1 = ataque, 0 = defensa) 
        public bool enModoAtaque
        {
            get { return EnModoAtaque; }
            set { EnModoAtaque = value; }
        } 

        protected bool EsPenetrante; 
        public bool esPenetrante
        {
            get { return EsPenetrante; }
            set { EsPenetrante = value; }
        }

        public Monstruo(int ataque, int defensa,  string nombre, string descripcion, Color color, string nombreImagen)
        {
            this.Ataque = ataque;
            this.AtaqueOriginal = ataque;
            this.Defensa = defensa;
            this.DefensaOriginal = defensa;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Tipo = "Monstruo";
            this.Color = color;
            Volteada = false;
            EnModoAtaque = true;
            EnCampo = false;
            EnCementerio = false;
            EnMano = false;
            EnMazo = false;
            Activada = false;
            this.EsPenetrante = false;
            this.Imagen = ObtenerRutaImagen(nombreImagen);
            // sacar la direccion de la imagen del reverso de la carta y asignarla al atributo de la imagen del reverso
        }

        public virtual void AlSerDestruido(Jugador jugador )
        {
            return;
        }

        public virtual void AlSerAtacado(Monstruo oponente)
        {
            return;
        }

        public virtual void AlSerInvocado(Jugador jugador)
        {
            return;
        }

        public void alCementerio(Monstruo monstruo)
        {
            monstruo.EnCampo = false;
            monstruo.EnCementerio = true;
        }

        // Modificar el método Atacar para llamar a AlSerDestruido cuando corresponda
        public virtual void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            int diferencia;
            puedeAtacar = false;
            objetivo.AlSerAtacado(atacante);

            if (objetivo == null)
            {
                // Ataque directo
                oponente.recibirDanio(ataque);
                puedeAtacar = false;
                return;
            }

            if (esPenetrante && !objetivo.enModoAtaque)
            {
                // Efecto penetrante
                diferencia = ataque - objetivo.defensa;

                if (diferencia > 0)
                {
                    oponente.recibirDanio(diferencia);
                    oponente.campo.eliminarMonstruo(objetivo);
                    objetivo.alCementerio(objetivo);
                    objetivo.AlSerDestruido(oponente);
                }
                else if (diferencia < 0)
                {
                    jugador.recibirDanio(Math.Abs(diferencia));
                }
                return;
            }

            if (objetivo.enModoAtaque)
            {
                // Ataque vs Ataque
                diferencia = ataque - objetivo.ataque;

                if (diferencia > 0)
                {
                    oponente.campo.eliminarMonstruo(objetivo);
                    objetivo.alCementerio(objetivo);
                    oponente.recibirDanio(diferencia);
                    objetivo.AlSerDestruido(oponente);
                }
                else if (diferencia < 0)
                {
                    jugador.campo.eliminarMonstruo(atacante);
                    atacante.alCementerio(atacante);
                    AlSerDestruido(jugador);
                    jugador.recibirDanio(Math.Abs(diferencia));
                }
                else
                {
                    jugador.campo.eliminarMonstruo(atacante);
                    alCementerio(atacante);
                    AlSerDestruido(jugador);
                    oponente.campo.eliminarMonstruo(objetivo);
                    objetivo.alCementerio(objetivo);
                    objetivo.AlSerDestruido(oponente);
                }
            }
            else
            {
                // Ataque vs Defensa
                diferencia = ataque - objetivo.defensa;
                if (diferencia > 0)
                {
                    objetivo.AlSerDestruido(oponente);
                    objetivo.alCementerio(objetivo);
                    oponente.campo.eliminarMonstruo(objetivo);
                }
                else if (diferencia < 0)
                {
                    jugador.recibirDanio(Math.Abs(diferencia));
                }
            }
        }
        public void cambiarPosicion()
        {
            EnModoAtaque = !EnModoAtaque;
        }

        public virtual void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo objetivo) { }
    }

    public class Hechizo : Carta
    {
        // int duracion;

        public Hechizo ( string nombre, string descripcion, Color color, string nombreImagen)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Tipo = "Magia";
            this.Color = color;
            Volteada = false;
            EnCampo = false;
            EnCementerio = false;
            EnMano = false;
            EnMazo = false;
            Activada = false;
            this.Imagen = ObtenerRutaImagen(nombreImagen);
        }

        public virtual void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo monstruo)
        {

        }
    }

    public class Trampa : Carta
    {
        // int duracion;

        public Trampa(string nombre, string descripcion, string tipo, Color color, string nombreImagen)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Tipo = tipo;
            this.Color = color;
            Volteada = false;
            EnCampo = false;
            EnCementerio = false;
            EnMano = false;
            EnMazo = false;
            Activada = false;
            this.Imagen = ObtenerRutaImagen(nombreImagen);
        }
    }
}
