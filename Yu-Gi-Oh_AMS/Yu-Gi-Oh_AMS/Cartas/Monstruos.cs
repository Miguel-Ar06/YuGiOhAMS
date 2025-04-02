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
            "Si ataca a un monstruo con DEF < 1500, lo destruye sin calcular daño.",
            Color.DarkOrange, "Dragón de fuego.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            if (objetivo != null && objetivo.defensa < 1500)
            {
                // Efecto especial: destruye monstruos con DEF < 1500 sin calcular daño
                oponente.campo.eliminarMonstruo(objetivo);
                oponente.cementerio.agregar(objetivo);
                puedeAtacar = false;
                MessageBox.Show($"¡{nombre} activó su efecto! {objetivo.nombre} fue destruido.");
            }
            else
            {
                base.Atacar(objetivo, this, jugador, oponente);
            }
        }
    }

    internal class CaballeroOscuro : Monstruo
    {
        public CaballeroOscuro() : base(1800, 1600, "Caballero Oscuro",
            "Si es destruido, roba +1 carta.",
            Color.DarkOrange, "Caballero oscuro.jpeg")
        { }

        public override void AlSerDestruido(Jugador jugador)
        {
            if (jugador.mazo.tamano > 0)
            {
                Carta cartaRobada = jugador.mazo.desapilar();
                jugador.mano.agregar(cartaRobada);
            }
        }
    }

    internal class GuerreroRelampago : Monstruo
    {
        public GuerreroRelampago() : base(1900, 1200, "Guerrero Relámpago",
            "Si inflige daño directo, el oponente descarta 1 carta.",
            Color.DarkOrange, "Guerrero Relámpago.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            int vidaAntes = oponente.lifePoints;
            base.Atacar(objetivo, this, jugador, oponente);

            // Si hizo daño directo (sin monstruo defensor)
            if (objetivo == null && oponente.lifePoints < vidaAntes)
            {
                if (oponente.mano.tamano > 0)
                {
                    Random rand = new Random();
                    int indice = rand.Next(0, oponente.mano.tamano);
                    Carta descartada = oponente.mano.obtenerDatoPorIndice(indice);
                    oponente.mano.eliminarPorDato(descartada);
                    oponente.cementerio.agregar(descartada);
                    MessageBox.Show($"¡Efecto de {nombre} activado! {oponente.nombre} descartó {descartada.nombre}.");
                }
            }
        }
    }

    internal class LadronFantasma : Monstruo
    {
        public LadronFantasma() : base(1600, 1400, "Ladrón Fantasma",
            "Al invocar, roba +1 carta.",
            Color.DarkOrange, "Ladrón fantasma.jpeg")
        { }

        public void EfectoInvocacion(Jugador jugador)
        {
            Carta cartaRobada = jugador.mazo.desapilar();
            if (cartaRobada != null)
            {
                jugador.mano.agregar(cartaRobada);
                MessageBox.Show($"¡Efecto de {nombre} activado! {jugador.nombre} robó una carta.");
            }
        }
    }

    internal class GolemPiedra : Monstruo
    {
        private bool puedeAtacarEsteTurno = false;

        public GolemPiedra() : base(2000, 2500, "Golem de Piedra",
            "Solo puede atacar cada 2 turnos.",
            Color.DarkOrange, "Golem de piedra.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            if (puedeAtacarEsteTurno)
            {
                base.Atacar(objetivo, this, jugador, oponente);
                puedeAtacarEsteTurno = false;
            }
            else
            {
                MessageBox.Show($"{nombre} no puede atacar este turno (solo ataca cada 2 turnos).");
            }
        }

        public void PrepararNuevoTurno()
        {
            puedeAtacarEsteTurno = !puedeAtacarEsteTurno;
        }
    }

    internal class MagoSombrio : Monstruo
    {
        public MagoSombrio() : base(1700, 1300, "Mago Sombrío",
            "Si destruye un monstruo en batalla, el oponente pierde 500 LP extra.",
            Color.DarkOrange, "Mago sombrío.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            bool destruyoMonstruo;
            if (objetivo.enModoAtaque)
            {
                destruyoMonstruo = objetivo != null && objetivo.ataque < ataque;
            }
            else
            {
                destruyoMonstruo = objetivo != null && objetivo.defensa < ataque;
            }

            base.Atacar(objetivo, this, jugador, oponente);

            if (destruyoMonstruo && objetivo.enCementerio)
            {
                oponente.lifePoints -= 500;
                MessageBox.Show($"¡Efecto de {nombre} activado! {oponente.nombre} pierde 500 LP adicionales.");
            }
        }
    }
    
    internal class DragonDeLava : Monstruo
    {
        public DragonDeLava() : base(2400, 1800, "Dragón de Lava",
            "Si esta carta ataca: inflige 300 daño adicional al oponente.",
            Color.DarkOrange, "Dragón de Lava.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            oponente.recibirDanio(300);
            MessageBox.Show("Se ha activado el efecto del dragon de lava, " + oponente.nombre + " ha perdido 300 LifePoints");
            base.Atacar(objetivo, this, jugador, oponente);
                
        }
    }

    internal class CazadorSigiloso : Monstruo
    {
        public CazadorSigiloso() : base(1700, 1000, "Cazador Sigiloso",
            "Si ataca directamente: descarta 1 carta al azar de la mano del oponente.",
            Color.DarkOrange, "Cazador Sigiloso.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            int vidaAntes = oponente.lifePoints;
            base.Atacar(objetivo, this, jugador, oponente);

            // Si hizo daño directo (sin monstruo defensor)
            if (objetivo == null && oponente.lifePoints < vidaAntes)
            {
                if (oponente.mano.tamano > 0)
                {
                    Random rand = new Random();
                    int indice = rand.Next(0, oponente.mano.tamano);
                    Carta descartada = oponente.mano.obtenerDatoPorIndice(indice);
                    oponente.mano.eliminarPorDato(descartada);
                    oponente.cementerio.agregar(descartada);
                    MessageBox.Show($"¡Efecto de {nombre} activado! {oponente.nombre} descartó {descartada.nombre}.");
                }
            }
        }
    }

    internal class GolemDeGranito : Monstruo
    {
        public GolemDeGranito() : base(2000, 2200, "Golem de Granito",
            "No puede atacar directamente. Si es atacado, el monstruo atacante pierde 500 ATK.",
            Color.DarkOrange, "Golem de granito.jpeg")
        {}

        public override void AlSerAtacado(Monstruo oponente)
        {
            oponente.ataque -= 500;
            MessageBox.Show($"(atacante.nombre) pierde 500 Atk por atacar a {nombre} ");
        }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            if (objetivo == null)
            {
                MessageBox.Show($"¡Efecto de {nombre} no permite atacar al oponente directamente!");
                return;
            }
            base.Atacar(objetivo, this, jugador, oponente);
        }
    }

    internal class HadaSanadora : Monstruo
    {
        public HadaSanadora() : base(800, 1800, "Hada Sanadora",
            "Cuando es invocada: ganas 500 LP.",
            Color.DarkOrange, "Hada sanadora.jpeg")
        { }

        public override void AlSerInvocado(Jugador jugador)
        {
            jugador.lifePoints += 500;
            MessageBox.Show($"{nombre} cura 500 LP a {jugador.nombre}!");
        }
    }

    internal class GuerreroDeLaEspada : Monstruo
    {
        public GuerreroDeLaEspada() : base(1600, 1400, "Guerrero de la Espada",
            "Si destruye un monstruo en batalla: gana 200 ATK.",
            Color.DarkOrange, "Guerrero de la espada.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            bool destruyoMonstruo;
            if (objetivo.enModoAtaque)
            {
                destruyoMonstruo = objetivo != null && objetivo.ataque < ataque;
            }
            else
            {
                destruyoMonstruo = objetivo != null && objetivo.defensa < ataque;
            }

            base.Atacar(objetivo, this, jugador, oponente);

            if (destruyoMonstruo && objetivo.enCementerio)
            {
                this.ataque += 200;
                MessageBox.Show($"{nombre} gana 200 ATK por destruir {objetivo.nombre}!");
            }
        }
    }

    internal class AsaltanteNocturno : Monstruo
    {
        public AsaltanteNocturno() : base(1800, 800, "Asaltante Nocturno",
            "Si ataca un monstruo en Defensa: inflige daño de penetración.",
            Color.DarkOrange, "Asaltante nocturno (1).jpeg") 
            //Mano puedes crear una clase trampas y borrar el archivo random q cree? siva dame chance para solucionar lo de la imagen null, 
        {
            esPenetrante = true;
        }
    }

    internal class LoboDelEclipse : Monstruo
    {
        public LoboDelEclipse() : base(1600, 1200, "Lobo del Eclipse",
            "Al atacar: puedes cambiar la posición del monstruo objetivo.",
            Color.DarkOrange, "Lobo del Eclipse.jpeg") 
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            objetivo.enModoAtaque = !objetivo.enModoAtaque;
            MessageBox.Show($"{nombre} cambia la posición de {objetivo.nombre}!");
            base.Atacar(objetivo, this, jugador, oponente);
        }
    }

    internal class SerpienteVenenosa : Monstruo
    {
        public SerpienteVenenosa() : base(1500, 1200, "Serpiente Venenosa",
            "Si inflige daño de batalla: el oponente pierde 300 LP adicionales.",
            Color.DarkOrange, "Serpiente Venenosa.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            int vidaAntes = oponente.lifePoints;
            base.Atacar(objetivo, this, jugador, oponente);

            // Si hizo daño directo (sin monstruo defensor)
            
            if (oponente.lifePoints < vidaAntes)
            {
                oponente.recibirDanio(300);
                MessageBox.Show($"{nombre} envenena al oponente por 300 LP adicionales!");
            }
            
        }
    }

    internal class SabioDeLosSecretos : Monstruo
    {
        public SabioDeLosSecretos() : base(1000, 2000, "Sabio de los Secretos",
            "Una vez por turno: roba 1 carta si controlas otro monstruo.",
            Color.DarkOrange, "Sabio de los Secretos.jpeg")
        { }

        public void ActivarEfecto(Jugador jugador)
        {
            if (jugador.campo.monstruos.tamano > 1 && jugador.mazo.tamano > 0)
            {
                jugador.robarCarta();
                MessageBox.Show($"{nombre} hace robar 1 carta!");
            }
        }
    }

    internal class DemonioMenor : Monstruo
    {
        public DemonioMenor() : base(2200, 1000, "Demonio Menor",
            "Pierde 500 ATK cada vez que destruye un monstruo.",
            Color.DarkOrange, "Demonio Menor.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            bool destruyoMonstruo;
            if (objetivo.enModoAtaque)
            {
                destruyoMonstruo = objetivo != null && objetivo.ataque < ataque;
            }
            else
            {
                destruyoMonstruo = objetivo != null && objetivo.defensa < ataque;
            }

            base.Atacar(objetivo, this, jugador, oponente);

            if (destruyoMonstruo && objetivo.enCementerio)
            {
                this.ataque -= 500;
                MessageBox.Show($"{nombre} pierde 500 ATK (ahora {ataque})!");
            }
        }
    }

    internal class TigreBlanco : Monstruo
    {
        public TigreBlanco() : base(2100, 1300, "Tigre Blanco",
            "Si ataca un monstruo en Defensa: destruye el objetivo sin calcular daño.",
            Color.DarkOrange, "Tigre blanco.jpeg")
        { }

        public override void Atacar(Monstruo objetivo, Monstruo atacante, Jugador jugador, Jugador oponente)
        {
            if (!objetivo.enModoAtaque)
            {
                puedeAtacar = false;
                oponente.campo.eliminarMonstruo(objetivo);
                objetivo.alCementerio(objetivo);
                objetivo.AlSerDestruido(oponente);

                // durisimo, voy a seguir implementando el main
                MessageBox.Show($"{nombre} destruye {objetivo.nombre} instantáneamente!");
            }
            else
            {
                base.Atacar(objetivo, this, jugador, oponente);
            }
        }
    }




}
