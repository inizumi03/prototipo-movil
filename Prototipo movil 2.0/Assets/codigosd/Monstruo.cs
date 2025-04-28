using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monstruo : MonoBehaviour
{
    [Header("Estadísticas")]
    public int vidaMax = 2000;
    public int vidaActual;

    public int ataque = 1000;

    public int defensaMax = 500;
    public int defensaActual;

    public int hambreMax = 100;
    public int hambreActual = 0;

    [Header("UI")]
    public Image imagenVida;
    public Image barraHambre;
    public Text textoAtaque;
    public Text textoDefensa;

    private bool ataqueBloqueado = false;

    private void Start()
    {
        vidaActual = vidaMax;
        defensaActual = defensaMax;
        hambreActual = 0;
        ActualizarUI();
    }

    public void RecibirDaño(int cantidad)
    {
        if (ataqueBloqueado)
        {
            Debug.Log("¡El ataque fue bloqueado!");
            ataqueBloqueado = false;
            return;
        }

        int dañoRestante = cantidad;

        if (defensaActual > 0)
        {
            int defensaUsada = Mathf.Min(defensaActual, cantidad / 2);
            defensaActual -= defensaUsada;
            dañoRestante -= defensaUsada;
        }

        vidaActual -= dañoRestante;
        if (vidaActual < 0) vidaActual = 0;

        ActualizarUI();
    }

    public void SubirVida(int cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMax) vidaActual = vidaMax;
        ActualizarUI();
    }

    public void SubirAtaque(int cantidad)
    {
        ataque += cantidad;
        ActualizarUI();
    }

    public void SubirDefensa(int cantidad)
    {
        defensaActual += cantidad;
        if (defensaActual > defensaMax) defensaActual = defensaMax;
        ActualizarUI();
    }

    public void BloquearProximoAtaque()
    {
        ataqueBloqueado = true;
    }

    public void AumentarHambre(int cantidad)
    {
        hambreActual += cantidad;
        if (hambreActual > hambreMax) hambreActual = hambreMax;
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (imagenVida != null)
            imagenVida.fillAmount = (float)vidaActual / vidaMax;

        if (barraHambre != null)
            barraHambre.fillAmount = (float)hambreActual / hambreMax;

        if (textoAtaque != null)
            textoAtaque.text = "ATK: " + ataque;

        if (textoDefensa != null)
            textoDefensa.text = "DEF: " + defensaActual;
    }
}
