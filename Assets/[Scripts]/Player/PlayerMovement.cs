using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float XAxisValue, speed, XDP, XJT;
    [SerializeField] bool alredyUsing;
    void Start()
    {
        
    }
    void Update()
    {
        valueSet();
        Movement(XAxisValue);
    }
    void valueSet()
    {
        XDP = Input.GetAxisRaw("Debug Horizontal");
        XJT = Input.GetAxisRaw("Horizontal");
        if ( Mathf.Abs(XDP) >= Mathf.Abs(XJT)) XAxisValue = XDP * (speed * Time.deltaTime); else XAxisValue = XJT * (speed * Time.deltaTime);
    }
    void Movement(float amount) {
        transform.position += new Vector3(amount,0,0);
    }
}
