using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public Transform jugador;
    public float suavizado = 5f;

    [Header("Opcional")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    void Start()
    {
        BuscarJugador();
    }

    void LateUpdate()
    {
        if (jugador == null)
        {
            BuscarJugador();
            return;
        }

        Vector3 posicionDeseada = new Vector3(
            jugador.position.x + offset.x,
            jugador.position.y + offset.y,
            offset.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            suavizado * Time.deltaTime
        );
    }

    void BuscarJugador()
    {
        GameObject jugadorEncontrado = GameObject.FindGameObjectWithTag("Player");

        if (jugadorEncontrado != null)
        {
            jugador = jugadorEncontrado.transform;
        }
    }
}