using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
    }

    void FixedUpdate() {
        this.transform.position = new Vector3(camTransform.position.x,0,this.transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {



    }
}
