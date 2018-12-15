using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotosignn : MonoBehaviour {

	public GameObject login;
	public GameObject register;

	// Use this for initialization
	void Start () {
		login.SetActive(true);
		register.SetActive(false);
	}
	
	// Update is called once per frame
	public void whenckicked () {
		login.SetActive(false);
		register.SetActive(true);

	}
}
