using UnityEngine;
using System.Collections;

public class StartPosition : MonoBehaviour
{

    public Transform startPosition;

    void Awake()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
    }

}
