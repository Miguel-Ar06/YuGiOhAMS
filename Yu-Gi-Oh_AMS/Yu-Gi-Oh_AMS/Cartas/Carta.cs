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
        protected int id;

        public string nombre {get; set;}
        public string descripcion {get; set;}
        public string tipo {get; set;}
        public Color color {get; set;}
        public bool enMano {get; set;}
        public bool enCampo {get; set;}
        public bool enCementerio {get; set;}
        public bool enMazo {get; set;}
        public bool activada {get; set;}
        public bool volteada {get; set;}
        public string imagenReverso {get; set;}
        public string imagen { get; set; }
    }

    internal class Monstruo : Carta
    {
        public int ataque { get; set; }
        public int defensa { get; set; }
        // public int nivel { get; set; }
        public string atributo { get; set; }
        public string tipoMonstruo { get; set; }
        public bool enModoAtaque { get; set; } // (1 = ataque, 0 = defensa)
        public bool esPenetrante { get; set; }


        Monstruo(int ataque, int defensa, string atributo, string tipo_monstruo, string nombre, string descripcion, string tipo, bool esPenetrante, Color color, string imagen)
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
            this.esPenetrante = esPenetrante;
            this.imagen = imagen;
        }

        public int atacar (Monstruo objetivo)
        {
            if (esPenetrante)
            {
                return ataque;
            }

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
