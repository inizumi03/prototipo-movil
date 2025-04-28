using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cartas/Subir Ataque")]
public class CartaSubirAtaque : CartaBase
{
    public int cantidad = 200;

    public override void Activar(GameManger gameManager)
    {
        gameManager.monstruo.SubirAtaque(cantidad);
        Debug.Log("Ataque aumentado en " + cantidad);
    }
}
