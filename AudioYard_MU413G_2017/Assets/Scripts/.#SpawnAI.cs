using UnityEngine;
using System.Collections;

public class SpawnAI : MonoBehaviour
{
	public Object runner;
	//private Transform playerCamera;
	public bool spawnOnAwake = false;

	void Awake()
	{
		//playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
		if (runner == null)
		{
			return;
		}
	}

	public void Spawn(Transform spawnTrans)
	{
		Instantiate(runner, spawnTrans.position, spawnTrans.rotation);
	}



}
