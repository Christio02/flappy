using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float minY = -4f; // The minimum y position of the cloud particles
    private float maxY = 3f; // The maximum y position of the cloud particles

    void Start()
    {
    // Get the ParticleSystem component attached to the cloud object
    ParticleSystem particle = GetComponent<ParticleSystem>();
    // Create an array to store the particles in the ParticleSystem
    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particle.particleCount];
    // Get the particles from the ParticleSystem and store them in the array
    int numParticles = particle.GetParticles(particles);

    // Loop through each particle in the array
    for (int i = 0; i < numParticles; i++) {
        // Get the current position of the particle
        Vector3 newPosition = particles[i].position;
        // Set the y position of the particle to a random value between minY and maxY
        newPosition.y = Random.Range(minY, maxY);
        // Update the position of the particle
        particles[i].position = newPosition;
    }
    
    particle.SetParticles(particles, numParticles);
    }

 
    // void Update()
    // {
    //     // Get the ParticleSystem component attached to the cloud object
    //     ParticleSystem particle = GetComponent<ParticleSystem>();
    //     // Create an array to store the particles in the ParticleSystem
    //     ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particle.particleCount];
    //     // Get the particles from the ParticleSystem and store them in the array
    //     int numParticles = particle.GetParticles(particles);

    //     // Loop through each particle in the array
    //     for (int i = 0; i < numParticles; i++) {
    //         // Get the current position of the particle
    //         Vector3 newPosition = particles[i].position;
    //         // Set the y position of the particle to a random value between minY and maxY
    //         newPosition.y = Random.Range(minY, maxY);
    //         // Update the position of the particle
    //         particles[i].position = newPosition;
            
    //     }
    //     particle.SetParticles(particles, numParticles);
    // }


    
}
