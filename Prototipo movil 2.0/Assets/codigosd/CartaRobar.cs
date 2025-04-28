using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cartas/Robar Carta")]
public class CartaRobar : CartaBase
{
    public override void Activar(GameManger gameManager)
    {
        gameManager.RobarCartaDesdeMazo();
        Debug.Log("¡Has robado una carta del mazo!");
    }
}