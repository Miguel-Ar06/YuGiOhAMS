using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_AMS.Cartas
{
    internal class DragonDeFuego : Monstruo
    {
        public DragonDeFuego() : base(2500, 2000, "Dragón de Fuego",
            "Si ataca a un monstruo con DEF < 1500, lo destruye sin calcular daño.", Color.Black , "Moguel, pon aqui el png")
        { }

        public override void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo objetivo)
        {
            if (objetivo != null && objetivo.defensa < 1500)
            {
                oponente.campo.eliminarMonstruo(objetivo);
                oponente.cementerio.agregar(objetivo);
                MessageBox.Show($"El monstruo {objetivo.nombre} fue destruido por Dragón de Fuego.");
            }
        }

        internal class CaballeroOscuro : Monstruo
        {
            public CaballeroOscuro() : base(1800, 1600, "Caballero Oscuro",
                "Si es destruido, roba +1 carta.",Color.Black, "Moguel, pon aqui el png")
            { }

            public override void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo objetivo)
            {
                if (this.enCementerio)
                {
                    Carta cartaRobada = jugador.mazo.desapilar();
                    if (cartaRobada != null)
                    {
                        jugador.mano.agregar(cartaRobada);
                        // MessageBox.Show($"{jugador.nombre} robó una carta gracias al efecto de Caballero Oscuro.");
                    }
                }
            }
        }

        internal class GuerreroRelampago : Monstruo
        {
            public GuerreroRelampago() : base(1900, 1200, "Guerrero Relámpago",
                "Si inflige daño directo, el oponente descarta 1 carta.", Color.Black, "Moguel, pon aqui el png")
            { }

            public override void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo objetivo)
            {
                if (objetivo == null && oponente.campo.contarMonstruos() == 0)
                {
                    if (oponente.mano.tamano > 0)
                    {
                        Random random = new Random();
                        int indiceAleatorio = random.Next(0, oponente.mano.tamano);
                        Carta cartaDescartada = oponente.mano.obtenerDatoPorIndice(indiceAleatorio);
                        oponente.mano.eliminarPorDato(cartaDescartada);
                        oponente.cementerio.agregar(cartaDescartada);
                        // MessageBox.Show($"El efecto de Guerrero Relámpago hizo que {oponente.nombre} descartara {cartaDescartada.nombre}.");
                    }
                }
            }
        }
    }
}
