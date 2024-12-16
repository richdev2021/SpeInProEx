using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject proyectil;
    public float AntiSpam, delay;
    private void Update()
    {
        spamDetect();
    }
    private void spamDetect() {
        AntiSpam += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
            if (AntiSpam >= delay)
            {
                fire();
            }

        if (Input.GetKeyDown(KeyCode.Space)) {
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
    }
}
