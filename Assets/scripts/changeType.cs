using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public char type;
    public bool r;
    public bool a;
    public bool f;
    public bool t;
    public bool p;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        type = 'p';
        sr = GetComponent<SpriteRenderer>();
        gameObject.tag = "Player";
        isCave = true;
        isSpace = false;
        isOcean = false;
        isForest = false;
        r = false;
        a = false;
        t = false;
        f = false;
        p = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            if(isCave){
                this.type = 'r';
                r = true;
                a = false;
                t = false;
                f = false;
                p = false;
                //gameObject.tag = "rock";
                sr.sprite = caveSprite;
                cycleTypeForward();
            }
            else if(isOcean){
                this.type = 'f';
                f = true;
                r = false;
                a = false;
                t = false;
                p = false;
                //gameObject.tag = "fish";
                sr.sprite = oceanSprite;
                cycleTypeForward();
            }
            else if(isForest){
                this.type = 't';
                t = true;
                f =false;
                a = false;
                r = false;
                p = false;
                sr.sprite = forestSprite;
                //gameObject.tag = "tree";
                cycleTypeForward();
            }
            else if(isSpace){
                this.type = 'a';
                a = true;
                r = false;
                f = false;
                t = false;
                p = false;
                //gameObject.tag = "alien";
                sr.sprite =  spaceSprite;
                cycleTypeForward();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            if(isCave){
                this.type = 'r';
                r = true;
                a = false;
                t = false;
                f = false;
                p = false;
                sr.sprite = caveSprite;
                cycleTypeBackward();
            }
            else if(isOcean){
                this.type = 'f';
                f = true;
                r = false;
                a = false;
                t = false;
                p = false;
                sr.sprite = oceanSprite;
                cycleTypeBackward();
            }
            else if(isForest){
                this.type = 't';
                t = true;
                f =false;
                a = false;
                r = false;
                p = false;
                sr.sprite = forestSprite;
                //gameObject.tag = "tree";
                cycleTypeBackward();
            }
            else if(isSpace){
                this.type = 'a';
                a = true;
                r = false;
                f = false;
                t = false;
                p = false;
                sr.sprite = spaceSprite;
                //gameObject.tag = "alien";
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


    void OnTriggerEnter2D(Collider2D other) {
        if(type != 't' && other.CompareTag("enemy")) {
            SceneManager.LoadScene ("scene1");
            Debug.Log(type);
        }
        
    }

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