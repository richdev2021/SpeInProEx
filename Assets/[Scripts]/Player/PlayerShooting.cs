using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject proyectil;
    public float AntiSpam, delay;
    public ControllerInclusion CI;
    public PlayerMovement PLM;
    public AudioSource OwnSource;
    private void Update()
    {
        if(PLM.speed != 0)
        spamDetect();
    }
    private void spamDetect() {
        AntiSpam += 1 * Time.deltaTime;
        if (CI.fireHold())
            if (AntiSpam >= delay)
            {
                fire();
            }

        if (CI.FireButton()) {
            if (AntiSpam >= delay)
            {
                fire();
            }
        }
        if (AntiSpam >= delay)
        {
            AntiSpam = delay;
        }
        
    }
    public void fire() {
        Instantiate(proyectil, transform.position,transform.rotation);
        AntiSpam = 0;
        OwnSource.pitch = Random.Range(3.0f,0.2f);
        OwnSource.PlayOneShot(OwnSource.clip);
    }
}
