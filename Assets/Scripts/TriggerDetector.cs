using UnityEngine;

public class ColisionSolida : MonoBehaviour
{
    public string targetTag = "MiObjetoDetectable";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("¡Colisión física detectada con objeto sólido!");
            // Aquí podés hacer lo que quieras cuando lo toque
        }
    }
}
