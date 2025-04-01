using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh_AMS.Cartas;

namespace Yu_Gi_Oh_AMS
{
    internal class Jugador
    {
        public int numero { get; set; }
        public string nombre { get; set; }
        public int lifePoints { get; set; }
        public int cartasEnMano { get; set; }

        public bool esTurno { get; set; }

        public bool puedeInvocar { get; set; }

        public ListaDoble<Carta> mano = new ListaDoble<Carta>();
        public Campo campo = new Campo();
        public ListaDoble<Carta> cementerio = new ListaDoble<Carta>();
        public Pila<Carta> mazo = new Pila<Carta>();

        public Jugador(int numero, string nombre, bool esTurno)
        {
            this.numero = numero;
            this.nombre = nombre;
            lifePoints = 8000;
            cartasEnMano = 0;
            this.esTurno = esTurno;
        }

        public void robarCarta()
        {
            Carta carta = mazo.desapilar();
            mano.agregar(carta);
            cartasEnMano++;
        }

        public void jugarCarta(Carta carta)
        {
            if (carta is Monstruo)
            {
                campo.agregarMonstruo((Monstruo)carta);
                this.puedeInvocar = false;
            }
            else if (carta is Hechizo)
            {
                campo.agregarHechizoOTrampa((Hechizo)carta);
            }
            else if (carta is Trampa)
            {
                campo.agregarHechizoOTrampa((Trampa)carta);
            }
            
            mano.eliminarPorDato(carta);
            cartasEnMano--;
        }

        public void descartarCarta(Carta carta)
        {
            mano.eliminarPorDato(carta);
            cartasEnMano--;
            cementerio.agregar(carta);
        }

        public void recibirDanio(int danio)
        {
            lifePoints -= danio;
        }

        public void barajearMazo()
        {
            mazo.revolver();
        }

    }
}
