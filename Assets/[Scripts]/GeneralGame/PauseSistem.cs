using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseSistem : MonoBehaviour
{
    public static PauseSistem _instance;
    public GameStates state;
    public Action<GameStates> GSC;

    public static PauseSistem GetInstance()
    { //define cual instance es esta
        return _instance;
    }
    public void Awake()
    {
        _instance = this;
    }
    public void changeGameState(GameStates newgamestate)
    {//cambia el estado del juego al gamestate que notifiques con actions1.GetInstance().changeGameState(//gamestate)
        //Debug.Log("change to " + newgamestate);
        state = newgamestate;
        if (GSC != null)
        {
            GSC.Invoke(state);
        }
        // Debug.Log(GSC);
    }

}
public enum GameStates
{
    PAUSED,
    INGAME
}