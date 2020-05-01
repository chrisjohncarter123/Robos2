using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDetail : MonoBehaviour


{

    public string title;
    public string description;

    public PartDetailType detailType;

    public enum PartDetailType{
        Input,
        Output
    }

    Variable variable;

    public RobotPart robotPart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public RobotPart GetRobotPart(){
        return robotPart;
    }
    public Argument GetArgument(){
        return GetComponent<Argument>();
    }
    public void SetRobotPart(RobotPart robotPart){
        this.robotPart = robotPart;
    }
    public float GetInputValue(){
        if(variable){
            return variable.GetValue();

        }
        return 0;
        
    }
    public void ResetVariables(){

    }

    public void SetOutputValue(float value){
        variable.SetValue(value);
    }

    public void SetVariable(Variable variable){
        this.variable = variable;
        
    }

    public RobotHead GetRobotHead(){
        return robotPart.robotHead;

    }
}
