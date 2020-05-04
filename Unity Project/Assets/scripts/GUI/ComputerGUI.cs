using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerGUI : MonoBehaviour
{

    public Computer computer;

    [SerializeField]
    ProgramableObject programmableObject;

    [SerializeField]
    GameObject computerScreen;


    [SerializeField]
    ProgramListGUI programListGUI;

    [SerializeField]
    VariablesParentGUI variablesGUI;

    [SerializeField]
    ProgramGUI programGUI;


    [SerializeField]
    GameObject variablesPage;
    

    [SerializeField]
    GameObject functionsPage;

    [SerializeField]
    GameObject wiringPage;

    [SerializeField]
    WiringCamera wiringCamera;

    [SerializeField]
    RobotPart robotPart;

    [SerializeField]
    GameObject robotWiringPartParentGUI;

    [SerializeField]
    float wiringScreenRotation = 1;

    [SerializeField]
    GameObject runProgramButton;


    [SerializeField]
    RobotOnOffButtons onOffButtonsGUI;

    public TurnComputerScreenOnOffGUI onOffGUI;

    public ComputerScreen screen;




    Vector3 dragStart;


    

    // Start is called before the first frame update
    void Start()
    {
        SetComputer();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    /*
    public void TurnScreenOn(){
        onOffButtonsGUI.OnOnButton();
    }
    */

/*
    public void SetVariablesTab(){
        variablesPage.SetActive(true);
        functionsPage.SetActive(false);
    //    wiringPage.SetActive(false);
    //    programListGUI.TurnOffSelectedProgrammableObject();

    }
    */
    public void SetFunctionsTab(){
      //  variablesPage.SetActive(false);
        functionsPage.SetActive(true);
        wiringPage.SetActive(false);

   //programListGUI.TurnOffSelectedProgrammableObject();
   //     programListGUI.TurnOffSelectedProgrammableObject();


        programGUI.SetSingleProgram(programmableObject); 

        programGUI.SetSingleProgram(programmableObject); 

       // programListGUI.SetSelectedProgrammableObject(programmableObject);
        

    

    }

    public void SetWiringTab(){
       // variablesPage.SetActive(false);
        functionsPage.SetActive(false);
        wiringPage.SetActive(true);
        //programListGUI.TurnOffSelectedProgrammableObject();


   
        wiringCamera.SetRobotHead(robotPart.robotHead);
       

    }

    public void UpdateComputerGUI(){
        SetComputer();

    }

    public void SetComputer(){

        computer.GetPrograms().SetGUI(programListGUI, variablesGUI);

       // variablesGUI.Display();
        //programListGUI.TurnOffSelectedProgrammableObject();

        //programGUI.TurnOffSelf();

    }

    public void AddNewVariable(){


        string title = "New Variable";
        computer.AddNewVariable(title);
        
        UpdateVariablesDropdownLists();

    }

    void UpdateVariablesDropdownLists(){
        foreach(CommandGUI c in gameObject.GetComponentsInChildren<CommandGUI>()){
                c.UpdateVariablesDropdownLists();
        }
    }

    public void AddNewProgram(){
        string title = "New Program";
        computer.AddNewProgram(title);

    }

    public void AddWiringPartGUI(RobotPart robotPart){
        GameObject newWiringPartGUI =  Instantiate (robotPart.GetWiringGUI() );
        newWiringPartGUI.transform.SetParent(robotWiringPartParentGUI.transform);
       

    }


    public void OnStartWiringDrag(){

        dragStart = Input.mousePosition;



    }
    public void OnEndWiringDrag() {

        

    }

    public void UpdateWiringDrag(){
        Vector3 change = Input.mousePosition - dragStart;
        wiringCamera.UpdateWiringCameraRotation(change);

    }

    public void OnProgramEnd(){
        onOffButtonsGUI.OnProgramEnd();

    }


    

    
}
