using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnigiriControl : MonoBehaviour
{
    public float power = 1f;
    public Transform cameraTransform;
    private Vector3 initialPos;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isReadyToThrow=false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = getInitialPos();
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    void Flick()
    {
        RaycastHit hit;
        Ray ray = cameraTransform.gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 8;
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                startPos = Input.mousePosition;
                isReadyToThrow = true;
            }
        }
        if (isReadyToThrow) {
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                isReadyToThrow = false;
                endPos = Input.mousePosition;

                // Throw
                Vector3 dir = endPos - startPos;
                this.GetComponent<Rigidbody>().useGravity = true;
                
                this.GetComponent<Rigidbody>().AddForce(power * new Vector3(dir.x, dir.magnitude, dir.y));
                this.GetComponent<Rigidbody>().AddTorque(new Vector3(dir.y, dir.x, 0));
            }
        }
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Person") {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            yield return new WaitForSeconds(3);
            Application.OpenURL("http://localhost:8081/top/missionComplete?userId=3"); 
            Destroy(this.gameObject);
        }else if (collision.gameObject.name == "Floor") {
            yield return new WaitForSeconds(3);
            Destroy(this.gameObject);

            // Instantiate new onigiri
            GameObject newOnigiri = Instantiate(this.gameObject, initialPos, Quaternion.Euler(180, 0, 90));
            newOnigiri.GetComponent<Rigidbody>().useGravity=false;
            newOnigiri.GetComponent<OnigiriControl>().enabled = true;
            cameraTransform.gameObject.GetComponent<CameraControl>().onigiri = newOnigiri;
        }
    }

    Vector3 getInitialPos()
    {
        return cameraTransform.position + 2 * cameraTransform.forward + Vector3.down;
    }
}
