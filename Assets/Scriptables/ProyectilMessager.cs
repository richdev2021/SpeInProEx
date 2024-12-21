using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ProyectilScriptable", menuName = "ScriptableObjects/ProyectilScriptable", order = 1)]
public class ProyectilMessager : ScriptableObject
{
   public bool Ingame;
    public void SetNotInGame(bool isInGame) {
        Ingame = isInGame;
    }
}
