using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public GameObject RotateButton;
    public GameObject PowerButton;
    public Text PowerIndicator;

    public GameObject StartArea;
    public GameObject FinishArea;

    public GameObject Danger1;
    public GameObject Danger2;

    public GameObject PausePanel;


    public static bool IsRotating = true;
    private bool IncrementPower = false;
    public static bool StartMoving = false;
    public static float MovementSpeed = 0f;

    public static bool IsPaused = false;



	// Use this for initialization
	void Start () {
        StartMoving = false;
        IsRotating = true;
        IncrementPower = false;
        MovementSpeed = 0f;
        IsPaused = false;
        PowerButton.SetActive(false);
        StartCoroutine(IncreasePower());

	}
	
	// Update is called once per frame
	void Update () {
        Danger1.transform.localScale = Vector3.Lerp(Danger1.transform.localScale, new Vector3(100,100), Time.deltaTime * 0.001f);
        if (Danger2 != null) {
            Danger2.transform.localScale = Vector3.Lerp(Danger2.transform.localScale, new Vector3(100, 100), Time.deltaTime * 0.001f);
        }
        FinishArea.transform.localScale = Vector3.Lerp(FinishArea.transform.localScale, new Vector3(), Time.deltaTime * 0.1f);


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
            yield return new WaitForSeconds(.75f);

            
        }
    }


    public void StopRotating() {
        IsRotating = false;
        RotateButton.SetActive(false);
        PowerButton.SetActive(true);
        IncrementPower = true;
    }

    public void SetPower() {
        Debug.Log("set power");
        StartMoving = true;
        IncrementPower = false;
        PowerButton.SetActive(false);
    }




    public void ExitLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeLevel() {
        PausePanel.gameObject.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseLevel() {
        Time.timeScale = 0f;
        PausePanel.gameObject.SetActive(true);
        IsPaused = true;
    }

    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
