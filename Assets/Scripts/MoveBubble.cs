using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBubble : MonoBehaviour
{
    private Transform draggingBubble = null;
    private Vector3 offset;
    private Camera mainCam;
    private Vector2 screenBound;
    private Vector3 objectBound;
    [Range(2,50)]
    [SerializeField]private int boxLimiter;

    void Start()
    {
        mainCam = Camera.main;
        screenBound = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clique");
            RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                draggingBubble = hit.transform;
                offset = draggingBubble.position - mainCam.ScreenToWorldPoint(Input.mousePosition);
                offset.z = 0;

                var bounds = draggingBubble.GetComponent<Collider2D>().bounds;
                objectBound = bounds.extents;
            }
        } 

        if(draggingBubble != null && Input.GetMouseButtonUp(0))
        {
            draggingBubble = null;
        }

        if(draggingBubble)
        {
            Vector3 mousePostion = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePostion.z = 0;
            Vector3 targetPosition = mousePostion + offset; 

            targetPosition.x = Mathf.Clamp(targetPosition.x, -screenBound.x + objectBound.x, screenBound.x - objectBound.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -screenBound.y + objectBound.y, (screenBound.y - objectBound.y - boxLimiter));

            draggingBubble.position = targetPosition;
        }
    }    
}