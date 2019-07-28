using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
     public float speed = 3.5f;
     private float X;
     private float Y;
     public GameObject onigiri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if (!onigiri.GetComponent<OnigiriControl>().isReadyToThrow) {
        //     if(Input.GetMouseButton(0)) {
        //         transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
        //         X = transform.rotation.eulerAngles.x;
        //         Y = transform.rotation.eulerAngles.y;
        //         transform.rotation = Quaternion.Euler(X, Y, 0);
        //     }
        // }
    }
}
