using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndIfStatement : MonoBehaviour
{
    public bool looping;
    public IfStatement ifStatement;

    Command command;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCommand(){
        if(looping){
            if(ifStatement.TestIfStatement()){
                command.programable.RunCommand(ifStatement.gameObject.GetComponent<Command>());
            } else {
                command.RunNextCommand();
            }
        }else {
            command.RunNextCommand();
        }
    }
}
