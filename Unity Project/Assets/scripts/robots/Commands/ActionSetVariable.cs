using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetVariable : MonoBehaviour
{

    Command command;

    // Start is called before the first frame update
    void Start()
    {
        command = gameObject.GetComponent<Command>();
    }


    void OnAction() {
        Variable variable = command.GetArgument(1).GetAsVariable();
        float value = command.GetArgumentValue(0);
        variable.SetValue(value);

        command.RunNextCommand();
    }
}
