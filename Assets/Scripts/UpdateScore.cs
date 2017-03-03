using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Common;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

	public Text textbox;

	// Use this for initialization
	void Start () {

	}

	void Update () {
		
		// Set score form sessiondata
		textbox.text =  SessionData.GetHighScore().ToString();
	}
}
