using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleEffect : MonoBehaviour
{
    public GameObject dustParticlePrefab; // Reference to the dust particle prefab

    private ParticleSystem dustParticleSystem;

    private void Start()
    {
        // Instantiate the particle system
        dustParticleSystem = Instantiate(dustParticlePrefab, gameObject.transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();
        dustParticleSystem.Stop(); // Stop the particle system initially
    }

    public void Play()
    {
        if (dustParticleSystem != null)
        {
            dustParticleSystem.Play();
        }
    }

    public void Stop()
    {
        if (dustParticleSystem != null)
        {
            dustParticleSystem.Stop();
        }
    }
}