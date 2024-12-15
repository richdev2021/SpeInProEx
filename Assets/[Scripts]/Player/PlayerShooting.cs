using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject proyectil;
    public float AntiSpam, delay;
    public bool TriggerFire;
    private void Update()
    {
        AntiSpam += 1 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKey(KeyCode.Space))
            if (AntiSpam >= delay)
            {
                fire();
            }
            else 
            {
                TriggerFire = true;
            }

        if (AntiSpam >= delay) {
            AntiSpam = delay;
            if (TriggerFire) fire();
        }
    }
    public void fire() {
        Instantiate(proyectil, transform.position,transform.rotation);
        TriggerFire = false;
        AntiSpam = 0;
    }
}
