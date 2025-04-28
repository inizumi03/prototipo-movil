using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public Monstruo monstruo;
    public MazoManager mazoManager;

    private void Start()
    {
        StartCoroutine(RepartirCartasAnimadas());
    }

    public void AumentarAtaqueMonstruo(int cantidad)
    {
        monstruo.SubirAtaque(cantidad);
    }

    public void CurarVidaMonstruo(int cantidad)
    {
        monstruo.SubirVida(cantidad);
    }

    public void BloquearProximoAtaque()
    {
        monstruo.BloquearProximoAtaque();
    }

    public void RobarCartaDesdeMazo()
    {
        if (mazoManager != null)
            mazoManager.RobarCartaIndividual();
    }
    public void AumentarHambreMonstruo(int cantidad)
    {
        if (monstruo != null)
            monstruo.AumentarHambre(cantidad);
    }
    private IEnumerator RepartirCartasAnimadas()
    {
        for (int i = 0; i < 3; i++)
        {
            mazoManager.RobarCartaConMovimiento(i);
            yield return new WaitForSeconds(0.3f); // pequeño retraso entre cada carta
        }
    }
}
