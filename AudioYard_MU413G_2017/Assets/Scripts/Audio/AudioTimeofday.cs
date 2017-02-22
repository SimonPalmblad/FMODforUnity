using UnityEngine;
using System.Collections;

public class AudioTimeofday : MonoBehaviour
{
	public bool showDebugMessages = false;

	public void ExampleParameter(float timeofday)
	{
		if (!showDebugMessages)
		{
			return;
		}
		else
		{
			Debug.Log ("Time of day is: " + timeofday);
		}
	}
}
