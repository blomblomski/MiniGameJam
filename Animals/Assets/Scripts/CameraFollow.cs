using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    public Transform playerPos;
    public Vector3 offset = new Vector3();
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(playerPos.position.x + offset.x, playerPos.position.y + offset.y, playerPos.position.z + offset.z);

	}
}
