using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ProyectilScriptable", menuName = "ScriptableObjects/ProyectilScriptable", order = 1)]
public class ProyectilMessager : ScriptableObject
{
   public bool Ingame;
    public float volume, efects;
    private static string Vol = "volume", FX = "efects"; 
    public void SetNotInGame(bool isInGame) {
        Ingame = isInGame;
    }
    public void SaveVolume() {
        PlayerPrefs.SetFloat(Vol, volume);
        PlayerPrefs.SetFloat(FX, efects);
    }
    public void LoadVolume() {
        PlayerPrefs.GetFloat(Vol, volume);
        PlayerPrefs.GetFloat(FX, efects);
    }
}
