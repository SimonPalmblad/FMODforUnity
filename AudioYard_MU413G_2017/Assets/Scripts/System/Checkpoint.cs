using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			other.gameObject.GetComponent<Player> ().Checkpoint (gameObject);
		}
	}
}
