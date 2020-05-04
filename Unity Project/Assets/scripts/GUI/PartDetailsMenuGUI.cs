using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartDetailsMenuGUI : MonoBehaviour
{

    public RobotPart robotPart;

    RobotPart selectedPartOnWiringScreen;

    public GameObject wiringPartGUIList;

    public GameObject wiringPartGUIParent;

    public GameObject partDetailGUIParent;

    public ComputerScreen screen;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPart(RobotPart robotPart){
        foreach(WiringPartGUI wiring in wiringPartGUIList.GetComponentsInChildren<WiringPartGUI>()){
            if(wiring.robotPart == robotPart){
                DisplayWiringPart(wiring, robotPart);
               
                return;
            }

        }

        WiringPartGUI newPart = CreateNewWiringPart(robotPart);
        hasAWiringPart = true;
        DisplayWiringPart(newPart, robotPart);
        
    }
    public void SetToBlank(){
        foreach(WiringPartGUI wiring in wiringPartGUIList.GetComponentsInChildren<WiringPartGUI>()){
            wiring.SetWiringActive(false);

        }
    }
    
    public void CloseMenu(){
       // wiringPartGUI.CloseMenu();
    }
    

    bool hasAWiringPart = false;

    void DisplayWiringPart(WiringPartGUI wiringPartGUI, RobotPart robotPart){
        if(hasAWiringPart){
            SetToBlank();
        }
        

        wiringPartGUI.SetWiringActive(true);
        screen.robotPart = robotPart;
        

    }
    WiringPartGUI CreateNewWiringPart(RobotPart robotPart){
        GameObject newWiringPartGUI = Instantiate(wiringPartGUIParent);
        newWiringPartGUI.transform.SetParent(wiringPartGUIList.transform, false);
        newWiringPartGUI.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        WiringPartGUI wiringGUI = newWiringPartGUI.GetComponent<WiringPartGUI>();
        wiringGUI.SetRobotPart(robotPart);

        
        wiringGUI.InitDetails(robotPart, partDetailGUIParent);
        

        return wiringGUI;

    }

    public void SetPrograms(Programs programs){

    }
}
