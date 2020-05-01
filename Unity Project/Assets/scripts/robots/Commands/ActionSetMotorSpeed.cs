using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetMotorSpeed : MonoBehaviour
{
    [SerializeField]
    ProgramableObject po;

    [SerializeField]
    Motor motor;

    // Start is called before the first frame update
   Command command;

    // Start is called before the first frame update
    void Start()
    {
        command = gameObject.GetComponent<Command>();
    }


    void OnAction() {
        

        motor.SetSpeed( command.GetArgumentValue(0) );
        command.RunNextCommand();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
