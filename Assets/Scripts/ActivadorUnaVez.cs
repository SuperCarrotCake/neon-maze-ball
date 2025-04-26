using UnityEngine;

public class ActivadorUnaVez : MonoBehaviour
{
    public Collider triggerCollider;  // El Collider del objeto con el trigger (el área a detectar)
    public Collider playerCollider;   // El Collider del jugador

    private bool yaActivado = false;  // Para asegurarse que solo se active una vez

    void Update()
    {
        // Solo activamos si no ha sido activado antes
        if (!yaActivado)
        {
            // Verificamos si el jugador está completamente dentro del trigger
            if (triggerCollider.bounds.Contains(playerCollider.bounds.min) &&
                triggerCollider.bounds.Contains(playerCollider.bounds.max))
            {
                Activar();  // Activar la acción (lo que queramos que pase)
                yaActivado = true;  // Aseguramos que solo se ejecute una vez
            }
        }
    }

    // La acción que se activa cuando el jugador entra completamente
    void Activar()
    {
        Debug.Log("✅ El jugador entró completamente. Activando solo una vez...");
        // Aquí podés poner la acción que quieres: abrir puerta, sumar puntos, etc.
    }
}
