using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {


    public GameObject HowToPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(int index) {
        switch(index) {
            case 1:
                SceneManager.LoadScene("LevelOne");
                break;
            case 2:
                SceneManager.LoadScene("LevelTwo");
                break;
            case 3:
                SceneManager.LoadScene("LevelThree");
                break;
        }
    }

    public void ShowHowTo() {
        HowToPanel.SetActive(true);
    }

    public void HideHowTo() {
        HowToPanel.SetActive(false);
    }
}
