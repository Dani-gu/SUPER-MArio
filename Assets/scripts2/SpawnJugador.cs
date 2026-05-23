using UnityEngine;

public class SpawnJugador : MonoBehaviour
{
    [Header("Nombre del punto de spawn de esta escena")]
    public string nombreSpawnActual;

    private void Start()
    {
        string spawnGuardado = PlayerPrefs.GetString("SpawnDestino", "");

        if (spawnGuardado == nombreSpawnActual)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");

            if (jugador != null)
            {
                jugador.transform.position = transform.position;

                Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                }
            }
        }
    }
}