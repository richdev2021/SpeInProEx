using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Settings;
    public TextMeshProUGUI SettingsButtonSaveToogle;
    public bool settingsActive = false;
    public void SettingsToogle() {
        settingsActive = !settingsActive;
        Settings.SetActive(settingsActive);
        if (settingsActive) SettingsButtonSaveToogle.text = "Guardar"; else SettingsButtonSaveToogle.text = "Configuraci�n";
    }
    public void QuitApp() {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
