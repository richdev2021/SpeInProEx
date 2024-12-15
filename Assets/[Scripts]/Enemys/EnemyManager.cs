using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public float Timer, TimeMax,Incrementation, direction, TotalSpeed;
    public bool MoveDown, HaveLose, DefineTime;
    private void FixedUpdate()
    {
        if(HaveLose == false)
        timerFunction();
    }
    private void timerFunction() {
        Timer += 1 * Time.deltaTime;
        if (Timer >= TotalSpeed)
        {
            Timer = 0;
            verifyPosition();
            movePosition();
            DefineTime = true;
        }
        if (DefineTime)
        {
            TotalSpeed = (TimeMax * Incrementation)/3;
            Incrementation = 0;
            DefineTime = false;
        }
    }
    private void verifyPosition() {
        for (int j = 0; j <= Enemys.Length-1; j++)
        {
            if (Enemys[j].active == true)
            {
                Incrementation += 1;
                if (Enemys[j].transform.position.x >= 25 || Enemys[j].transform.position.x <= -25)
                {
                    MoveDown = true;
                }
                if (Enemys[j].transform.position.y <= -12)
                {
                    HaveLose = true;
                    return;
                }
            }
        }
        if (MoveDown == true) direction *= -1;
    }
    private void movePosition() {
        if (MoveDown == false)
        {
            for (int i = 0; i <= Enemys.Length-1; i++)
            {
                try
                {
                    Enemys[i].transform.position += new Vector3(0.4f * direction, 0, 0);
                }
                catch { Debug.Log("cantMove"+ i); }
            }
        }
        else
        {
            for (int k = 0; k <= Enemys.Length-1; k++)
            {
                try
                {
                    Enemys[k].transform.position += new Vector3(0, -2, 0);
                }
                catch { Debug.Log("cantMove"+ k); }
            }
            for (int i = 0; i <= Enemys.Length - 1; i++)
            {
                try
                {
                    Enemys[i].transform.position += new Vector3(0.4f * direction, 0, 0);
                }
                catch { Debug.Log("cantMove" + i); }
            }
            MoveDown = false;
        }
    }
}
