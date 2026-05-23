using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaTrigger : MonoBehaviour
{
    [Header("Escena a cargar")]
    public string nombreEscena;

    [Header("Spawn donde aparecerá el jugador")]
    public string nombreSpawnDestino;

    [Header("Opcional: tecla necesaria")]
    public bool requiereTecla = false;
    public KeyCode tecla = KeyCode.S;

    private bool jugadorDentro = false;

    private void Update()
    {
        if (requiereTecla && jugadorDentro && Input.GetKeyDown(tecla))
        {
            CambiarEscena();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        jugadorDentro = true;

        if (!requiereTecla)
        {
            CambiarEscena();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        jugadorDentro = false;
    }

    private void CambiarEscena()
    {
        PlayerPrefs.SetString("SpawnDestino", nombreSpawnDestino);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nombreEscena);
    }
}