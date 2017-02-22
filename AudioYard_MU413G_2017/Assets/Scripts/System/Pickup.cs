using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    private PickupManager pickupManager;
    private BoxCollider boxCollider;
	private MeshRenderer meshRenderer;
	public Transform refTrans;
	private bool rotationActive = true;

    void Awake()
    {
        pickupManager = FindObjectOfType<PickupManager>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
		meshRenderer = gameObject.GetComponent<MeshRenderer> ();
    }
	
	void Update ()
    {
		if (!rotationActive)
			return;
        else
			transform.Rotate(Vector3.up, 50f * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        boxCollider.enabled = false;
		meshRenderer.enabled = false;
		rotationActive = false;
		pickupManager.PickupHandling(refTrans, gameObject);
    }
}
