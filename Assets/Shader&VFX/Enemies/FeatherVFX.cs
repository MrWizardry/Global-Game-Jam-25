using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FeatherVFX : MonoBehaviour
{
    public VisualEffect vfxFeather;

    // blah blah rest of code
    private void Start()
    {
        vfxFeather = GetComponent<VisualEffect>();
    }
    // Call this immediately before you destroy your missile
    public void DetachParticles()
    {
        // This splits the particle off so it doesn't get deleted with the parent
        vfxFeather.transform.parent = null;

        // this stops the particle from creating more bits
        vfxFeather.Stop();

        // This finds the particleAnimator associated with the emitter and then
        // sets it to automatically delete itself when it runs out of particles
        if(vfxFeather.aliveParticleCount == 0)
        {
            Destroy(vfxFeather);
        }
    }
}
