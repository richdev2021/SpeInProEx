using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsManager : MonoBehaviour
{
    public GameObject[] Shields;
    public ScoreAndHiscoreScriptable SAHS;
    public void Start()
    {
        reactivateAll();
    }
    public void GetActiveShields() {
        StringBuilder shields = new StringBuilder();
        for (int i = 0; i < Shields.Length; i++)
        {
            if (Shields[i].active) shields.Append("true"); else shields.Append("false");
            shields.Append("/");
        }
        SAHS.shields = shields.ToString();
    }
    public void activateSavedShields() {
        
        string[] setshields = SAHS.shields.Split("/");
        for (int i = 0; i < Shields.Length; i++)
        {
            Shields[i].SetActive(bool.Parse(setshields[i]));
        }
    }
    public void reactivateAll() {
        for (int i = 0; i < Shields.Length; i++)
        {
            Shields[i].SetActive(true);
        }
    }
}
