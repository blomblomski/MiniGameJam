using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameManager gameManager;

    public Transform currentPosition;
    public Rigidbody rigbody;
    public Collider coll;
     
    public float speed;
    public float constSpeed;
    public Vector3 _currentSpeed = new Vector3();
    public float jumpHeight;
    public float distanceToGround;
    public float distToWall;
	// Use this for initialization
	void Start () {
        gameManager.GetComponent<GameManager>();
        distanceToGround = coll.bounds.extents.y;
        distToWall = coll.bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () {

        _currentSpeed = rigbody.velocity;
        currentPosition.position = new Vector3(currentPosition.position.x + constSpeed,currentPosition.position.y,0f);

        if (Controls.Space() && IsGrounded())
        {           
            rigbody.AddForce(new Vector3(constSpeed * 3, currentPosition.position.y + jumpHeight, 0f), ForceMode.VelocityChange);
        }

        if (IsGrounded())
        {
            if (Controls.Left() && constSpeed > 0)
            {
                constSpeed *= -1;
                currentPosition.Rotate(0,180,0);
            }
            if (Controls.Right() && constSpeed < 0)
            {
                constSpeed *= -1;
                currentPosition.Rotate(0, 180, 0);
            }
        }

        if (HitWall())
        {
            constSpeed *= -1;
            currentPosition.Rotate(0, 180, 0);
        }


        if (currentPosition.position.y < -20)
        {
             #if UNITY_EDITOR
                 UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
            #else
                 Application.Quit();
            #endif
        }

    }


    bool IsGrounded() {
        return Physics.Raycast(currentPosition.position, -Vector3.up, distanceToGround + 0.1f);
    }

    bool HitWall() {
        var temp = new Vector3(currentPosition.position.x, currentPosition.position.y - .5f, 0f);
        return Physics.Raycast(temp, Vector3.right * constSpeed, distToWall + 0.0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        gameManager.TimePlus();
        Destroy(other.gameObject);
    }

    public Vector3 ReturnCurrentPosition() {
        return currentPosition.position;
    }

    




}
