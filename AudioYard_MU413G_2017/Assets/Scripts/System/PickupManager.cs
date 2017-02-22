using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour
{
	[HideInInspector]
    public int numberOfPickups = 0;
    [HideInInspector]
	public GameObject[] pickups;
	private SpawnAI spawnAI;
	[HideInInspector]
	public AudioManager audioManager;

    void Awake()
    {
        spawnAI = FindObjectOfType<SpawnAI>();
		pickups = GameObject.FindGameObjectsWithTag("Pickups");
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
    }

	public void PickupHandling(Transform tempTrans, GameObject instance)
	{
		numberOfPickups++;
		spawnAI.Spawn(tempTrans);
		audioManager.PickupTaken (instance);
	}

	public void SentryKilled()
	{
		numberOfPickups++;
	}
}