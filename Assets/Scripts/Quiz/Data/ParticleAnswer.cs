using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAnswer : MonoBehaviour
{
    Transform transformParticles;
    ParticleSystem particles;

    void Awake()
    {
        transformParticles = GetComponent<Transform>();
        particles = GetComponent<ParticleSystem>();
    }

    public void SpawnParticleAnswer(Vector3 targetPosition, float scaleParticle)
    {
        transformParticles.localScale = new Vector3(scaleParticle, scaleParticle, 1);
        transformParticles.position = targetPosition;
        particles.Play();
    }
}