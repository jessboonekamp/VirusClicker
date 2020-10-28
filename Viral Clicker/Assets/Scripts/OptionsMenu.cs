using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject MenuPanel;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public void Back() {
        if (OptionsPanel != null) {
            OptionsPanel.SetActive(false);
        }
        if (MenuPanel != null) {
            MenuPanel.SetActive(true);
        }
    }

    public void SetVolume(float volume) {

        audioMixer.SetFloat("Volume", volume);
    }
}
