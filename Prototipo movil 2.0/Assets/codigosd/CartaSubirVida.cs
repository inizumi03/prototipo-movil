using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Cartas/Subir Vida")]
public class CartaSubirVida : CartaBase
{
    public int cantidad = 500;

    public override void Activar(GameManger gameManager)
    {
        gameManager.monstruo.SubirVida(cantidad);
        Debug.Log("Vida aumentada en " + cantidad);
    }
}