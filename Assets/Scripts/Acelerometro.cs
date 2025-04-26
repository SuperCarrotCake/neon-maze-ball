using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Acelerometro : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 tilt = Input.acceleration;
        // Dibuja la dirección de 'tilt' (en rojo)
        Debug.DrawRay(transform.position, tilt, Color.red);

        // Muestra en consola la fuerza antes de multiplicar
        // Debug.Log("Fuerza antes: " + tilt);

        // Ahora rotamos el tilt y luego multiplicamos
        tilt = Quaternion.Euler(90, 0, 0) * tilt;

        tilt.y = 0f;
        Vector3 force = tilt * speed;

        // Dibuja la dirección de 'force' (en azul)
        Debug.DrawRay(transform.position, force, Color.blue);

        // Muestra en consola la fuerza después de multiplicar
        // Debug.Log("Fuerza después: " + force);

        // Finalmente aplicamos la fuerza
        rb.AddForce(force);
    }
}
