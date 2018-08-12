using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static float MovementSpeed = 0f;

    public GameObject RotateButton;
    public GameObject PowerButton;
    public Text PowerIndicator;

    public static bool IsRotating = true;
    private bool IncrementPower = false;

    public static bool StartMoving = false;

    public static float power = 0f;
	// Use this for initialization
	void Start () {
        StartCoroutine(IncreasePower());

	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator IncreasePower() {
        while (true) {
            if (IncrementPower) {

                MovementSpeed += 1;
                Debug.Log(MovementSpeed);
                PowerIndicator.text = MovementSpeed.ToString();
                yield return new WaitForSeconds(1f);
            }
        }
    }


    public void StopRotating() {
        IsRotating = false;
        RotateButton.SetActive(false);
        IncrementPower = true;
    }

    public void SetPower() {
        StartMoving = true;
        IncrementPower = false;
        PowerButton.SetActive(false);
    }
}
