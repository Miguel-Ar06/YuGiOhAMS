using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace Yu_Gi_Oh_AMS.Cartas
{


    internal class Carta
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

        protected string ImagenReverso;
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
    }

    internal class Monstruo : Carta
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

        public Monstruo(int ataque, int defensa,  string nombre, string descripcion, Color color, string imagen)
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
            this.Imagen = imagen;
            // sacar la direccion de la imagen del reverso de la carta y asignarla al atributo de la imagen del reverso
        }

        public void atacar (Monstruo objetivo, Jugador jugador, Jugador Oponente )
        {
            int diferencia;

            if (EsPenetrante && !objetivo.enModoAtaque)
            {
                PuedeAtacar = false;
                diferencia = Ataque - objetivo.defensa;
                if (diferencia > 0)
                {
                    Oponente.recibirDanio(diferencia);
                    objetivo.enCementerio = true;
                    return;
                }
                else if (diferencia == 0)
                {
                    return;
                }
                else
                {
                    jugador.recibirDanio((-1) * diferencia);
                    return;
                }
            }

           
            if (objetivo.enModoAtaque)
            {
                diferencia = Ataque - objetivo.ataque;
                PuedeAtacar = false;

                if (diferencia > 0)
                {
                    objetivo.enCementerio = true;
                    Oponente.recibirDanio(diferencia);
                    return;
                }
                else if (diferencia < 0)
                {
                    enCementerio = true;
                    jugador.recibirDanio((-1) * diferencia);
                    return;
                }
                else
                {
                    EnCementerio = true;
                    objetivo.enCementerio = true;
                    return;
                }
            }
            else
            {
                PuedeAtacar = false;
                diferencia = Ataque - objetivo.defensa;

                if (diferencia > 0)
                {
                    objetivo.enCementerio = true;
                    return;
                }
                else if (diferencia < 0)
                {
                    jugador.recibirDanio((-1) * diferencia);
                    return;
                }
                else
                {
                    objetivo.enCementerio = true;
                    return ;
                }
            }
        }

        public virtual void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo objetivo) { }
    }

    internal class Hechizo : Carta
    {
        protected string Efecto;
        public string efecto
        {
            get { return Efecto; }
            set { Efecto = value; }
        }
        // int duracion;

        public Hechizo (string efecto, string nombre, string descripcion, string tipo, Color color, string imagen)
        {
            this.Efecto = efecto;
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
            this.Imagen = imagen;
        }
    }

    internal class Trampa : Carta
    {
        protected string Efecto; 
        public string efecto 
        {
            get { return Efecto; }
            set { Efecto = value; }
        }

        // int duracion;

        public Trampa(string efecto, string nombre, string descripcion, string tipo, Color color, string imagen)
        {
            this.Efecto = efecto;
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
            this.Imagen = imagen;
        }
    }
}
