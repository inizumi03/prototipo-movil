using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoCarta
{
    TurnoPropio,
    TurnoEnemigo
}

public abstract class CartaBase : ScriptableObject
{
    public string nombreCarta;
    public Sprite imagen;
    public TipoCarta tipoCarta;

    public abstract void Activar(GameManger gameManager);
}

