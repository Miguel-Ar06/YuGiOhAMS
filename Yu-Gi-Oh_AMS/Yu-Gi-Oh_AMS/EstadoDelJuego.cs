using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_AMS
{
    internal class EstadoDelJuego
    {
        public bool jugando { get; set; }
        public bool faseInicial { get; set; }
        public bool faseDeRobo { get; set; }
        public bool faseDePreparacion1 { get; set; }
        public bool faseDeAtaque { get; set; }
        public bool faseDePreparacion2 { get; set; }
        public bool faseFinal { get; set; }
        public int ganador { get; set; }

        public EstadoDelJuego()
        {
            jugando = true; 
            faseInicial = true;
            faseDeRobo = false;
            faseDePreparacion1 = false;
            faseDeAtaque = false;
            faseDePreparacion2 = false;
            faseFinal = false;
            ganador = 0;
        }
        public void siguienteFase()
        {
            if (faseInicial)
            {
                faseInicial = false;
                faseDeRobo = true;
            }
            else if (faseDeRobo)
            {
                faseDeRobo = false;
                faseDePreparacion1 = true;
            }
            else if (faseDePreparacion1)
            {
                faseDePreparacion1 = false;
                faseDeAtaque = true;
            }
            else if (faseDeAtaque)
            {
                faseDeAtaque = false;
                faseDePreparacion2 = true;
            }
            else if (faseDePreparacion2)
            {
                faseDePreparacion2 = false;
                faseFinal = true;
            }
            else if (faseFinal)
            {
                faseFinal = false;
                faseInicial = true;
            }
        }

        // no se si falta algo mas

    }
}
