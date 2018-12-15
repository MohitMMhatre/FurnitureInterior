using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontPage : MonoBehaviour {




    public void explorer() {

        SceneManager.LoadScene("Explore");

    }
    public void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) 
        Application.Quit();
		
     
    }
       
    public void exit()
    {

        Application.Quit();
        Debug.Log("Over");    
    }

    //public void imagepress()
    //{
    //    if (gameObject.CompareTag("Sofa")) { 
    //            Debug.Log("hey u just clicked ");
    //    }
    //    else
    //    {
    //        Debug.Log("Nevermind");
    //    }
    //}

}
