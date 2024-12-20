using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float XAxisValue, speed, XDP, XJT;
    public GameStates currentState; // Estados del juego
    public PauseSistem manager;
    void Start()
    {
        PauseSistem.GetInstance().GSC += changeGameState;
    }
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
        if (currentState == GameStates.PAUSED) speed = 0;
        else if (currentState == GameStates.INGAME) speed = 30; // Actualizar movimiento basado en el estado
    }
    void Update()
    {
        valueSet();
        Movement(XAxisValue);
    }
    void valueSet()
    {
        XDP = Input.GetAxisRaw("DpadMovement");
        XJT = Input.GetAxisRaw("Horizontal");
        if ( Mathf.Abs(XDP) >= Mathf.Abs(XJT)) XAxisValue = XDP * (speed * Time.deltaTime); else XAxisValue = XJT * (speed * Time.deltaTime);
    }
    void Movement(float amount) {
        transform.position += new Vector3(amount,0,0);
        if (transform.position.x >= 27.5f) transform.position = new Vector3(-27, transform.position.y, transform.position.z);
        if (transform.position.x <= -27.5f) transform.position = new Vector3(27, transform.position.y, transform.position.z);
    }
}
