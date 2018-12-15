using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Explorerscript : MonoBehaviour {

	
	public static string a="";
   
    public int nay;
	

	// Use this for initialization
	void Start () {

	   
	}
	
    public void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			SceneManager.LoadScene("Front Page"); 
		
     
    }
	// Update is called once per frame
	public void onButtonpress (Image btn) {

		a = btn.name;
        nay = Convert.ToInt32(a);
        PlayerPrefs.SetInt("Intvalue", nay);

        SceneManager.LoadScene("ARDisplay");

       
        
    }

	

	

}
