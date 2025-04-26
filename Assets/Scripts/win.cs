using UnityEngine;

public class DetectorInterno : MonoBehaviour
{
    private bool playerDentro = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDentro = true;
            Debug.Log("El jugador ENTRÓ completamente.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDentro = false;
            Debug.Log("El jugador SALIÓ completamente.");
        }
    }

    void Update()
    {
        if (playerDentro)
        {
            // Aquí podés hacer cosas mientras esté completamente dentro
            // Debug.Log("Jugador está DENTRO en este frame");
        }
    }
}
