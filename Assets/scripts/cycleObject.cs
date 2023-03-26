using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        GameObject newObject= null;
        if(Input.GetKeyDown(KeyCode.E)){
            
            if(isCave){  
                newObject = Instantiate(caveObject, transform.position,Quaternion.Euler(0, 0, 15 ));
            }
            else if(isOcean){
                // isOcean = false;
                // isForest = true;
                Debug.Log("OCEAN!!!! WOOOO;");
                newObject = Instantiate(oceanObject, transform.position, transform.rotation);
            }
            else if(isForest){
                // isForest = false;
                // isSpace = true;
                newObject = Instantiate(forestObject, transform.position, transform.rotation);
            }
            else if(isSpace){
                // isSpace = false;
                // isCave=true;
                newObject = Instantiate(spaceObject, transform.position, transform.rotation);
            }
            Destroy(gameObject);
            Debug.Log("rock " + isCave);
            Debug.Log("ocean " +isOcean);
            Debug.Log("forest " + isForest);
            Debug.Log("space " + isSpace);

            //cycleTypeForward();
        }
        else if(Input.GetKeyDown(KeyCode.Q)){

            if(isCave){
                newObject =  Instantiate(caveObject, transform.position,Quaternion.Euler(0, 0, 15 ));
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
            //cycleTypeBackward();
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(type != 't' && other.CompareTag("enemy")) {
            SceneManager.LoadScene ("scene1");
            Debug.Log(type);
        }
    }

    // public void cycleTypeForward(){
    //     if(isCave){
    //         isCave = false;
    //         isOcean = true;
    //     }
    //     else if(isOcean){
    //         isOcean = false;
    //         isForest = true;
    //     }
    //     else if(isForest){
    //         isForest = false;
    //         isSpace = true;
    //     }
    //     else if(isSpace){
    //         isSpace = false;
    //         isCave = true;
    //     }
    // }

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
