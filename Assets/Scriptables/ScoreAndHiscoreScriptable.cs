using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScoreAndHiscoreMain", menuName = "ScriptableObjects/ScoreAndHiscoreMain", order = 1)]
public class ScoreAndHiscoreScriptable : ScriptableObject {
    // Start is called before the first frame update
    public float Score, Hiscore;
    public int Lives, Rounds;
    public void AddScore(float Addedscore)
    {
        Score += Addedscore;
    }
    public void ReduceLives(int ReducedLives) {
        Lives -= ReducedLives;
    }

}
