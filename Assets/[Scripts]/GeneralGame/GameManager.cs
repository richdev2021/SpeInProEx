using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int Level, tutorialStep, typeOfInput;
    public bool inTutoria, canshoot, canMove;
    public ImageSwitcher[] AdaoptativeImages;
    public GameObject iconX, IconB;
    public TextMeshProUGUI tutorial;
    public ControllerInclusion CI;
    public int controllerDetector;
    public EnemyManager EM;

    private void Update()
    {
        playTutorial();
    }
    void playTutorial() {
        if (Level == 0)
        {
            TutorialBasicControlls();
            tutorialProgression();
            if (CI.DetectTypeOfInput() != 0)
            {
                controllerDetector = CI.DetectTypeOfInput();
                AdaoptativeImages[0].switchImage(controllerDetector);
                AdaoptativeImages[1].switchImage(controllerDetector);
            }
        }
        else
        {
            tutorialStep = 0;
            tutorial.text = ("");
            iconX.SetActive(false);
            IconB.SetActive(false);
        }
        
    }
    void TutorialBasicControlls() {
        if (CI.FireButton()) tutorialStep += 1;
        if (CI.backButton())
        {
            if (tutorialStep >= 6) tutorialStep = 0;
                tutorialStep -= 1;
            if (tutorialStep <= 0) tutorialStep = 0;
        }
    }
    void tutorialProgression()
    {
        if (tutorialStep == 0) {
            tutorial.text = "bienvenido a SpeInProEx, lo último en simulación de combate alienígena, para continuar y disparar presiona: ";
            iconX.SetActive(true);
            canMove = false;
            canshoot = false;
            IconB.SetActive(false);
            EM.backToStart();
        }
        if (tutorialStep == 1)
        {
            tutorial.text = "utiliza la palanca de movimiento en caso de estar en mando o a y d en caso de estar en teclado para moverte";
            iconX.SetActive(false);
            canMove = true;
        }
        if (tutorialStep == 2)
        {
            tutorial.text = "tienes que acabar con todas las naves enemigas, después de acabar con ellas otra oleada vendra mas rapida y podría ser más numerosa";
        }
        if (tutorialStep == 3)
        {
            tutorial.text = "ellos también te dispararan evita sus disparos, puedes usar los escudos de energía para cubrirte";
            canshoot = true;
        }
        if (tutorialStep == 4)
        {
            tutorial.text = "estás en una simulación infinita, tu objetivo es sobrevivir lo más posible, evita que lleguen a ti";
            IconB.SetActive(false);
        }
        if (tutorialStep == 5)
        {
            tutorial.text = "para continuar acaba con todos, para volver en este tutorial presiona: ";
            IconB.SetActive(true);
        }
        if (tutorialStep >= 6)
        {
            tutorial.text = "repetir tutorial con: ";
        }

    }
}
