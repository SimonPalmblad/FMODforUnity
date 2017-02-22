using UnityEngine;
using System.Collections;

public class Sentry : MonoBehaviour 
{
	public Transform rotationControl;
	public float rotationTime = 1;
	public float rotationMaxSpeed = 1;
	
	public GameObject sentryBulletPrefab;
	public float fireRate = 0.5f;
	public Transform muzzleTransform;

	public float rotationThreshold = 5;
	
	private Transform target;
	private Transform ownTransform;
	private Vector3 standardEuler = Vector3.zero;
	private float rotationRefVelocity = 0;
	private bool rotating = false;
	[HideInInspector]
	public AudioManager audioManager;

	void Awake()
	{
		ownTransform = transform;
		standardEuler = rotationControl.eulerAngles;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}
	
	void LateUpdate()
	{
		if(target == null)
			return;
		Quaternion dummyRotation = Quaternion.LookRotation(target.position - ownTransform.position, Vector3.up);
		rotationControl.eulerAngles = new Vector3(standardEuler.x, Mathf.SmoothDampAngle(rotationControl.eulerAngles.y, dummyRotation.eulerAngles.y, ref rotationRefVelocity, rotationTime, rotationMaxSpeed), standardEuler.z);
		if (Mathf.Abs (rotationRefVelocity) > rotationThreshold)
		{
			if (rotating == false)
			{
				audioManager.StationaryNPCRotationStarted ();
				rotating = true;
			}
		}
		else
		{
			if (rotating)
			{
				audioManager.StationaryNPCRotationStopped ();
				rotating = false;
			}
		}
	}
	
	public void SetTarget(Transform targetTransform)
	{
		target = targetTransform;
		if(target != null)
		{
			StartCoroutine(FireRoutine());
			audioManager.StationaryNPCActivated (gameObject);
		}
		else
		{
			audioManager.StationaryNPCRotationStopped ();
			rotating = false;
			StopAllCoroutines();
			audioManager.StationaryNPCDeactivated ();
		}
	}
	
	IEnumerator FireRoutine()
	{
		yield return new WaitForSeconds(fireRate);
		GameObject.Instantiate(sentryBulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
		audioManager.StationaryNPCShoot ();
		StartCoroutine(FireRoutine());
	}
	
	public void OnHit()
	{
		audioManager.StationaryNPCDied ();
		Destroy(gameObject);
	}
}
