using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float smoothing = 5f;

    private Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
            offset = transform.position - target.position;
        }
        else
        {
            Debug.LogError("Target Destroyed");
        }
    }
    private void FixedUpdate()
    {
       
        if (target == null) 
        {
            GameObject playerObject1 = GameObject.FindWithTag("Player");
            SetTarget(playerObject1.transform);
            return;
        }
        

        Vector3 targetCamPos = target.position +offset;
        targetCamPos.y = transform.position.y;

        transform.position = Vector3.Lerp(transform.position,targetCamPos,smoothing*Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        offset= transform.position - target.position;
    }
}
