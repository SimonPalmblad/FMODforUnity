using UnityEngine;
using System.Collections;

public class AudioPlayerActions : MonoBehaviour
{
	public bool showFootstepDebugMessages = false;

	public void PlayFootstep(int material)
	{
		if (!showFootstepDebugMessages)
		{
			return;
		}
		else
		{
			Debug.Log ("PlayerFootstep - Material: " + material);
		}
	}

	public void PlayLand (int material)
	{
		Debug.Log ("PlayerLanded - Material: " + material);
	}

	public void PlayJump (int material)
	{
		Debug.Log ("PlayerJumped - Material: " + material);
	}

	public void PlaySpawn()
	{
		Debug.Log ("PlayerSpawned");
	}

	public void PlayShoot()
	{
		Debug.Log ("PlayerShoot");
	}

	public void PlayerDied()
	{
		Debug.Log ("PlayerDied");
	}

	public void PlayerWon(float waitTime)
	{
		Debug.Log ("PlayerWon - Waiting " + waitTime + " seconds");
	}
}

