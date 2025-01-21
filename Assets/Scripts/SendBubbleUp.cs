using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendBubbleUp : MonoBehaviour
{
    public GameObject bubble; // Referência para a bolha a ser lançada.
    public Slider powerBar;   // Barra de força para o lançamento.
    public float maxPower = 20f; // Força máxima do lançamento.
    public float minSpeed = 2f; // Velocidade mínima de oscilação.
    public float maxSpeed = 10f; // Velocidade máxima de oscilação.

    private float currentPower = 0f;
    private bool isIncreasing = true; // Define a direção da barra (subindo ou descendo).

    void Update()
    {
        // Atualiza a barra automaticamente.
        UpdatePowerBar();

        // Lança a bolha ao soltar o botão.
        if (Input.GetMouseButtonDown(0))
        {
            LaunchBubble();
            ResetPower();
        }
    }

    void UpdatePowerBar()
    {
        // Calcula a velocidade com base na posição atual da barra.
        float t = currentPower / maxPower; // Normaliza o valor (0 a 1).
        float speed = Mathf.Lerp(minSpeed, maxSpeed, t);

        // Atualiza a força com base na direção.
        if (isIncreasing)
        {
            currentPower += speed * Time.deltaTime;
            if (currentPower >= maxPower)
            {
                currentPower = maxPower;
                isIncreasing = false; // Inverte a direção.
            }
        }
        else
        {
            currentPower -= speed * Time.deltaTime;
            if (currentPower <= 0)
            {
                currentPower = 0;
                isIncreasing = true; // Inverte a direção.
            }
        }

        // Atualiza o valor visual da barra.
        if (powerBar != null)
        {
            powerBar.value = currentPower / maxPower;
        }
    }

    void LaunchBubble()
    {
        if (bubble != null)
        {
            Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * currentPower;
            }
        }
    }

    void ResetPower()
    {
        currentPower = 0f;
        isIncreasing = true;
        if (powerBar != null)
        {
            powerBar.value = 0f;
        }
    }
}
