using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalNivel : MonoBehaviour
{
    [Header("Configuración")]
    public string nombreEscenaCastillo = "castillo";
    public float velocidadCaminar = 2f;

    [Header("Referencias")]
    public Transform puntoCastillo;

    private bool nivelFinalizado = false;
    private bool jugadorEnMovimiento = false;
    private Transform jugador;
    private Rigidbody2D rbJugador;

    void Update()
    {
        if (jugadorEnMovimiento && jugador != null && puntoCastillo != null)
        {
            MoverJugadorAlCastillo();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (gameObject.CompareTag("FlagPole") && !nivelFinalizado)
        {
            FinalizarNivel(collision.gameObject);
        }

        if (gameObject.CompareTag("Castle") && nivelFinalizado)
        {
            CambiarEscenaCastillo();
        }
    }

    public void FinalizarNivel(GameObject player)
    {
        nivelFinalizado = true;

        jugador = player.transform;
        rbJugador = player.GetComponent<Rigidbody2D>();

        if (rbJugador != null)
        {
            rbJugador.linearVelocity = Vector2.zero;
        }

        jugadorEnMovimiento = true;

        MonoBehaviour[] scriptsJugador = player.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scriptsJugador)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }
    }

    public void MoverJugadorAlCastillo()
    {
        Vector2 posicionActual = jugador.position;
        Vector2 posicionDestino = new Vector2(puntoCastillo.position.x, jugador.position.y);

        jugador.position = Vector2.MoveTowards(
            posicionActual,
            posicionDestino,
            velocidadCaminar * Time.deltaTime
        );

        if (Vector2.Distance(posicionActual, posicionDestino) < 0.05f)
        {
            jugadorEnMovimiento = false;
            CambiarEscenaCastillo();
        }
    }

    public void CambiarEscenaCastillo()
    {
        SceneManager.LoadScene(nombreEscenaCastillo);
    }
}