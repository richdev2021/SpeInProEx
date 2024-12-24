using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectilScript : MonoBehaviour
{
    public float lifeTimer = 0;
    public float speed = 10;
    public ScoreAndHiscoreScriptable SAHS;
    public bool Stop;
    public ProyectilMessager PM;
    public GameObject PlayerPartiocles, ShieldParticles,bulletParticles;
    void Update()
    {
        Stop = PM.Ingame;
        if (!Stop)
        {
            lifeTimer += 1 * Time.deltaTime;
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            if (lifeTimer >= 3) Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"|| collision.tag == "shield")
        {
            if (collision.tag == "Player")
            {
                SAHS.ReduceLives(1);
                Instantiate(PlayerPartiocles,this.transform,true);
            }
            if (collision.tag == "shield") 
            Destroy(collision.gameObject);
            Instantiate(ShieldParticles, this.transform,true); ;
            Destroy(this.gameObject);

        }
        if (collision.tag == "PlayerBullet") {
            Destroy(collision.gameObject);
            Instantiate(bulletParticles,this.transform,true);
        }
    }
}
