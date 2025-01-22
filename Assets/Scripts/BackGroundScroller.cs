using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [Header("Background Settings")]
    public Transform background; // O objeto do background
    public float scrollDuration = 60f; // Tempo total para o background descer

    private float spriteHeight; // Altura do sprite do background
    private Vector2 startPosition; // Posição inicial do background
    private Vector2 endPosition; // Posição final do background
    private float elapsedTime = 0f; // Tempo decorrido

    void Start()
    {
        if (background == null)
        {
            Debug.LogError("O background não foi atribuído!");
            return;
        }

        // Calcula a altura do sprite
        SpriteRenderer spriteRenderer = background.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteHeight = spriteRenderer.bounds.size.y;
        }
        else
        {
            Debug.LogError("O objeto de background não possui um SpriteRenderer!");
            return;
        }

        float cameraTop = Camera.main.transform.position.y + Camera.main.orthographicSize;

        // Define as posições inicial e final
        startPosition = background.position;
        endPosition = new Vector2(startPosition.x, cameraTop - (spriteHeight/2));
    }

    void Update()
    {
        if (background != null && elapsedTime < scrollDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / scrollDuration);
            background.position = Vector2.Lerp(startPosition, endPosition, progress);
        }
    }
}
