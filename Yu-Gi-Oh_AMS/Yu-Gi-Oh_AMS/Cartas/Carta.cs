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
        protected string nombre;
        protected string descripcion;
        protected string tipo;
        protected Color color;
        protected bool enMano;
        protected bool enCampo;
        protected bool enCementerio;
        protected bool enMazo;
        protected bool activada;
        protected bool volteada;

        protected string imagenReverso;
        protected string imagen;
    }

    internal class Monstruo : Carta
    {
        public int ataque { get; set; }
        public int defensa { get; set; }
        // public int nivel { get; set; }
        public string atributo { get; set; }
        public string tipoMonstruo { get; set; }
        public bool enModoAtaque { get; set; } // (1 = ataque, 0 = defensa)

        Monstruo(int ataque, int defensa, string atributo, string tipo_monstruo, string nombre, string descripcion, string tipo, Color color, string imagen)
        {
            this.ataque = ataque;
            this.defensa = defensa;
            this.atributo = atributo;
            this.tipoMonstruo = tipo_monstruo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.color = color;
            volteada = false;
            enModoAtaque = true;
            enCampo = false;
            enCementerio = false;
            enMano = false;
            enMazo = false;
            activada = false;
            this.imagen = imagen;
        }

        public int atacar (Monstruo objetivo)
        {
            int diferencia;

            if (objetivo.enModoAtaque)
            {
                diferencia = ataque - objetivo.ataque;

                if (diferencia > 0)
                {
                    objetivo.enCementerio = true;
                    return diferencia;
                }
                else if (diferencia < 0)
                {
                    enCementerio = true;
                    return diferencia;
                }
                else
                {
                    enCementerio = true;
                    objetivo.enCementerio = true;
                    return 0;
                }
            }
            else
            {
                diferencia = ataque - objetivo.defensa;

                if (diferencia > 0)
                {
                    objetivo.enCementerio = true;
                    return diferencia;
                }
                else if (diferencia < 0)
                {
                    return diferencia;
                }
                else
                {
                    objetivo.enCementerio = true;
                    return 0;
                }
            }
        }
    }

    internal class Hechizo : Carta
    {
        public string efecto { get; set; }
        // int duracion;

        public Hechizo (string efecto, string nombre, string descripcion, string tipo, Color color, string imagen)
        {
            this.efecto = efecto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.color = color;
            volteada = false;
            enCampo = false;
            enCementerio = false;
            enMano = false;
            enMazo = false;
            activada = false;
            this.imagen = imagen;
        }
    }

    internal class Trampa : Carta
    {
        public string efecto { get; set; }
        // int duracion;
        public Trampa(string efecto, string nombre, string descripcion, string tipo, Color color, string imagen)
        {
            this.efecto = efecto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.color = color;
            volteada = false;
            enCampo = false;
            enCementerio = false;
            enMano = false;
            enMazo = false;
            activada = false;
            this.imagen = imagen;
        }
    }
}
