using UnityEngine;
using System.Collections;

public class SentryBarrel : MonoBehaviour 
{
	public Sentry sentry;

	void OnHit()
	{
		sentry.OnHit ();
	}
}
