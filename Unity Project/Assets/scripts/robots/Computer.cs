using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

    [SerializeField]
    public Programs programs;

    [SerializeField]
    public WiringCamera wiringCamera;

    public ComputerGUI computerGUI;
    


    bool updateWiringCamera = false;


    // Start is called before the first frame update
    void Start()
    {
        wiringCamera.SetRobotHead(GetComponent<RobotPart>().robotHead);
        TurnWiringCameraOff();
    }

    // Update is called once per frame
    void Update()
    {
        if(updateWiringCamera){
            wiringCamera.UpdateWiringCamera();
        }
    }

    public Programs GetPrograms(){
        return programs;
    }

    public void AddNewVariable(string name){
        programs.AddGlobalVariable(name);

    }
    public void AddNewProgram(string name){
        programs.CreateNewProgram(name);
    }

    public void TurnWiringCameraOn(){
        wiringCamera.gameObject.SetActive(true);
        wiringCamera.TurnWiringCameraOn();

       
    }

    public void TurnWiringCameraOff(){
        wiringCamera.TurnWiringCameraOff();
        wiringCamera.gameObject.SetActive(false);
    }

  
    
}
