using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnComputerScreenOnOffGUI : MonoBehaviour
{

    [SerializeField]
    GameObject onScreen;

    [SerializeField]
    GameObject offScreen;

    [SerializeField]
    Computer computer;

    [SerializeField]
    ComputerGUI computerGUI;

    [SerializeField]
    GameObject onBackgroundObject;

    [SerializeField]
    WiringCamera wiringCamera;

    public Text isRunningStatusText;

    public Screen screen;



    static TurnComputerScreenOnOffGUI currentComputerTurnedOn;

    

    // Start is called before the first frame update
    void Start()
    {
        TurnOff();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOn(){
        if(currentComputerTurnedOn){
            currentComputerTurnedOn.TurnOff();
        }
        currentComputerTurnedOn = this;
        onScreen.SetActive(true);
        offScreen.SetActive(false);
        //computer.TurnWiringCameraOn();
        wiringCamera.gameObject.SetActive(true);
        //wiringCamera.SetInitialTransform();
        onBackgroundObject.SetActive(true);
        computerGUI.SetFunctionsTab();
        isRunningStatusText.gameObject.SetActive(false);
        screen.TurnScreenOnSelf();





    }
    public void TurnOff(){
        currentComputerTurnedOn = null;
        onScreen.SetActive(false);
        offScreen.SetActive(true);
        //computer.TurnWiringCameraOff();
        wiringCamera.gameObject.SetActive(false);
        onBackgroundObject.SetActive(false);
        isRunningStatusText.gameObject.SetActive(true);
        screen.TurnScreenOff();

    }
}
