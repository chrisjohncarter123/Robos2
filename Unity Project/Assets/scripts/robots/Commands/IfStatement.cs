using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfStatement : MonoBehaviour
{

    Command command;

    public EndIfStatement endIfStatement;
    // Start is called before the first frame update

    void Start()
    {
        command = gameObject.GetComponent<Command>();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void RunCommand(){
        if(TestIfStatement()){
            command.RunNextCommand();
        } else {
            command.GoToNextEndIf();
        }
    }

    public bool TestIfStatement(){
        float a = command.GetArgumentValue(0);
        int comparerType = (int)command.GetArgumentValue(1);
        float b = command.GetArgumentValue(2);
        switch (comparerType){
            case (int)Argument.ComparerType.GreaterThan:
                return a > b;

            break;

            case (int)Argument.ComparerType.EqualTo:
                return a == b;

            break;

            case (int)Argument.ComparerType.LessThan:
                return a < b;

            break;

        }

        Debug.LogError("Invalid comparerType for ifstatement");
        return false;

    }
}
