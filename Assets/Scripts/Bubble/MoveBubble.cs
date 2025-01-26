using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBubble : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SpriteRenderer bgImage; // Referência ao SpriteRenderer do fundo

    private Transform draggingBubble = null;
    private Vector3 offset;
    private Camera mainCam;
    private Vector2 backgroundSize;
    private Vector3 objectBound;
    [Range(2, 17)]
    public int boxLimiter;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        mainCam = Camera.main;

        // Obtém o tamanho do fundo baseado no SpriteRenderer
        if (bgImage != null)
        {
            backgroundSize = bgImage.bounds.size / 2f; // Metade do tamanho do fundo para os limites
        }
        else
        {
            Debug.LogError("bgImage não está atribuído. Atribua o SpriteRenderer do fundo.");
        }
    }

    void Update()
    {
        if (gameManager.GetStageStarted() == false)
        {
            Debug.Log(gameManager.GetStageStarted());
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject.tag == "Player")
                {
                    draggingBubble = hit.transform;
                    offset = draggingBubble.position - mainCam.ScreenToWorldPoint(Input.mousePosition);
                    offset.z = 0;

                    var bounds = draggingBubble.GetComponent<Collider2D>().bounds;
                    objectBound = bounds.extents;
                }
            }

            if (draggingBubble != null && Input.GetMouseButtonUp(0))
            {
                draggingBubble = null;
            }

            if (draggingBubble)
            {
                Vector3 mousePostion = mainCam.ScreenToWorldPoint(Input.mousePosition);
                mousePostion.z = 0;
                Vector3 targetPosition = mousePostion + offset;

                // Define os limites com base no tamanho do fundo
                targetPosition.x = Mathf.Clamp(targetPosition.x, -backgroundSize.x + objectBound.x, backgroundSize.x - objectBound.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, -backgroundSize.y + objectBound.y, backgroundSize.y - objectBound.y - boxLimiter);

                draggingBubble.position = targetPosition;
            }
        }
    }

    public void SetBubbleArea(int value)
    {
        boxLimiter = value;
    }
}