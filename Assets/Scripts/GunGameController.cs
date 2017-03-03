using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Common;

public class GunGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Save data info
		SessionData.SetGameType(SessionData.GameType.GUN_GALLERY);

		InvokeRepeating("SpawnTarget",0,0.6f);
	}



	void SpawnTarget(){

		Vector3 pos = new Vector3( Random.Range(-10,10) , Random.Range(0,5), Random.Range(-10,10));

		GameObject clone = Instantiate( Resources.Load("Target"),pos, Quaternion.identity) as GameObject;


			
	}
}
