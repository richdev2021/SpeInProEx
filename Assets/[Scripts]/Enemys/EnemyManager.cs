using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public SpriteRenderer[] ESR;
    public GameObject proyectile, player;
    public float Timer, TimeMax, Incrementation, direction, TotalSpeed, ProyectilSpawnTimer, proyectilSpawnMax, enemyDistance, Distance = 1000, SavedValue;
    public int RandomEnemy, enemyCounter, RandBetfirstAndLast, nearestEnemy, RealLevel;
    public bool MoveDown, HaveLose, DefineTime, noEnemysLeft,DoAnithing;
    public Vector2[] startingPositions;
    public GameManager GM;
    public ScoreAndHiscoreScriptable SAHS;
    public ScoreManager SM;
    public AudioSource OwnSource;
    public ShieldsManager SHM;
    public float[][] SavedPosition;

    public GameStates currentState;
    public PauseSistem manager;
    private void OnEnable()
    {
        try
        {
            PauseSistem.GetInstance().GSC += changeGameState;
        }
        catch { };
    }
    private void OnDisable()
    {
        PauseSistem.GetInstance().GSC -= changeGameState;
    }
    void changeGameState(GameStates _gs)
    {
        //Debug.Log(_gs);
        currentState = _gs; // Asignar el estado actual del juego
        if (currentState == GameStates.PAUSED) { DoAnithing = false; }
        else if (currentState == GameStates.INGAME) { DoAnithing = true; }; // Actualizar movimiento basado en el estado
    }
    private void Start()
    {
        PauseSistem.GetInstance().GSC += changeGameState;
        for (int j = 0; j <= Enemys.Length - 1; j++) startingPositions[j] = Enemys[j].transform.position;
        changeLevel(GM.Level);
        if (SAHS.PressedContinue) {
            ResumeGame();
            SHM.activateSavedShields();
            SAHS.PressedContinue = false;

        }
    }
    private void FixedUpdate()
    {
        if (DoAnithing)
        {
            RealLevel = GM.Level;
            if (HaveLose == false)
                timerFunction();
            ProyectilSpawnTimer += 1 * Time.deltaTime;
            if (ProyectilSpawnTimer >= proyectilSpawnMax)
            {
                if (GM.canshoot)
                    RandomShooting();
                ProyectilSpawnTimer = 0;
                GM.canMove = true;
                GM.canshoot = true;
            }
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
        RandomEnemy = UnityEngine.Random.Range(0, 83);
        OwnSource.pitch = UnityEngine.Random.Range(3.0f, 1f);
        OwnSource.PlayOneShot(OwnSource.clip);
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
        else { GM.Level++; RealLevel++; changeLevel(RealLevel); SAHS.Rounds = RealLevel; SM.SetRounds(0, RealLevel); };
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
            reactivate(Enemys.Length);
        }
        if(level >= 5)
        {
            SHM.reactivateAll();
        }
    }
    public void reactivate(int amount) {
        for (int i = 0; i < amount; i++)
            Enemys[i].SetActive(true);
    }
    public void deactivateAll() {
        for (int i = 0; i < Enemys.Length; i++)
            Enemys[i].SetActive(false);
    }
    public void backToStart() {
        for (int j = 0; j <= Enemys.Length - 1; j++) Enemys[j].transform.position = startingPositions[j];
    }
    public void EnemyAvailableSave() {
        StringBuilder enemysToSave = new StringBuilder();
        StringBuilder positionsToSave = new StringBuilder();
        for (int i = 0; i < Enemys.Length; i++) { 
            if (Enemys[i].active)
            {
                enemysToSave.Append(i);
                enemysToSave.Append("/");
                positionsToSave.Append((Enemys[i].transform.position.x));
                positionsToSave.Append("/");
                positionsToSave.Append((Enemys[i].transform.position.y));
                positionsToSave.Append("/");
            }
        }
        SAHS.RTS = RealLevel;
        SAHS.enemys = enemysToSave.ToString();
        SAHS.ActiveEnemysPos = positionsToSave.ToString();
        SAHS.direction = direction;
        SHM.GetActiveShields();
        SAHS.SaveAll();
        Debug.Log(enemysToSave.ToString());
    }
    public void ResumeGame() {
        if (SAHS.enemys != null) {
            SAHS.loadAll();
            deactivateAll();
            direction = SAHS.direction;
            RealLevel = SAHS.RTS;
            GM.Level = SAHS.RTS;
            SM.SetRounds(0, SAHS.RTS);
            SHM.activateSavedShields();
            string[] ActiveEnemys = SAHS.enemys.Split("/");
            string[] enemysPosRaw = SAHS.ActiveEnemysPos.Split("/");
            SavedValue = float.Parse(ActiveEnemys[0]);
            int PIV = 0;
            int PTV = 0;
            for (int i = 0; i < Enemys.Length; i++)
            {
                if (SavedValue == i)
                {
                    Enemys[i].transform.position = new Vector2(float.Parse(enemysPosRaw[PTV]), float.Parse(enemysPosRaw[PTV + 1]));
                    Enemys[i].SetActive(true);
                    PIV++;
                    PTV = PTV + 2;
                    if (ActiveEnemys[PIV] != "" || ActiveEnemys[PIV] != null) ;
                    SavedValue = float.Parse(ActiveEnemys[PIV]); 
                }
                else {
                    Enemys[i].SetActive(false);
                }
            }
        }
    }

}
