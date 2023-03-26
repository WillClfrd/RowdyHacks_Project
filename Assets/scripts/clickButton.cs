using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown() {
        Debug.Log("Click");
        if(gameObject.CompareTag("start"))
        {
            SceneManager.LoadScene ("scene1"); 
        }
        else if(gameObject.CompareTag("control"))
        {
            SceneManager.LoadScene("scene3");
        }
        else if(gameObject.CompareTag("lore"))
        {
            SceneManager.LoadScene("scene4");
        }
        else if(gameObject.CompareTag("back"))
        {
            SceneManager.LoadScene("scene2");
        }

    }
}
