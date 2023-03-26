using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class cycleObject : MonoBehaviour
{
    public GameObject caveObject;
    public GameObject oceanObject;
    public GameObject forestObject;
    public GameObject spaceObject;
    public bool isCave;
    public bool isOcean;
    public bool isForest;
    public bool isSpace;
    public Quaternion caveRotation;
    public char type;
    private IEnumerator coroutine;
    private DateTime underwaterStart;
    public float drownBuffer = 2.0f;
    public bool isInWater;
    public characterController controller;
    
    void Start()
    {
        controller = gameObject.GetComponent<characterController>();
        switch(type){
            case 't':
                isCave = false;
                isOcean = false;
                isForest = false;
                isSpace = true;
                break;
            case 'a':
                isCave = true;
                isOcean = false;
                isForest = false;
                isSpace = false;
                break;
            case 'f':
                isCave = false;
                isOcean = false;
                isForest = true;
                isSpace = false;
                break;
            case 'p':
                isCave = true;
                isOcean = false;
                isForest = false;
                isSpace = false;
                break;
            case 'r':
                isCave = false;
                isOcean = true;
                isForest = false;
                isSpace = false;
                break;
        }
        isInWater = false;
    }

    void Update()
    {
        DateTime currentTime = DateTime.Now;
        TimeSpan timeUnderwater = currentTime - underwaterStart;
        GameObject newObject = null;
        if(Input.GetKeyDown(KeyCode.E)){
            if(isCave){  
                newObject = Instantiate(caveObject, transform.position, Quaternion.Euler(0, 0, 15 ));
            }
            else if(isOcean){
                Debug.Log("OCEAN!!!! WOOOO;");
                newObject = Instantiate(oceanObject, transform.position, transform.rotation);
            }
            else if(isForest){
                newObject = Instantiate(forestObject, transform.position, transform.rotation);
            }
            else if(isSpace){
                newObject = Instantiate(spaceObject, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Debug.Log("rock " + isCave);
            Debug.Log("ocean " + isOcean);
            Debug.Log("forest " + isForest);
            Debug.Log("space " + isSpace);
        }
        else if(Input.GetKeyDown(KeyCode.Q)){
            if(isCave){
                newObject = Instantiate(caveObject, transform.position, Quaternion.Euler(0, 0, 15 ));
            }
            else if(isOcean){
                newObject = Instantiate(oceanObject, transform.position, transform.rotation);
            }
            else if(isForest){
                newObject = Instantiate(forestObject, transform.position, transform.rotation);
            }
            else if(isSpace){
                newObject = Instantiate(spaceObject, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        if((isInWater) && (type != 'f') && (drownBuffer <= timeUnderwater.TotalSeconds)){
            SceneManager.LoadScene ("scene1");
            Debug.Log(type);
        }
        if(isInWater && type == 'f'){
            controller.jumpForce = 200000f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(type != 't' && other.CompareTag("enemy")) {
            SceneManager.LoadScene ("scene1");
            Debug.Log(type);
        }
        if(other.CompareTag("water")){
            isInWater = true;
            if(type != 'f'){
                underwaterStart = DateTime.Now;
            }
        }
        if(other.CompareTag("end_flag")){
            SceneManager.LoadScene("scene4");
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("water")){
            isInWater = false;
        }
        if(type == 'f'){
            controller.jumpForce = 50f;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.GetComponent<BoxCollider2D>() != null && type == 'r') {
            Destroy(other.collider.gameObject);
        }
    }

    public void cycleTypeBackward(){
        if(isCave){
            isCave = false;
            isSpace = true;
        }
        else if(isOcean){
            isOcean = false;
            isCave = true;
        }
        else if(isForest){
            isForest = false;
            isOcean = true;
        }
        else if(isSpace){
            isSpace = false;
            isForest = true;
        }
    }
}
