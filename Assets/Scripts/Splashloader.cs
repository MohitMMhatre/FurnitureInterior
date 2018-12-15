using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Splashloader : MonoBehaviour {


    public Image splashimage;
    public string loadlevel;

    IEnumerator Start()
    {
        splashimage.canvasRenderer.SetAlpha(0.0f);

        Fadein();
        yield return new WaitForSeconds(5.0f);
        fadeout();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadlevel);
    }
        
    void Fadein()
    {
        splashimage.CrossFadeAlpha(1.0f,2.0f,false);
    }

    void fadeout()
    {
        splashimage.CrossFadeAlpha(0.0f, 2.0f, false);
    }
	
}
