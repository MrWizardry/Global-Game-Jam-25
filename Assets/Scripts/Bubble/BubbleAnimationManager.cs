using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAnimationManager : MonoBehaviour
{
    [SerializeField] private BubbleLife lifeTracker;
    [SerializeField] private GameObject explosion_VFX;

    private void CanTakeDamage()
    {
        lifeTracker.CanTakeDamageNow();
    }
    private void VFX_Explosion()
    {
        Instantiate(explosion_VFX, transform.position, Quaternion.identity);
    }
}
