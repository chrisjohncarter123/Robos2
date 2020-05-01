using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOnTime : MonoBehaviour
{

    float time;

    float finishTime;

    bool running;

    Command command;
    // Start is called before the first frame update

    void Start()
    {
        command = gameObject.GetComponent<Command>();
    }
    // Update is called once per frame
    void Update()
    {
        if(running){
            if(Time.time >= finishTime){
                running = false;
                command.RunNextCommand();
                
            }
        }


    }

    void OnAction() {
        time = command.GetArgumentValue(0);
        finishTime = Time.time + time;
        running = true;

    }

    void StopCommand(){
        running = false;
    }
}
