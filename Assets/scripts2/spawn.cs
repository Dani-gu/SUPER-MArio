using UnityEngine;

public class SpawnPrefabInicio : MonoBehaviour
{
    [Header("Prefab del jugador")]
    public GameObject prefabJugador;

    [Header("Punto donde aparecerá el jugador")]
    public Transform puntoSpawn;

    private void Start()
    {
        if (prefabJugador == null)
        {
            Debug.LogError("No asignaste el prefab del jugador en el SpawnManager.");
            return;
        }

        if (puntoSpawn == null)
        {
            Debug.LogError("No asignaste el punto de spawn en el SpawnManager.");
            return;
        }

        GameObject jugadorExistente = GameObject.FindGameObjectWithTag("Player");

        if (jugadorExistente == null)
        {
            Instantiate(prefabJugador, puntoSpawn.position, puntoSpawn.rotation);
        }
        else
        {
            jugadorExistente.transform.position = puntoSpawn.position;

            Rigidbody2D rb = jugadorExistente.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}