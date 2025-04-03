using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh_AMS.Cartas;

namespace Yu_Gi_Oh_AMS
{
    public class Jugador
    {
        protected int Numero;
        public int numero 
        {
            get { return Numero; }
            set { Numero = value; }
        }

        protected string Nombre;
        public string nombre 
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        protected int LifePoints;
        public int lifePoints 
        {
            get { return LifePoints; }
            set { LifePoints = value; }
        }

        protected int CartasEnMano;
        public int cartasEnMano
        {
            get { return CartasEnMano; }
            set { CartasEnMano = value; }
        }

        protected bool EsTurno;
        public bool esTurno
        {
            get { return EsTurno; }
            set { EsTurno = value; }
        }

        protected bool PuedeInvocar; 
        public bool puedeInvocar
        {
            get { return PuedeInvocar; }
            set { PuedeInvocar = value; }
        }

        public ListaDoble<Carta> mano;
        public Campo campo;
        public ListaDoble<Carta> cementerio;
        public Pila<Carta> mazo;

        public Jugador(int numero, string nombre, bool esTurno)
        {
            this.Numero = numero;
            this.Nombre = nombre;
            LifePoints = 8000;
            CartasEnMano = 0;
            this.EsTurno = esTurno;

            mano = new ListaDoble<Carta>();
            campo = new Campo();
            cementerio = new ListaDoble<Carta>();
            mazo = new Pila<Carta>();
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

        public void SetPuedeInvocar(bool invocar)
        {
            this.puedeInvocar = invocar;
        }

        public bool GetPuedeInvocar()
        {
            return this.puedeInvocar;
        }
    }
}
