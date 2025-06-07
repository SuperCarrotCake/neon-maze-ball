using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public RectTransform textRect; // el RectTransform del texto
    public float speed = 50f;      // velocidad de desplazamiento
    private float startX;
    private float resetPositionX;

    void Start()
    {
        startX = textRect.anchoredPosition.x;
        // Establecemos una posición de reinicio basada en el ancho del texto
        resetPositionX = -textRect.rect.width;
    }

    void Update()
    {
        // Mueve el texto a la izquierda continuamente
        textRect.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // Si el texto llega al final (sale por la izquierda), regresa a la posición inicial por la derecha
        if (textRect.anchoredPosition.x < resetPositionX)
        {
            textRect.anchoredPosition = new Vector2(startX, textRect.anchoredPosition.y);
        }
    }
}
