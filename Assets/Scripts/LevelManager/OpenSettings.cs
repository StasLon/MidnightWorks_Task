using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{

    public GameObject settingsWindow;
    public Button settingsButton;

    private void Start()
    {
        settingsWindow.SetActive(false);
        settingsButton.onClick.AddListener(ToggleSettingsWindow);
    }


    public void ToggleSettingsWindow()
    {
        settingsWindow.SetActive(true);
        
    }


    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
