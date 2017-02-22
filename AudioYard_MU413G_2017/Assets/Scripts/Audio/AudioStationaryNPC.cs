using UnityEngine;
using System.Collections;

public class AudioStationaryNPC : MonoBehaviour
{
	public void AudioStationaryNPCActivate()
	{
		Debug.Log ("StationaryNPCActivated");
	}

	public void AudioStationaryNPCDeactivate()
	{
		Debug.Log ("StationaryNPCDeactivated");
	}

	public void AudioStationaryNPCShoot()
	{
		Debug.Log ("StationaryNPCShoot");
	}

	public void AudioStationaryNPCRotationStart()
	{
		Debug.Log ("StationaryNPCRotationStarted");
	}

	public void AudioStationaryNPCRotationStop()
	{
		Debug.Log ("StationaryNPCRotationStopped");
	}

	public void AudioStationaryNPCDie()
	{
		Debug.Log("StationaryNPCDied");
	}
}
