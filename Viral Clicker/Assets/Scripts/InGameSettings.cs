using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject OptionsPanel;
    // Start is called before the first frame update

    public void OpenOptions() {
        if (OptionsPanel != null) {
            if (OptionsPanel.activeInHierarchy) {
                OptionsPanel.SetActive(false);
            } else {
                OptionsPanel.SetActive(true);
                    }
        }
    }

    public void Back() {
        if (OptionsPanel != null) {
            OptionsPanel.SetActive(false);
        }
    }
}
