using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cartas/Comida")]
public class CartaComida : CartaBase
{
    public int cantidadHambre = 25;

    public override void Activar(GameManger gameManager)
    {
        gameManager.AumentarHambreMonstruo(cantidadHambre);
        Debug.Log("Monstruo ha comido. Hambre aumentada en " + cantidadHambre);
    }
}
