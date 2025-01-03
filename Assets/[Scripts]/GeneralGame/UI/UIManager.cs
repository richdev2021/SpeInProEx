using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject Settings, PauseMenu;
    public TextMeshProUGUI SettingsButtonSaveToogle;
    public bool SettingsActive = false, PauseActive = false;
    [SerializeField]
    public GameStates currentState; // Estados del juego
    public PauseSistem manager;
    public ProyectilMessager PM;
    public Slider VOL,FX;
    public AudioMixer volume;
    void Start()
    {
        try
        {
            PauseSistem.GetInstance().GSC += changeGameState;
            PM.LoadVolume();
            useSavedValues();
        }
        catch
        {
            PM.LoadVolume();
            useSavedValues();
        }
    }
    private void OnEnable()
    {
        try
        {
            PauseSistem.GetInstance().GSC += changeGameState;
            PM.LoadVolume();
            useSavedValues();
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
        if (SettingsActive) {
            SettingsButtonSaveToogle.text = "Guardar"; PM.LoadVolume();useSavedValues(); 
        } else{ 
            SettingsButtonSaveToogle.text = "Configuración"; PM.SaveVolume(); 
        }
    }
    public void PauseGame() {
        PauseActive = !PauseActive;
        PauseMenu.SetActive(PauseActive);
        if (PauseActive) { manager.changeGameState(GameStates.PAUSED); PM.SaveVolume(); } else{ manager.changeGameState(GameStates.INGAME); PM.LoadVolume();useSavedValues(); };
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
    public void changeVolume() {
        PM.volume = VOL.value * 5;
        volume.SetFloat("Music",PM.volume-80);
    }
    public void changeEffects()
    {
        PM.efects = FX.value * 5;
        volume.SetFloat("SFX", PM.efects - 80);
    }
    public void useSavedValues()
    {
        try
        {
            VOL.value = PM.volume / 5;
            FX.value = PM.efects / 5;
            volume.SetFloat("Music", PM.volume - 80);
            volume.SetFloat("SFX", PM.efects - 80);
        }
        catch {
            volume.SetFloat("Music", PM.volume - 80);
            volume.SetFloat("SFX", PM.efects - 80);
        }
    }
}
