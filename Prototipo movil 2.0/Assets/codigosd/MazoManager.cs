using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazoManager : MonoBehaviour
{

    [Header("Cartas en el mazo (ScriptableObjects)")]
    public List<CartaBase> cartasDelMazo;

    [Header("Prefab de carta en mano")]
    public GameObject cartaPrefab;

    [Header("Espacios de la mano (3 espacios máximos)")]
    public List<Transform> espaciosMano;

    [Header("GameManger")]
    public GameManger gameManager;

    // Llamado al iniciar la partida para repartir 3 cartas
    public void RepartirCartasIniciales()
    {
        for (int i = 0; i < 3; i++)
        {
            RobarCartaConMovimiento(i);
        }
    }

    // Llamado por carta de "Robar Carta"
    public void RobarCartaIndividual()
    {
        for (int i = 0; i < espaciosMano.Count; i++)
        {
            if (espaciosMano[i].childCount == 0)
            {
                RobarCartaConMovimiento(i); //  usa la misma animación y proceso
                return;
            }
        }

        Debug.Log("La mano está llena. No se puede robar otra carta.");
    }

    public void RobarCartaConMovimiento(int indiceEspacio)
    {
        if (cartasDelMazo.Count == 0 || cartaPrefab == null || indiceEspacio >= espaciosMano.Count)
            return;

        int indice = Random.Range(0, cartasDelMazo.Count);
        CartaBase cartaElegida = cartasDelMazo[indice];

        // Instanciar en posición del mazo (este GameObject)
        GameObject cartaGO = Instantiate(cartaPrefab, transform.position, Quaternion.identity, espaciosMano[indiceEspacio].parent);

        CartaEnMano cartaScript = cartaGO.GetComponent<CartaEnMano>();
        cartaScript.carta = cartaElegida;
        cartaScript.gameManager = gameManager;
        cartaScript.ActualizarVisual();

        StartCoroutine(MoverCarta(cartaGO.transform, espaciosMano[indiceEspacio].position, 0.3f));
    }

    private IEnumerator MoverCarta(Transform carta, Vector3 destino, float duracion)
    {
        Vector3 origen = carta.position;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duracion;
            carta.position = Vector3.Lerp(origen, destino, t);
            yield return null;
        }

        carta.position = destino;
    }
}
