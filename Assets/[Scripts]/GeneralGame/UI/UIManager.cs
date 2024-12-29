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
    [SerializeField]
    public GameStates currentState; // Estados del juego
    public PauseSistem manager;
    void Start()
    {
        try
        {
            PauseSistem.GetInstance().GSC += changeGameState;
        }
        catch { }
    }
    private void OnEnable()
    {
        try
        {
            PauseSistem.GetInstance().GSC += changeGameState;
        }
        catch { };
    }
    private void OnDisable()
    {
        try
        {
            PauseSistem.GetInstance().GSC -= changeGameState;
        }
        catch { }
    }
    void changeGameState(GameStates _gs)
    {
        currentState = _gs;
    }
    public void SettingsToogle() {
        SettingsActive = !SettingsActive;
        Settings.SetActive(SettingsActive);
        if (SettingsActive) SettingsButtonSaveToogle.text = "Guardar"; else SettingsButtonSaveToogle.text = "Configuración";
    }
    public void PauseGame() {
        PauseActive = !PauseActive;
        PauseMenu.SetActive(PauseActive);
        if (PauseActive) manager.changeGameState(GameStates.PAUSED); else manager.changeGameState(GameStates.INGAME);
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
    public void continueGame() { 
        
    }
}
