using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programs : MonoBehaviour
{
    [SerializeField]
    GameObject program;

    [SerializeField]
    GameObject programParent;

    ProgramListGUI programListGUI;

    VariablesParentGUI variablesGUI;

    [SerializeField]
    GameObject globalVariablesParent;

    [SerializeField]
    Computer computer;



   // [SerializeField]
   // ProgramGUI programGUI;

    [SerializeField]
    GameObject variable;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGUI(ProgramListGUI program, VariablesParentGUI variables){
        programListGUI = program;
        variablesGUI = variables;
    }
    public void CreateNewProgramWithTextField(){

        string name = "";
        if(programListGUI.newProgramName.text == ""){
            name = "Untitled Program";
        }
        else {
            name = programListGUI.newProgramName.text;
        }

        CreateNewProgram(name);

        programListGUI.newProgramName.text = "";
    }

    public void CreateNewProgram(string title){
        GameObject clone;
        clone = Instantiate(program);
        clone.transform.SetParent(programParent.transform, false);
        clone.GetComponent<ProgramableObject>().title = title;
        programListGUI.UpdateList();
    }

    public Variable[] GetAllGlobalVariables(){
        return computer.GetPrograms().globalVariablesParent.GetComponentsInChildren<Variable>();
    }

    public void AddGlobalVariable(string title){
        GameObject clone;
        clone = Instantiate(variable);
        clone.transform.parent = (globalVariablesParent.transform);
        clone.GetComponent<Variable>().variableName = variablesGUI.GetNewVariableName();
        clone.GetComponent<Variable>().SetPrograms(this);
        variablesGUI.Display();
        //programGUI.UpdateGUI();
     }

     public void DeleteGlobalVariable(Variable variable){
         Destroy(variable.gameObject);
         variablesGUI.Display();
         variablesGUI.Display();
     }
     public void DeleteGlobalVariable(string variable){
         Variable v = Array.Find(GetAllGlobalVariables(), x => x.GetName() == variable);
         DeleteGlobalVariable(v);
         
         
     }


     public void MoveVariable(Variable variable, int move){
         TransformHelper.MoveSiblingIndex(variable.transform, move);

     }
     
    public Variable[] GetAllVariables(){
        Variable[] variables = globalVariablesParent.transform.GetComponentsInChildren<Variable>();
        return variables;
        

    }


     public void SetAllVariablesToInitialValues(){
         Variable[] variables = GetAllGlobalVariables();

         foreach(Variable v in variables){
             v.SetToInitialValue();
         }
     }

     public void RunAllPrograms(){
         ProgramableObject[] pos = GetAllPrograms();
         foreach(ProgramableObject po in pos){
             po.StartProgram();
         }

     }

     public ProgramableObject[] GetAllPrograms(){
         return programParent.GetComponentsInChildren<ProgramableObject>();
     }

}
