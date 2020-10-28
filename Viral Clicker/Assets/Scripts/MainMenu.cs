using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject MenuPanel;
    // Start is called before the first frame update
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions() {
        if(OptionsPanel != null) {
            OptionsPanel.SetActive(true);
        }
        if (MenuPanel != null) {
            MenuPanel.SetActive(false);
        }
    }

    public void QuitGame() {
        Debug.Log("quit");
        Application.Quit();
    }
}

