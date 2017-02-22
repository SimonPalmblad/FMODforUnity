using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	private AudioTimeofday audioTimeofday;
	private AudioPlayerActions audioPlayerActions;
	[HideInInspector]
	public AudioMovingNPC audioMovingNPC;
	private AudioCheckpoint audioCheckpoint;
	private AudioPickup audioPickup;
	private AudioEventATrigger audioEventATrigger;
	private AudioEventBTrigger audioEventBTrigger;
	[HideInInspector]
	public AudioStationaryNPC audioStationaryNPC;
	[HideInInspector]
	public int material;

	void Awake()
	{
		audioTimeofday = GameObject.FindObjectOfType<AudioTimeofday> ();
		audioPlayerActions = GameObject.FindObjectOfType<AudioPlayerActions> ();
		audioEventATrigger = GameObject.FindObjectOfType<AudioEventATrigger> ();
		audioEventBTrigger = GameObject.FindObjectOfType<AudioEventBTrigger> ();
		material = 1;
	}

	public void PlayerSpawned ()
	{
		audioPlayerActions.PlaySpawn ();
	}

	public void PlayerFootstep()
	{
		audioPlayerActions.PlayFootstep (material);
	}

	public void PlayerJump()
	{
		audioPlayerActions.PlayJump (material);
	}

	public void PlayerLand()
	{
		audioPlayerActions.PlayLand (material);
	}

	public void PlayerShoot ()
	{
		audioPlayerActions.PlayShoot ();
	}

	public void PlayerDied ()
	{
		audioPlayerActions.PlayerDied ();
	}

	public void CheckpointTaken (GameObject instance)
	{
		audioCheckpoint = instance.GetComponent<AudioCheckpoint> ();
		audioCheckpoint.AudioCheckpointTaken ();
	}

	public void PickupTaken (GameObject instance)
	{
		audioPickup = instance.GetComponent<AudioPickup> ();
		audioPickup.AudioPickupTaken ();
	}

	public void MovingNPCSpawned()
	{
		if(audioMovingNPC != null)
			audioMovingNPC.MovingNPCSpawned ();
	}

	public void MovingNPCHit(int hitpoints)
	{
		if(audioMovingNPC != null)
			audioMovingNPC.MovingNPCHit (hitpoints);
	}

	public void MovingNPCKilledplayer()
	{
		if(audioMovingNPC != null)
			audioMovingNPC.MovingNPCKilledplayer ();
	}

	public void MovingNPCDied()
	{
		if(audioMovingNPC != null)
			audioMovingNPC.MovingNPCDied();
	}

	public void StationaryNPCActivated(GameObject instance)
	{
		audioStationaryNPC = instance.GetComponent<AudioStationaryNPC> ();
		audioStationaryNPC.AudioStationaryNPCActivate ();
	}

	public void StationaryNPCDeactivated()
	{
		audioStationaryNPC.AudioStationaryNPCDeactivate();
	}

	public void StationaryNPCShoot()
	{
		audioStationaryNPC.AudioStationaryNPCShoot ();
	}

	public void StationaryNPCRotationStarted()
	{
		audioStationaryNPC.AudioStationaryNPCRotationStart ();
	}

	public void StationaryNPCRotationStopped()
	{
		audioStationaryNPC.AudioStationaryNPCRotationStop ();
	}

	public void StationaryNPCDied()
	{
		audioStationaryNPC.AudioStationaryNPCDie ();
	}

	public void EventATriggered()
	{
		audioEventATrigger.AudioEventATriggered ();
	}

	public void EventBTriggered()
	{
		audioEventBTrigger.AudioEventBTriggered ();
	}

	public void PlayerWon(float waitTime)
	{
		audioPlayerActions.PlayerWon (waitTime);
	}

	public void Timeofday(float timeofday)
	{
		audioTimeofday.ExampleParameter (timeofday);
	}
}