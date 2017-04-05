using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VRStandardAssets.Utils;
using VRStandardAssets.Maze;

public class NavPlayer : MonoBehaviour {

	public Vector3 goal;
	NavMeshAgent agent;

	public ThirdPersonCharacter character;

	// Use this for initialization
	void Start () {

		agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

		//character.Move(agent.desiredVelocity, false, false);


		agent.destination = goal;
	}
		
	public void SetTarget( Transform newGoal){
		goal = newGoal.position;
	}
}
