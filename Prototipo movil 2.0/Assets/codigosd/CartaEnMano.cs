using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaEnMano : MonoBehaviour
{

    public CartaBase carta;
    public GameManger gameManager;

    public Image imagenCarta;
    public Text nombreCarta;

    private void Start()
    {
        ActualizarVisual();
    }

    public void ActivarCarta()
    {
        if (carta != null && gameManager != null)
        {
            carta.Activar(gameManager);
            Destroy(gameObject); // Elimina la carta usada
        }
        else
        {
            Debug.LogWarning("Falta carta o GameManager en CartaEnMano.");
        }
    }

    public void ActualizarVisual()
    {
        if (imagenCarta != null) imagenCarta.sprite = carta.imagen;
        if (nombreCarta != null) nombreCarta.text = carta.nombreCarta;
    }
}
