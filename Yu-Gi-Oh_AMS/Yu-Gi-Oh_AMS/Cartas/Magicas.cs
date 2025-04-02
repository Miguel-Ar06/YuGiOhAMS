using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_AMS.Cartas
{
    internal class TormentaRelampago : Hechizo
    {
        public TormentaRelampago() : base("Tormenta Relámpago",
            "Destruye todos los monstruos en el campo del oponente con menos de 2000 ATK.", Color.MediumTurquoise, "Tormenta relámpago.jpeg")
        { }

        public override void ActivarEfecto(Jugador jugador, Jugador oponente)
        {
            var cartasADestruir = new List<Monstruo>();

            for (int i = 0; i < oponente.campo.monstruos.tamano; i++)
            {
                var carta = oponente.campo.monstruos.obtenerDatoPorIndice(i);
                if (carta.ataque < 2000)
                {
                    cartasADestruir.Add(carta);
                }
            }
            foreach (var carta in cartasADestruir)
            {
                oponente.campo.eliminarMonstruo(carta);
                oponente.cementerio.agregar(carta);
            }
        }
    }

    internal class RecargaMagica : Hechizo
    {
        public RecargaMagica() : base("Recarga Mágica", "Roba 2 cartas.", Color.MediumTurquoise, "Recarga mágica.jpg") { }

        public override void ActivarEfecto(Jugador jugador, Jugador oponente)
        {
            for (int i = 0; i < 2; i++)
            {
                Carta cartaRobada = jugador.mazo.desapilar();
                if (cartaRobada != null)
                {
                    jugador.mano.agregar(cartaRobada);
                }
            }
        }
    }

    internal class EspadaDestino : Hechizo
    {
        public EspadaDestino() : base("Espada del Destino",
            "+1000 ATK a un monstruo (1 turno).", Color.MediumTurquoise, "Espada del destino.jpeg")
        { }

        public override void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo monstruo)
        {
            if (monstruo != null)
            {
                monstruo.ataque += 1000;

                // Aquí se debería implementar la lógica para revertir el efecto después de 1 turno
                // Esto puede implicar almacenar el estado original y restaurarlo después de un turno
            }
        }
    }

    internal class CuracionSuprema : Hechizo
    {
        public CuracionSuprema() : base("Curación Suprema",
            "+2000 LP al jugador.", Color.MediumTurquoise, "Curación suprema.jpeg")
        { }

        public override void ActivarEfecto(Jugador jugador, Jugador oponente)
        {
            jugador.lifePoints += 2000;
        }
    }

    internal class ControlMental : Hechizo
    {
        public ControlMental() : base("Control Mental",
            "Toma el control de un monstruo enemigo (1 turno).", Color.MediumTurquoise, "Control mental (1).jpeg")
        { }

        public override void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo monstruo)
        {
            oponente.campo.eliminarMonstruo(monstruo);
            jugador.campo.agregarMonstruo(monstruo);
            //Aun le falta
        }
    }
}



