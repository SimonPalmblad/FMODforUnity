using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour 
{
	public float initialVelocity = 10;
	public float lifeTime = 3;
	public bool onCollisionDestroy = false;
	
	void Awake()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * initialVelocity;
		
		Destroy(gameObject, lifeTime);
	}

	
	void OnCollisionEnter(Collision collision)
	{
			
		collision.collider.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
		
		if(onCollisionDestroy)
		{
			Destroy(gameObject);
		}
	}
}
