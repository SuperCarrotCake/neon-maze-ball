using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NeonFlicker : MonoBehaviour
{
    [Header("Rango de intensidad")]
    public float minEmission = 0.4f;
    public float maxEmission = 1.2f;

    [Header("Velocidad de cambio")]
    public float minInterval = 1.05f;
    public float maxInterval = 1.2f;

    private TextMeshProUGUI _text;
    private Material _mat;
    private float _targetIntensity;
    private float _timer;

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _mat = _text.fontMaterial;
        _timer = 0f;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            // Elegimos nueva intensidad y próximo intervalo
            _targetIntensity = Random.Range(minEmission, maxEmission);
            _timer = Random.Range(minInterval, maxInterval);
        }

        // Lerp suave hacia la intensidad objetivo
        float current = _mat.GetFloat(ShaderUtilities.ID_GlowPower);
        float next = Mathf.Lerp(current, _targetIntensity, Time.deltaTime * 10f);
        _mat.SetFloat(ShaderUtilities.ID_GlowPower, next);
    }
}
