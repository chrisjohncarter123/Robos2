using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopStatement : MonoBehaviour
{
    Command command;

    public bool infinity = false;

    int currentCount = 0;
    // Start is called before the first frame update

    void Start()
    {
        command = gameObject.GetComponent<Command>();
        currentCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAction(){
        int count = (int)command.GetArgumentValue(0);

        if(currentCount < count){
            currentCount += 1;
            command.programable.SetIsLooping(true);

        }
        else {
            command.programable.SetIsLooping(false);

        }
        
        command.RunNextCommand();
    }
}
