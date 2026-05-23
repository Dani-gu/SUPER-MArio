using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasladoEscena : MonoBehaviour
{
    public string nombreEscena = "subterraneo";

    private bool jugadorDentro = false;

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }
}