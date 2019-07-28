using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonControl : MonoBehaviour
{
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponentInChildren<ParticleSystem>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Onigiri") {
            particle.Play();
        }
    }
}
