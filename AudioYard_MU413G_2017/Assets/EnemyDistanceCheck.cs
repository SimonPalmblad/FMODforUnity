using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceCheck : MonoBehaviour {
    //public GameObject Player;
    Vector3 MyVector;
    public GameObject player;
    Transform playerPos;
    float parameter;

    // Use this for initialization
	void Start ()

    {
        playerPos = player.GetComponent<Transform>();
        Debug.Log("Found rtansdform!!");
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(playerPos.position.normalized, transform.position.normalized);
        Debug.Log("You are:" + dist + "from enemy.");
    
    }

}
