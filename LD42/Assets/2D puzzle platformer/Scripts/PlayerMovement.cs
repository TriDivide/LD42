using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float RotationSpeed = 5f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.IsRotating) {
            transform.Rotate(Vector3.forward * -RotationSpeed);
        }
		if (GameManager.StartMoving) {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * GameManager.MovementSpeed;

        }
    }
}
