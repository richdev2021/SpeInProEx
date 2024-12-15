using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public GameObject proyectile;
    public float Timer, TimeMax,Incrementation, direction, TotalSpeed,ProyectilSpawnTimer,proyectilSpawnMax;
    public int RandomEnemy, enemyCounter,RandBetfirstAndLast;
    public bool MoveDown, HaveLose, DefineTime, noEnemysLeft;
    private void FixedUpdate()
    {
        if(HaveLose == false)
        timerFunction();
        ProyectilSpawnTimer += 1 * Time.deltaTime;
        if (ProyectilSpawnTimer >= proyectilSpawnMax) {
            RandomShooting();
            ProyectilSpawnTimer = 0;
        }
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
    private void RandomShooting() {
        RandomEnemy = Random.RandomRange(0, 83);
        for(int i = 0; i <= Enemys.Length - 1; i++) 
        {
            if (Enemys[i].active == true) enemyCounter += 1;
        }
        if (enemyCounter != 0)
        {
            if (Enemys[RandomEnemy].active == false) {enemyCounter = 0;
                RandBetfirstAndLast = Random.Range(0, 2);
                for (int i = 0; i <= Enemys.Length - 1; i++)
                {
                    if (RandBetfirstAndLast == 0)
                    {
                        if (Enemys[i].active == true) RandomEnemy = i;
                    }
                    else
                    {
                        if (Enemys[i].active == true)
                        {
                            RandomEnemy = i;
                            i += 1000;
                        }
                    }
                }
            }
            Instantiate(proyectile, Enemys[RandomEnemy].transform.position, Enemys[RandomEnemy].transform.rotation);
        }
    }
}
