using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float RotationSpeed = 5f;

    public Sprite self;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.IsRotating) {
            transform.Rotate(Vector3.forward * -RotationSpeed);
        }
		if (GameManager.StartMoving) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * GameManager.MovementSpeed, ForceMode2D.Impulse);

        }


    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("collided");
        if (col.gameObject.tag == "Danger") {
            Destroy(gameObject);
        }
    }
}
