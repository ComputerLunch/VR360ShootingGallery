using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;
using System;

namespace VRStandardAssets.Menu
{
	public class MenuSlider : MonoBehaviour {

		public event Action<MenuSlider> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

		[SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
		[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
		[SerializeField] private SelectionSlider m_SelectionRadial;         // This controls when the selection is complete.
		[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


		private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


		private void OnEnable ()
		{
			
			m_SelectionRadial.OnBarFilled += HandleSelectionComplete;
		}


		private void OnDisable ()
		{
			
			m_SelectionRadial.OnBarFilled -= HandleSelectionComplete;
		}



		private void HandleSelectionComplete()
		{
			// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
			if(m_GazeOver)
				StartCoroutine (ActivateButton());
		}


		private IEnumerator ActivateButton()
		{
			// If the camera is already fading, ignore.
			if (m_CameraFade.IsFading)
				yield break;

			// If anything is subscribed to the OnButtonSelected event, call it.
			//if (OnButtonSelected != null)
			//	OnButtonSelected(this);

			// Wait for the camera to fade out.
			yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

			// Load the level.
			SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
		}
	}
}
