using UnityEngine;
using System.Collections;

[System.Serializable]
public class MovingCubeOrder
{
	public Vector3 movement = Vector3.zero;
	public float moveTime = 1;
	public bool playAudio = false;
}

public class MovingCube : MonoBehaviour
{
	public MovingCubeOrder[] orders;
	
	private Transform ownTransform;
	private AudioSource ownAudio;

	
	void Awake()
	{

		ownTransform = transform;
		ownAudio = GetComponent<AudioSource>();
		StartCoroutine(MoveRoutine(0));
	}


	IEnumerator MoveRoutine(int orderIndex)
	{
		float lerpValue = 0;
		Vector3 startPosition = ownTransform.position;
		if (ownAudio != null)
		{
			if (orders [orderIndex].playAudio) 
			{
				if (!ownAudio.isPlaying)
					ownAudio.Play ();
			} 
			else
				ownAudio.Stop ();
		}
		
		while(lerpValue < 1)
		{
			lerpValue += Time.deltaTime / orders[orderIndex].moveTime;
			ownTransform.position = Vector3.Lerp(startPosition, startPosition + orders[orderIndex].movement, lerpValue);
			yield return null;
		}
		
		ownTransform.position = startPosition + orders[orderIndex].movement;
		if(orderIndex < orders.Length -1)
			StartCoroutine(MoveRoutine(orderIndex + 1));
		else
			StartCoroutine(MoveRoutine(0));
	}
}