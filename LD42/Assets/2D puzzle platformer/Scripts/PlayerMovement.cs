using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float RotationSpeed = 1f;


    public GameObject DeathPanel;
    public GameObject SuccessPanel;

    public AudioSource sfx;

    public AudioClip Bong;
    public AudioClip OhNo;
    public AudioClip OhYea;
	// Use this for initialization
	void Start () {

        sfx = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.IsRotating && !GameManager.IsPaused) {
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
            DeathPanel.SetActive(true);
            Time.timeScale = 0f;
            sfx.clip = OhNo;
                
            sfx.Play();



        }
        if (col.gameObject.tag == "Finish") {
            Debug.Log("You win");
            SuccessPanel.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}
