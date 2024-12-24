using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public float lifeTimer = 0;
    public float Max = 1;
    void Update()
    {
        lifeTimer += 1 * Time.deltaTime;
        if (lifeTimer >= Max) Destroy(this.gameObject);
    }
}
