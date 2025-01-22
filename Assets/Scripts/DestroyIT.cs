using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIT : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
