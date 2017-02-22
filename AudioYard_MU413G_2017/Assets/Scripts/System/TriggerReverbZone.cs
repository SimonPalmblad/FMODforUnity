using UnityEngine;
using System.Collections;

public class TriggerReverbZone : MonoBehaviour
{
    private AudioReverbZone zone;

    void Awake()
    {
        zone = gameObject.GetComponent<AudioReverbZone>();
    }
	
    void OnTriggerEnter()
    {
        zone.enabled = true;
    }

    void OnTriggerExit()
    {
        zone.enabled = false;
    }
}
