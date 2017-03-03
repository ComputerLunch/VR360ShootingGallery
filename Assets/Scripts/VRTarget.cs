using UnityEngine;
using VRStandardAssets.Utils;
using VRStandardAssets.Common;

namespace VRStandardAssets.Examples
{
	// This script is a simple example of how an interactive item can
	// be used to change things on gameobjects by handling events.
	public class VRTarget : MonoBehaviour
	{
		[SerializeField] private Material m_NormalMaterial;                
		[SerializeField] private Material m_OverMaterial;                  
		[SerializeField] private Material m_ClickedMaterial;               
		[SerializeField] private Material m_DoubleClickedMaterial;         
		[SerializeField] private VRInteractiveItem m_InteractiveItem;
		[SerializeField] private Renderer m_Renderer;

		private AudioSource m_audio;


		private void Awake ()
		{
			m_audio = GetComponent<AudioSource>();
			
			m_Renderer.material = m_NormalMaterial;
		}


		private void OnEnable()
		{
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
			m_InteractiveItem.OnDown += HandleClick;
			m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
		}


		private void OnDisable()
		{
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
			m_InteractiveItem.OnDown -= HandleClick;
			m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
		}


		//Handle the Over event
		private void HandleOver()
		{
			Debug.Log("Show over state");
			m_Renderer.material = m_OverMaterial;
		}


		//Handle the Out event
		private void HandleOut()
		{
			Debug.Log("Show out state");
			m_Renderer.material = m_NormalMaterial;
		}


		//Handle the Click event
		private void HandleClick()
		{
			Debug.Log("Show click state");
			m_Renderer.material = m_ClickedMaterial;
		
			// Remove object
			Destroy(gameObject);  // Remove form world

			// give the player a score
			SessionData.AddScore(1);


			Vector3 pos = transform.position;

			// Set Particle effect
			GameObject blast = Instantiate( Resources.Load("ParticleBurst"),pos, Quaternion.identity) as GameObject;


			AudioController.getSingleton().PlaySFX3D("sound/ShooterTargetHit", gameObject.transform, 1.0f);
		}


		//Handle the DoubleClick event
		private void HandleDoubleClick()
		{
			Debug.Log("Show double click");
			m_Renderer.material = m_DoubleClickedMaterial;
		}
	}

}