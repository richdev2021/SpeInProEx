using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilScript : MonoBehaviour
{
    public float lifeTimer = 0;
    public float speed = 25;
    public ScoreAndHiscoreScriptable SAHS;
    public ProyectilMessager PM;
    public bool Stop;
    void Update()
    {
        Stop = PM.Ingame;
        if (!Stop)
        {
            lifeTimer += 1 * Time.deltaTime;
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            if (lifeTimer >= 3) Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy"|| collision.tag == "shield") {
            if (collision.tag == "Enemy") SAHS.AddScore(10);
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
