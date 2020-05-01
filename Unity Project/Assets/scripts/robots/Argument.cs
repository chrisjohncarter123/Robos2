using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Argument : MonoBehaviour
{

    public string title;
    public string initialConstantValue;

    string value;

    public Variable variable;
    public ArgumentType argumentType;

    public ArgumentGUI.DisplayForm displayForm = ArgumentGUI.DisplayForm.Normal;


    public AssignmentType assignmentType = AssignmentType.Input;

    public enum ArgumentType{
        Constant,
        Variable,
        Comparer
    }

    public enum AssignmentType{
        Input,
        Output
    }

    public enum ComparerType{
        GreaterThan = 0,
        EqualTo = 1,
        LessThan = 2
    }
    
    // Start is called before the first frame update
    void Start()
    {
        value = initialConstantValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVariable(Variable variable){
        argumentType = ArgumentType.Variable;
        this.variable = variable;

    }

    public void SetConstant(float value){
        argumentType = ArgumentType.Constant;
        this.value = value.ToString();

    }

    public float GetValue(){
        if(value == null){
            return 0;
        }

        switch (argumentType){
            case ArgumentType.Constant:
                return float.Parse(value);
            break;
             case ArgumentType.Variable:
                if(variable == null) {
                    return 0;
                }
                else {
                    return variable.GetValue();
                } 
            break;

        }  
        return 0;

    }

    public string GetValueString(){
        return value;
    }

    public void SetValue(string value){
        this.value = value;

    }
    public void SetValue(float value){
        this.value = value.ToString();
    }

    public void SetVariableValue(float value){
        variable.SetValue(value);
    }

    public Variable GetAsVariable(){
        return variable;
        
    } 
}
