using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAddToVariable : MonoBehaviour
{
    Command command;

    public enum Operation{
        Add,
        Sub,
        Mult,
        Div,
        Power

    }

    public Operation operation;

    // Start is called before the first frame update
    void Start()
    {
        command = gameObject.GetComponent<Command>();
    }


    void OnAction() {
        Variable variable = command.GetArgument(1).GetAsVariable();
        float variableValue = variable.GetValue();
        float value = command.GetArgumentValue(0);
        variable.SetValue( DoOperation(variableValue, value));

        command.RunNextCommand();
    }

    float DoOperation(float a, float b){
        float result = 0;
        switch(operation){
            case Operation.Add:
                result = a + b;

            break;

            case Operation.Sub:
                result = a - b;

            break;

            case Operation.Mult:
                result = a * b;

            break;

            case Operation.Div:

                if(b == 0){
                    result = 0;
                }
                else {
                    result = a / b;
                }
            

            break;

            case Operation.Power:
                result = Mathf.Pow(a, b);

            break;
        }


        return result;
    }
}
