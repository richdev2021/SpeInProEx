using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public GameObject proyectile, player;
    public float Timer, TimeMax, Incrementation, direction, TotalSpeed, ProyectilSpawnTimer, proyectilSpawnMax, enemyDistance, Distance = 1000;
    public int RandomEnemy, enemyCounter, RandBetfirstAndLast, nearestEnemy, RealLevel;
    public bool MoveDown, HaveLose, DefineTime, noEnemysLeft;
    public Vector2[] startingPositions;
    public GameManager GM;
    private void Start()
    {
        for (int j = 0; j <= Enemys.Length - 1; j++) startingPositions[j] = Enemys[j].transform.position;
        changeLevel(GM.Level);
    }
    private void FixedUpdate()
    {
        RealLevel = GM.Level;
        if(HaveLose == false)
        timerFunction();
        ProyectilSpawnTimer += 1 * Time.deltaTime;
        if (ProyectilSpawnTimer >= proyectilSpawnMax) {
            if(GM.canshoot)
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
            if(GM.canMove)
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
            if (Enemys[i].active == true)
            {
                enemyCounter += 1;
                enemyDistance = Vector2.Distance(player.transform.position, Enemys[i].transform.position);
                if (enemyDistance <= Distance)
                {
                    nearestEnemy = i;
                    Distance = nearestEnemy;
                }
            }
        }
        if (enemyCounter != 0)
        {
            if (Enemys[RandomEnemy].active == false)
            {
                RandomEnemy = nearestEnemy;
            }
            Instantiate(proyectile, Enemys[RandomEnemy].transform.position, Enemys[RandomEnemy].transform.rotation);
            Distance = 1000;
            enemyCounter = 0;
        }
        else { GM.Level++; RealLevel++; changeLevel(RealLevel); };
    }
    public void changeLevel(int level) {
        backToStart();
        if (level == 0) {
            reactivate(11);
        }
        if (level == 1) {
            reactivate(Enemys.Length/4);
        }
        if (level == 2) {
            reactivate((Enemys.Length) / 2);
        }
        if (level == 3)
        {
            reactivate(((Enemys.Length)/4)*3);
        }
        if (level >= 4)
        {
            reactivate(Enemys.Length-1);
        }
    }
    public void reactivate(int amount) {
        for (int i = 0; i < amount; i++)
            Enemys[i].SetActive(true);
    }
    public void backToStart() {
        for (int j = 0; j <= Enemys.Length - 1; j++) Enemys[j].transform.position = startingPositions[j];
    }
}
