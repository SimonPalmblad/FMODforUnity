using UnityEngine;
using System.Collections;

public class MaterialManager : MonoBehaviour
{
	public int materialEnter;
	public int materialExit;
	private AudioManager audioManager;

	void Awake()
	{
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}

	void OnTriggerEnter()
	{
		audioManager.material = materialEnter;
	}

	void OnTriggerExit()
	{
		audioManager.material = materialExit;
	}
		
}
