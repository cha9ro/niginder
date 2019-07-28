using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public Transform cameraTransform;
    private float t=500;
    private float deltaT=100;
    private Vector3 dir;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t++;
        if (t%200 > deltaT) {
            x = Random.Range(-2f, 2f);
            y = Random.Range(-2f, 2f);
            t = 0;
            deltaT = Random.Range(50f, 100f);
        }
        dir = new Vector3(x, this.transform.position.y, y) - this.transform.position;
            
        this.transform.position += 0.05f * dir;
        this.transform.LookAt(cameraTransform);
    }

}
