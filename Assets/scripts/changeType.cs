using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeType : MonoBehaviour
{
    public Sprite caveSprite;
    public Sprite oceanSprite;
    public Sprite forestSprite;
    public Sprite spaceSprite;
    public bool isCave;
    public bool isOcean;
    public bool isForest;
    public bool isSpace;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        isCave = true;
        isSpace = false;
        isOcean = false;
        isForest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            if(isCave){
                sr.sprite = caveSprite;
                cycleTypeForward();
            }
            else if(isOcean){
                sr.sprite = oceanSprite;
                cycleTypeForward();
            }
            else if(isForest){
                sr.sprite = forestSprite;
                cycleTypeForward();
            }
            else if(isSpace){
                sr.sprite =  spaceSprite;
                cycleTypeForward();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            if(isCave){
                sr.sprite = caveSprite;
                cycleTypeBackward();
            }
            else if(isOcean){
                sr.sprite = oceanSprite;
                cycleTypeBackward();
            }
            else if(isForest){
                sr.sprite = forestSprite;
                cycleTypeBackward();
            }
            else if(isSpace){
                sr.sprite =  spaceSprite;
                cycleTypeBackward();
            }
        }
    }

    // public void setupCave(){
    //     sr.sprite = caveSprite;
    //     cycleType();
    // }

    // public void setupOcean(){
    //     sr.sprite = oceanSprite;
    //     cycleType();
    // }

    // public void setupForest(){
    //     sr.sprite = forestSprite;
    //     cycleType();
    // }

    // public void setupSpace(){
    //     sr.sprite = spaceSprite;
    //     cycleType();
    // }

    public void cycleTypeForward(){
        if(isCave){
            isCave = false;
            isOcean = true;
        }
        else if(isOcean){
            isOcean = false;
            isForest = true;
        }
        else if(isForest){
            isForest = false;
            isSpace = true;
        }
        else if(isSpace){
            isSpace = false;
            isCave = true;
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