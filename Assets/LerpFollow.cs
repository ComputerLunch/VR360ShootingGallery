using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollow : MonoBehaviour {

	public Transform target;
	public float lerpRate = 0.01f; // 0.01f Lower is slower

	Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - target.position;
	}

	void Update()
	{
		if (target)
		{
			transform.position = Vector3.Lerp (transform.position, target.position + offset, lerpRate);
		}
	}

}
