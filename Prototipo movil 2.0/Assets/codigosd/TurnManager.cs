using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Turno
{
    Jugador,
    Enemigo
}
public class TurnManager : MonoBehaviour
{
    public Turno turnoActual = Turno.Jugador;

    public Monstruo monstruoJugador;
    public Monstruo monstruoEnemigo;

    public Text textoTurno; // Mostrar "Turno del Jugador" o "Turno del Enemigo"
    public Button botonAtacar;

    private void Start()
    {
        ActualizarUI();
    }

    public void BotonAtacar()
    {
        if (turnoActual != Turno.Jugador) return;

        // Atacar enemigo
        monstruoEnemigo.RecibirDaño(monstruoJugador.ataque);
        CambiarTurno();
    }

    private void CambiarTurno()
    {
        if (turnoActual == Turno.Jugador)
        {
            turnoActual = Turno.Enemigo;
            StartCoroutine(TurnoDelEnemigo());
        }
        else
        {
            turnoActual = Turno.Jugador;
        }

        ActualizarUI();
    }

    private IEnumerator TurnoDelEnemigo()
    {
        yield return new WaitForSeconds(1f); // pequeño retraso para realismo

        monstruoJugador.RecibirDaño(monstruoEnemigo.ataque);

        CambiarTurno();
    }

    private void ActualizarUI()
    {
        if (textoTurno != null)
        {
            textoTurno.text = (turnoActual == Turno.Jugador) ? "Tu Turno" : "Turno del Enemigo";
        }

        if (botonAtacar != null)
        {
            botonAtacar.interactable = (turnoActual == Turno.Jugador);
        }
    }
}
