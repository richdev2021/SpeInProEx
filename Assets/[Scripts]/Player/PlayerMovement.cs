using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]public float XAxisValue, speed, XDP, XJT;
    public GameStates currentState; // Estados del juego
    public PauseSistem manager;
    public ProyectilMessager PM;
    void Start()
    {
        PauseSistem.GetInstance().GSC += changeGameState;
        manager.changeGameState(GameStates.INGAME);
    }
    private void OnEnable()
    {
        try
        {
            PauseSistem.GetInstance().GSC += changeGameState;
            manager.changeGameState(GameStates.INGAME);
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
        if (currentState == GameStates.PAUSED) { speed = 0; PM.SetNotInGame(true); }
        else if (currentState == GameStates.INGAME) { speed = 30; PM.SetNotInGame(false); }; // Actualizar movimiento basado en el estado
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
