using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float RotationSpeed = 3f;




	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.IsRotating) {
            transform.Rotate(Vector3.forward * -RotationSpeed);
        }

    }

    private void FixedUpdate() {
        if (GameManager.StartMoving) {


            var finalAngle = transform.localEulerAngles;

            Debug.Log("Angle: " + finalAngle.z);

            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * (GameManager.MovementSpeed / 20f), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("collided");
        if (col.gameObject.tag == "Danger") {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Finish") {
            Destroy(gameObject);
            Debug.Log("You win");
        }
    }
}
