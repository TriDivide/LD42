using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static float MovementSpeed = 0f;

    public GameObject RotateButton;
    public GameObject PowerButton;
    public Text PowerIndicator;

    public GameObject StartArea;
    public GameObject FinishArea;

    public GameObject Danger1;
    public GameObject Danger2;

    public static bool IsRotating = true;
    private bool IncrementPower = false;

    public static bool StartMoving = false;

    public static float power = 0f;
    private Vector3 target;
	// Use this for initialization
	void Start () {
        PowerButton.SetActive(false);
        StartCoroutine(IncreasePower());

	}
	
	// Update is called once per frame
	void Update () {
        Danger1.transform.localScale = Vector3.Lerp(Danger1.transform.localScale, new Vector3(100,100), Time.deltaTime * 0.005f);
        Danger2.transform.localScale = Vector3.Lerp(Danger2.transform.localScale, new Vector3(100, 100), Time.deltaTime * 0.005f);
        FinishArea.transform.localScale = Vector3.Lerp(FinishArea.transform.localScale, target, Time.deltaTime * 0.1f);


    }

    IEnumerator IncreasePower() {
        bool repeat = true;
        while (repeat) {
            if (StartMoving) {
                repeat = false;
            }

            if (IncrementPower) {
                MovementSpeed += 1;
                PowerIndicator.text = MovementSpeed.ToString();
            }
            yield return new WaitForSeconds(.5f);

            
        }
    }


    public void StopRotating() {
        IsRotating = false;
        RotateButton.SetActive(false);
        PowerButton.SetActive(true);
        IncrementPower = true;
    }

    public void SetPower() {
        StartMoving = true;
        IncrementPower = false;
        PowerButton.SetActive(false);
    }
}
