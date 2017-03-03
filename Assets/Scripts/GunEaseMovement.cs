using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using VRStandardAssets.Utils;

public class GunEaseMovement : MonoBehaviour {

	[SerializeField] private float m_Damping = 0.5f;    
	[SerializeField] private Transform m_CameraTransform; 
	[SerializeField] private VRInput m_VRInput;
	[SerializeField] private Transform m_GunContainer;  
	[SerializeField] private float m_GunContainerSmoothing = 10f;    
	[SerializeField] private Reticle m_Reticle; 

	private const float k_DampingCoef = -20f;                                       // This is the coefficient used to ensure smooth damping of this gameobject.


	// Use this for initialization
	void Start () {
		
	}
	
	private void Update()
	{
		// Smoothly interpolate this gameobject's rotation towards that of the user/camera.
		transform.rotation = Quaternion.Slerp(transform.rotation, InputTracking.GetLocalRotation(VRNode.Head),
			m_Damping * (1 - Mathf.Exp(k_DampingCoef * Time.deltaTime)));

		// Move this gameobject to the camera.
		transform.position = m_CameraTransform.position;

		// Find a rotation for the gun to be pointed at the reticle.
		Quaternion lookAtRotation = Quaternion.LookRotation (m_Reticle.ReticleTransform.position - m_GunContainer.position);

		// Smoothly interpolate the gun's rotation towards that rotation.
		m_GunContainer.rotation = Quaternion.Slerp (m_GunContainer.rotation, lookAtRotation,
			m_GunContainerSmoothing * Time.deltaTime);
	}
}
