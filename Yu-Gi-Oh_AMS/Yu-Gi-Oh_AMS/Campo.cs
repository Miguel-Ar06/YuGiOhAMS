using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh_AMS.Cartas;

namespace Yu_Gi_Oh_AMS
{
    internal class Campo
    {
        public int monstruosActivos { get; set; }
        public int monstruosEnCampo { get; set; }
        public int hechizosActivos { get; set; }
        public int hechizosEnCampo { get; set; }
        public int trampasActivas { get; set; }
        public int trampasEnCampo { get; set; }

        public Cola<Monstruo> monstruos = new Cola<Monstruo>();
        public Cola<Carta> hechizosYTrampas = new Cola<Carta>();
       
        public Campo()
        {
            monstruosActivos = 0;
            monstruosEnCampo = 0;
            hechizosActivos = 0;
            hechizosEnCampo = 0;
            trampasActivas = 0;
            trampasEnCampo = 0;
        }

        public int contarMonstruos()
        {
            return monstruosEnCampo;
        }

        public int contarZonaMagicas()
        {
            return (trampasEnCampo + hechizosEnCampo);
        }
        public void agregarMonstruo(Monstruo monstruo)
        {
            monstruos.encolar(monstruo);
            monstruosEnCampo++;
        }

        public void agregarHechizoOTrampa(Carta carta)
        {
            hechizosYTrampas.encolar(carta);
            hechizosEnCampo++;
        }

        public void eliminarMonstruo(Monstruo monstruo)
        {
            monstruos.extraerPorDato(monstruo);
            monstruosEnCampo--;
        }

        public void eliminarHechizoOTrampa(Carta carta)
        {
            hechizosYTrampas.extraerPorDato(carta);
            hechizosEnCampo--;
        }

    }
}
