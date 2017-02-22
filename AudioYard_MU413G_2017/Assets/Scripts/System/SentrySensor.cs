using UnityEngine;
using System.Collections;

public class SentrySensor : MonoBehaviour 
{
	public Sentry sentry;
	
	void OnTriggerEnter(Collider other)
	{
		sentry.SetTarget(other.transform);
	}
	
	void OnTriggerExit()
	{
		sentry.SetTarget(null);
	}
}
