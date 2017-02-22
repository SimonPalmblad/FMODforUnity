using UnityEngine;
using System.Collections;

public class AudioMovingNPC : MonoBehaviour
{
	private AudioManager audioManager;

	void Awake()
	{
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
		audioManager.audioMovingNPC = this;
	}

	public void MovingNPCSpawned()
	{
		Debug.Log ("MovingNPCSpawned");
	}

	public void MovingNPCHit(int hitpoints)
	{
		Debug.Log("MovingNPCHit - HitpointsRemaining: " + hitpoints);
	}

	public void MovingNPCKilledplayer()
	{
		Debug.Log("MovingNPCKilledplayer");
	}

	public void MovingNPCDied()
	{
		Debug.Log("MovingNPCDied");
	}

}
