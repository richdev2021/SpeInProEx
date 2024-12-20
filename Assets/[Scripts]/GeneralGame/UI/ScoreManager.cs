using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score, hiscore, rounds;
    public GameObject[] lives;
    public float FScore, FHiscore;
    public int FLives, FRounds;
    public ScoreAndHiscoreScriptable SAHS;
    
    public void Start()
    {
        FScore = SAHS.Score;
        FHiscore = SAHS.Hiscore;
        FLives = SAHS.Lives;
        FRounds = SAHS.Rounds;
        SetLives(0, FLives);
        SetScore(0);
        addToHiscore(FScore);
        SetRounds(0, FRounds);
    }
    public void FixedUpdate()
    {
        SetScore(SAHS.Score);
        SAHS.Rounds = FRounds;
        SetLives(0, SAHS.Lives);
    }
    public void SetScore(float Addedscore) {
        FScore = Addedscore;
        score.text = "puntuación : " + FScore;
        if (FScore > FHiscore) {
            addToHiscore(FScore);
        }
    }
    public void addToHiscore(float AddedHiScore) {
        FHiscore = AddedHiScore;
        hiscore.text = "Mejor puntuación : " + FHiscore;
        SAHS.Hiscore = FHiscore;
    }
    public void SetLives(int operation, int livesToCompare) {
        if (operation == -1) {
            FLives -= livesToCompare;
        }
        if (operation == 0)
        {
            FLives = livesToCompare;
        }
        if (operation == 1)
        {
            FLives += livesToCompare;
        }
        Debug.Log("LiveSet");
        for (int i = -0; i <= lives.Length-1; i++) {
            if (FLives > i) lives[i].SetActive(true); else lives[i].SetActive(false);
            Debug.Log(i + " " +FLives);
        }
        if (FLives == 0) SceneManager.LoadScene("GameOverScene");
    }
    public void SetRounds(int operation, int RoundsToCompare)
    {
        if (operation == -1)
        {
            FRounds -= RoundsToCompare;
        }
        if (operation == 0)
        {
            FRounds = RoundsToCompare;
        }
        if (operation == 1)
        {
            FRounds += RoundsToCompare;
        }
        rounds.text = "Round: " + FRounds;
    }
}
