using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionVariableMath : MonoBehaviour
{
    Command command;

    public enum Operation{
        Add,
        Sub,
        Mult,
        Div,
        Power,
        Sin,
        Cos,
        Sqrt,
        Abs

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

            case Operation.Sin:
                result = Mathf.Sin(b);

            break;

            case Operation.Cos:
                result = Mathf.Cos(b);

            break;

            case Operation.Abs:
                result = Mathf.Abs(b);

            break;

            case Operation.Sqrt:

                if(b < 0){
                    result = 0;
                }
                result = Mathf.Sqrt(b);

            break;
        }


        return result;
    }
}
