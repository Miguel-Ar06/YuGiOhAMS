using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh_AMS
{
    public class EstadoDelJuego
    {
        private bool Jugando;
        public bool jugando
        {
            get { return Jugando; }
            set { Jugando = value; }
        }

        private int Fase;
        public int fase
        {
            get { return Fase; }
            set { Fase = value; }
        }

        private int Ganador;
        public int ganador
        {
            get { return Ganador; }
            set { Ganador = value; }
        }

        public EstadoDelJuego()
        {
            Jugando = true;
            Fase = 0;
            Ganador = -1;
        }
        public void siguienteFase()
        {
            if (fase == 5)
            {
                fase = 0;
                return;
            }
            Fase++;

        }
    }
}
