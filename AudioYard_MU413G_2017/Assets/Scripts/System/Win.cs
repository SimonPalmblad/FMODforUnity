using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	public float waitForSeconds = 2;
	[HideInInspector]
	public AudioManager audioManager;

	void Awake()
	{
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}

	IEnumerator Won()
	{
		audioManager.PlayerWon (waitForSeconds);
		yield return new WaitForSeconds (waitForSeconds);
		SceneManager.LoadScene ("3D");
	}

	void OnTriggerEnter(Collider other)
	{
		StartCoroutine (Won());
	}
}
