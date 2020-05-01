using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHead : MonoBehaviour
{
    static int robotHeadCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetRobotLayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static RobotHead CreateNewRobotHead(){
        GameObject newRobot = new GameObject();
        newRobot.name = "Robot Head " + robotHeadCounter++;
        return newRobot.AddComponent<RobotHead>();
        

    }

    public void AddRobotPartgroup(PartGroup partGroup){
        partGroup.transform.SetParent(transform);

        foreach(RobotPart rp in partGroup.GetComponentsInChildren<RobotPart>()){
            rp.robotHead = (this);

        }

    }

    public void SetWiringLayer(){
        foreach(RobotPart rp in GetComponentsInChildren<RobotPart>()){
            rp.SetWiringLayer();
        }

    }
    public void SetRobotLayer(){
        foreach(RobotPart rp in GetComponentsInChildren<RobotPart>()){
            rp.SetRobotLayer();
        }

    }

    public Programs[] GetAllPrograms(){
        return GetComponentsInChildren<Programs>();

    }
    public bool HasAComputer(){
        return (GetAllPrograms().Length > 0);
    }

    public void AddComputer(){
        

    }
    public void RemoveComputer(){
        foreach(PartDetail detail in GetComponentsInChildren<PartDetail>()){
            detail.ResetVariables();
        }
    }

    

}
