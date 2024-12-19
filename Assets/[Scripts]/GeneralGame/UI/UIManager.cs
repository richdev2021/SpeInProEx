using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Settings, PauseMenu;
    public TextMeshProUGUI SettingsButtonSaveToogle;
    public bool SettingsActive = false, PauseActive = false;
    public void SettingsToogle() {
        SettingsActive = !SettingsActive;
        Settings.SetActive(SettingsActive);
        if (SettingsActive) SettingsButtonSaveToogle.text = "Guardar"; else SettingsButtonSaveToogle.text = "Configuración";
    }
    public void PauseGame() {
        PauseActive = !PauseActive;
        PauseMenu.SetActive(PauseActive);
    }
    public void QuitApp() {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToStartMenu() {
        SceneManager.LoadScene("MainMenuScene");
    }
}
