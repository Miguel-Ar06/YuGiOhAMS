namespace Yu_Gi_Oh_AMS.Cartas
{

    internal class EspejoFuerza : Trampa
    {
        public EspejoFuerza() : base("Espejo de Fuerza",
            "Si un enemigo ataca, destruye a todos sus monstruos en ataque.",
            "Trampa", Color.Fuchsia, "Espejo de fuerza.jpeg")
        { }

        public void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo atacante)
        {
            if (atacante != null)
            {
                List<Monstruo> monstruosADestruir = new List<Monstruo>();

                // Identificar monstruos en posición de ataque
                for (int i = 0; i < oponente.campo.monstruos.tamano; i++)
                {
                    var monstruo = oponente.campo.monstruos.obtenerDatoPorIndice(i) as Monstruo;
                    if (monstruo != null && monstruo.enModoAtaque)
                    {
                        monstruosADestruir.Add(monstruo);
                    }
                }

                // Destruir los monstruos
                foreach (var monstruo in monstruosADestruir)
                {
                    oponente.campo.eliminarMonstruo(monstruo);
                    oponente.cementerio.agregar(monstruo);
                }

                // Mover esta trampa al cementerio
                jugador.campo.eliminarHechizoOTrampa(this);
                jugador.cementerio.agregar(this);

                MessageBox.Show($"¡{nombre} activado! Se destruyeron {monstruosADestruir.Count} monstruos atacantes.");
            }
        }
    }

    internal class MuroDefensa : Trampa
    {
        public MuroDefensa() : base("Muro de Defensa",
            "Niega un ataque y termina la batalla.",
            "Trampa", Color.Fuchsia, "Muro de defensa.jpeg")
        { }

        public void ActivarEfecto(Jugador jugador, Monstruo atacante)
        {
            if (atacante != null)
            {
                atacante.puedeAtacar = false;

                // Mover esta trampa al cementerio
                jugador.campo.eliminarHechizoOTrampa(this);
                jugador.cementerio.agregar(this);

                MessageBox.Show($"¡{nombre} activado! El ataque de {atacante.nombre} fue negado.");
            }
        }
    }

    internal class RefuerzoDefensivo : Trampa
    {
        public RefuerzoDefensivo() : base("Refuerzo defensivo",
            "Aumenta la DEF de todos tus monstruos en 500 hasta el final del turno.",
            "Trampa", Color.Fuchsia, "Refuerzo Defensivo.jpeg")
        { }

        List<Monstruo> monstruosDefensaAumento = new List<Monstruo>();

        public void ActivarEfecto(Jugador jugador, Jugador oponente, Monstruo atacante)
        {
            for (int i = 0; i < jugador.campo.monstruos.tamano; i++)
            {
                var monstruo = jugador.campo.monstruos.obtenerDatoPorIndice(i) as Monstruo;
                if (monstruo != null)
                {
                    monstruo.defensa += 500;
                }
            }

            jugador.campo.eliminarHechizoOTrampa(this);
            jugador.cementerio.agregar(this);

            MessageBox.Show($"¡{nombre} activado! Se aumentó en 500 la defensa a {monstruosDefensaAumento.Count} monstruos.");

        }

        public void RevertirEfecto(Jugador jugador, Jugador oponente, Monstruo atacante)
        {
            for (int i = 0; i < jugador.campo.monstruos.tamano; i++)
            {
                var monstruo = jugador.campo.monstruos.obtenerDatoPorIndice(i) as Monstruo;
                if (monstruo != null)
                {
                    monstruo.defensa = monstruo.defensaOriginal;
                }
            }
            //peluche, voy a compilar pa ve
        }
    }
}