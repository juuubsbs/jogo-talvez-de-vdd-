using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrPasta : MonoBehaviour
{
    public float amplitude = 5f; // Amplitude do movimento
    public float frequency = 1f; // Frequência do movimento

    private float tempo;

    // Start is called before the first frame update
    void Start()
    {
        tempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        // Calcula a posição usando funções trigonométricas
        float x = amplitude * Mathf.Sin(frequency * tempo);
        float y = amplitude * Mathf.Sin(frequency * tempo) * Mathf.Cos(frequency * tempo);

        // Aplica a nova posição ao objeto
        transform.position = new Vector3(x, y, transform.position.z);
    }
}