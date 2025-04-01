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
    }
}
