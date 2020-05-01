using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandType : MonoBehaviour
{
    [SerializeField]
    public GameObject command;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string GetCommandNameType(){
        return command.GetComponent<Command>().commandName;
    }

    public GameObject CreateCommand(){
        GameObject clone = Instantiate(command);

        return clone;

    }
}
