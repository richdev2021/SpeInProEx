using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScoreAndHiscoreMain", menuName = "ScriptableObjects/ScoreAndHiscoreMain", order = 1)]
public class ScoreAndHiscoreScriptable : ScriptableObject {
    // Start is called before the first frame update
    public float Score, Hiscore;
    public int Lives, Rounds;
    public string enemys, ActiveEnemysPos;
    public static string PPS = "Score", PPHS = "HiScore", PPL = "Lives", PPR = "Rounds", AE = "EnemigosEnEscena", AEP = "EnemyPos";
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
        SaveAll();
    }
    public void SaveAll() {
        PlayerPrefs.SetFloat(PPS,Score);
        PlayerPrefs.SetInt(PPL, Lives);
        PlayerPrefs.SetInt(PPR, Rounds);
        PlayerPrefs.SetFloat(PPHS, Hiscore);
        PlayerPrefs.SetString(AE, enemys);
        PlayerPrefs.SetString(AEP, ActiveEnemysPos);
    }
    public void loadAll()
    {
        PlayerPrefs.GetFloat(PPS, Score);
        PlayerPrefs.GetInt(PPL, Lives);
        PlayerPrefs.GetInt(PPR, Rounds);
        PlayerPrefs.GetFloat(PPHS, Hiscore);
        PlayerPrefs.GetString(AE, enemys);
        PlayerPrefs.GetString(AEP, ActiveEnemysPos);
    }

}
