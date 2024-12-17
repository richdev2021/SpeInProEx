using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInclusion : MonoBehaviour
{
    public int eventCounter, keyPressVerifier,generalCounter;
    public Event KeyPressed;
    public bool FireButton() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire3")) return true; else return false;
    }
    public bool fireHold() {
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire3")) return true; else return false;
    }
    public bool acceptButton() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) return true; else return false;
    }
    public bool backButton()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire2")) return true; else return false;
    }
    public bool pauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("pause")) return true; else return false;
    }
    public int DetectTypeOfInput() {
        if (Input.anyKeyDown) { if (controllerKey()) return 1; else return 2; } else return 0;
        // if (Input.anyKeyDown) { KeyPressed = Event.current; if (KeyPressed.isKey) { Debug.Log(KeyPressed.keyCode); } }
        /*if (Input.anyKeyDown)
        {
            generalCounter++;
            keyPressVerifier = eventCounter;
            Event e = Event.current;
            if (e.isKey)
            {
                if (e.keyCode.ToString() != "None")
                    eventCounter++;
            }
            if (keyPressVerifier < eventCounter)
            {
                Debug.Log("keyboard");
            }
            else Debug.Log("Controller");
            eventCounter = 0;
        }
        return 10;*/
    }
    public bool controllerKey() {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button6)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button7)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button8)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick1Button9)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button0)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button1)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button2)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button3)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button4)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button5)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button6)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button7)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button8)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick2Button9)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button0)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button1)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button2)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button3)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button4)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button5)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button6)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button7)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button8)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick3Button9)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button0)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button1)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button2)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button3)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button4)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button5)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button6)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button7)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button8)) return true;
        else if (Input.GetKeyDown(KeyCode.Joystick4Button9)) return true;
        else return false;
    }
}
