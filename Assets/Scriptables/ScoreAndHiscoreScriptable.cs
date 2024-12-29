using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScoreAndHiscoreMain", menuName = "ScriptableObjects/ScoreAndHiscoreMain", order = 1)]
public class ScoreAndHiscoreScriptable : ScriptableObject {
    // Start is called before the first frame update
    public float Score, Hiscore,direction;
    public int Lives, Rounds,RTS;
    public string enemys, ActiveEnemysPos,shields;
    public bool PressedContinue;
    public static string PPS = "Score", PPHS = "HiScore", PPL = "Lives", PPR = "Rounds", AE = "EnemigosEnEscena", AEP = "EnemyPos",DIR = "Direction";
    public void AddScore(float Addedscore)
    {
        Score += Addedscore;
    }
    public void ReduceLives(int ReducedLives) {
        Lives -= ReducedLives;
    }
    public void NewGame() {
        Score = 0;
        Lives = 6;
        Rounds = 0;
        RTS = 0;
        enemys = null;
        ActiveEnemysPos = null;
        SaveAll();
    }
    public void SaveAll() {
        PlayerPrefs.SetFloat(PPS,Score);
        PlayerPrefs.SetInt(PPL, Lives);
        PlayerPrefs.SetInt(PPR, RTS);
        PlayerPrefs.SetFloat(PPHS, Hiscore);
        PlayerPrefs.SetString(AE, enemys);
        PlayerPrefs.SetString(AEP, ActiveEnemysPos);
        PlayerPrefs.SetFloat(DIR, direction);
    }
    public void loadAll()
    {
        PlayerPrefs.GetFloat(PPS, Score);
        PlayerPrefs.GetInt(PPL, Lives);
        PlayerPrefs.GetInt(PPR, Rounds);
        PlayerPrefs.GetFloat(PPHS, Hiscore);
        PlayerPrefs.GetString(AE, enemys);
        PlayerPrefs.GetString(AEP, ActiveEnemysPos);
        PlayerPrefs.GetFloat(DIR, direction);
    }

}
