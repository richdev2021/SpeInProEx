using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ProyectilScriptable", menuName = "ScriptableObjects/ProyectilScriptable", order = 1)]
public class ProyectilMessager : ScriptableObject
{
   public bool Ingame;
    public float volume, efects;
    public void SetNotInGame(bool isInGame) {
        Ingame = isInGame;
    }
    public void AddQuantity(bool SFX) {
        if(!SFX)
            volume += 4;
        if (SFX)
            efects += 4;
    }
    public void SubstractQuantity(bool SFX)
    {
        if (!SFX)
            volume -= 4;
        if (SFX)
            efects -= 4;
    }
}
