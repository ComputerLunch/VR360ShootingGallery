using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VRStandardAssets.Utils;


// This is a simple class used in the maze scene
// that determines when the character can be given
// new target destinations.
public class InteractiveNavItem : MonoBehaviour
{

	[SerializeField] private Reticle m_Reticle;                     // This is used to reference the position and use it as the destination.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;   // The VRInteractiveItem on the maze, used to detect double clicks on the maze.

	NavPlayer navPlayer;

	void Awake(){

		// Get the camera and the reticle
		GameObject camGo = GameObject.FindGameObjectWithTag("MainCamera");
		if(camGo){
			m_Reticle = camGo.GetComponent<Reticle>();
		}


		m_InteractiveItem =  GetComponent<VRInteractiveItem>();

		// Get the nav player
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		if(go){
			navPlayer = go.GetComponent<NavPlayer>();

		}else{
			Debug.Log("You are missing an object tag as Player");
		}
	}

	private void OnEnable()
	{
		m_InteractiveItem.OnClick += HandleDoubleClick;
	}


	private void OnDisable()
	{
		m_InteractiveItem.OnClick -= HandleDoubleClick;
	}


	private void HandleDoubleClick()
	{
		// Set players new target
		Debug.Log("goto new goal");
		navPlayer.SetTarget( m_Reticle.ReticleTransform);
	}
}
