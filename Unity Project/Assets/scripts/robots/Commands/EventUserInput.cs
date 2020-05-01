using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUserInput : MonoBehaviour
{

    // Start is called before the first frame update
    Command command;

    bool running = false;
    void Start()
    {
        command = gameObject.GetComponent<Command>();
    }
    // Update is called once per frame
    void Update()
    {
        if(running){
            if(Input.GetKeyDown(command.GetArgumentValueString(0))){
                command.RunNextCommand();
                running = false;
            }
        }


    }

    void OnAction() {
        running = true;
    }

    void StopCommand(){
        running = false;
    }
}
