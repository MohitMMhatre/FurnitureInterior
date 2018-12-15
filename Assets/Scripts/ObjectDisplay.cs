using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplay : MonoBehaviour {

	private Explorerscript Es;
    GameObject capture;

    public GameObject[]  furniture;
	public Transform spawnposition;
    // Use this for initialization


    public void Display () {


		GameObject asdobj = GameObject.FindGameObjectWithTag("GameController");
		if (asdobj != null)
		{
			Es = asdobj.GetComponent<Explorerscript>();
		}
		if (Es == null)
		{
			Debug.Log("Cannot find 'Explorer' script");
		}

		 int b = PlayerPrefs.GetInt("Intvalue",0);

		//Debug.Log("here "+b);
	    GameObject furni = furniture[b];
          Debug.Log("here");
        Instantiate(furni, spawnposition.position, spawnposition.rotation,spawnposition.parent);
        //  Debug.Log("there");
        PlayerPrefs.SetInt("HighScore",0);
        

	}

    public void OnScreenButton()
    {

        //GameObject capture = GameObject.FindGameObjectWithTag("Screencapture");

        string date = DateTime.Now.ToString("yyyyMMddTHHmmss");

        ScreenCapture.CaptureScreenshot(date + ".png");
    }

}
