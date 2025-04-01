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
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Color color { get; set; }
        public string tipo { get; set; }
        public bool enMano { get; set; }
        public bool enCampo { get; set; }
        public bool enCementerio { get; set; }
        public bool enMazo { get; set; }
        public bool activada { get; set; }
        public bool volteada { get; set; }
        public string imagenReverso { get; set; }
        public string imagen { get; set; }

        public virtual void ActivarEfecto(Jugador jugador, Jugador oponente) { }
    }

    internal class Monstruo : Carta
    {
        public int ataque { get; set; }
        public int defensa { get; set; }

        public bool puedeAtacar { get; set;}

        public bool enModoAtaque { get; set; } // (1 = ataque, 0 = defensa)
        public bool esPenetrante { get; set; }


        public Monstruo(int ataque, int defensa,  string nombre, string descripcion, Color color, string imagen)
        {
            this.ataque = ataque;
            this.defensa = defensa;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = "Monstruo";
            this.color = color;
            volteada = false;
            enModoAtaque = true;
            enCampo = false;
            enCementerio = false;
            enMano = false;
            enMazo = false;
            activada = false;
            this.esPenetrante = false;
            this.imagen = imagen;
        }

        public void atacar (Monstruo objetivo, Jugador jugador, Jugador Oponente )
        {
            int diferencia;

            

            if (esPenetrante && !objetivo.enModoAtaque)
            {
                puedeAtacar = false;
                diferencia = ataque - objetivo.defensa;
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
                diferencia = ataque - objetivo.ataque;
                puedeAtacar = false;

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
                    enCementerio = true;
                    objetivo.enCementerio = true;
                    return;
                }
            }
            else
            {
                puedeAtacar = false;
                diferencia = ataque - objetivo.defensa;

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
        
        // int duracion;

        public Hechizo ( string nombre, string descripcion, Color color, string imagen)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = "Magia";
            this.color = color;
            volteada = false;
            enCampo = false;
            enCementerio = false;
            enMano = false;
            enMazo = false;
            activada = false;
            this.imagen = imagen;
        }

        public virtual void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo monstruo)
        {

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
