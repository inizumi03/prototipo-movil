using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Cartas/Bloquear Ataque")]
public class CartaBloquearAtaque : CartaBase
{
    public override void Activar(GameManger gameManager)
    {
        gameManager.monstruo.BloquearProximoAtaque();
        Debug.Log("¡Próximo ataque bloqueado!");
    }
}
