using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleIf : MonoBehaviour
{
    public ScoreAndHiscoreScriptable SAHS;
    public Button self;
    public Image imagen;
    void Update()
    {
        if (SAHS.Score > 10) { self.enabled = true; imagen.color = Color.white; }
        else{ self.enabled = false; imagen.color = Color.black; }
    }
}
