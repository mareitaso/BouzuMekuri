using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class Particle : MonoBehaviour
{
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();

        particle.Stop();
    }

    void part()
    {
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            part();
        }
    }
}
