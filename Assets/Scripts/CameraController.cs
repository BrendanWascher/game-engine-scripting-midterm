using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    float cameraFollowSpeed = 5;

    [SerializeField]
    Transform objectToFollow;

    [SerializeField]
    float xOffSet;

    [SerializeField]
    float yOffSet;

    float zOffSet = -10;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPosition = new Vector3(objectToFollow.position.x + xOffSet, objectToFollow.position.y + yOffSet, zOffSet);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
	}
}
