using UnityEngine;
using System.Collections;

public class EventBTrigger : MonoBehaviour
{
	public GameObject[] activate;
	public GameObject[] deactivate;
	public float ambientIntensity;
	private BoxCollider boxCollider;
	[HideInInspector]
	public AudioManager audioManager;

	void Awake()
	{
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
		boxCollider = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter()
	{
		boxCollider.enabled = false;
		foreach (GameObject go in activate)
		{
			go.SetActive(true);
		}
		foreach (GameObject go in deactivate)
		{
			go.SetActive(false);
		}

		RenderSettings.ambientIntensity = ambientIntensity;

		audioManager.EventBTriggered ();

	}
}
