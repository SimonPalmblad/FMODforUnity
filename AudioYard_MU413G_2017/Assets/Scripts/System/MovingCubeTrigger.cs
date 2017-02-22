using UnityEngine;
using System.Collections;

public class MovingCubeTrigger : MonoBehaviour {

	private Transform player;

	void Awake () 
	{
		player = GameObject.FindObjectOfType<Player> ().GetComponent<Transform>();	
	}

	void OnTriggerEnter()
	{
		player.parent = transform.parent;
	}
	
	void OnTriggerExit()
	{
		player.parent = null;
	}

}

