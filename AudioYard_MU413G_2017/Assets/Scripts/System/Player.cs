using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
	[HideInInspector]
	public GameObject bulletPrefab;
	[HideInInspector]
	public Transform gunMuzzleTransform;
	private Vector3 playerPosition;
	private Quaternion playerRotation;
	public Transform startPosition;
	public Object bullet;
	private Transform bulletRef;
	[HideInInspector]
	public AudioManager audioManager;
	
	void Awake ()
	{
		bulletRef = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform>();
		transform.position = startPosition.position;
		transform.rotation = startPosition.rotation;
		playerPosition = transform.position;
		playerRotation = transform.rotation;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}

	void Start()
	{
		audioManager.PlayerSpawned ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			if(bullet != null)
			{
				Instantiate(bullet, bulletRef.transform.position, bulletRef.transform.rotation);
				audioManager.PlayerShoot ();
			}
		}
	}
	
	public void Death ()
	{
		transform.position = playerPosition;
		transform.rotation = playerRotation;
		audioManager.PlayerDied ();
	}
	

	public void Checkpoint (GameObject instance)
	{
		playerPosition = transform.position;
		playerRotation = transform.rotation;
		audioManager.CheckpointTaken (instance);
	}
	
	void OnHit()
	{
		Death();
	}
	

}
