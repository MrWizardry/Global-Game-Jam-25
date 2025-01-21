using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed =   2f;

    void Update()
    {
        transform.Translate(Vector3.down *  speed *  Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Deleter")
        {
            Destroy(this.gameObject);
        }
    }
}
