using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{

    [SerializeField]
    public string commandName;

    [SerializeField]
    public Argument[] arguments;

    public ProgramableObject programable; 


    public void SetProgramableObject(ProgramableObject p){
        programable = p;
    }
    public void RunCommand(){
        gameObject.SendMessage("OnAction");
    }
    public void RunNextCommand(){
        programable.RunNextCommand();

    }

    public void GoToNextEndIf(){
        programable.GoToNextEndIf();
    }

    public bool IsAnEndIf(){
        return (bool)GetComponent<EndIfStatement>();
    }

    public bool IsAnIf(){
        return (bool)GetComponent<IfStatement>();
    }

    public Argument GetArgument(int index){
        return arguments[index];
    }

    public float GetArgumentValue(int index){
        return arguments[index].GetValue();
    }

    public string GetArgumentValueString(int index){
        return arguments[index].GetValueString();
    }

    public void MoveUp(){
        programable.MoveCommandUp(this);

    }
    public void MoveDown(){
        programable.MoveCommandDown(this);

    }
    public void Delete(){
        programable.DeleteCommand(this);

    }

    



}
