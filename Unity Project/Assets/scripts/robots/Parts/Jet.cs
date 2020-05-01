using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidBody;

    Command command;

    public PartDetail input;
    public PartDetail output;

    // Start is called before the first frame update
    void Start()
    {
        command = gameObject.GetComponent<Command>();
    }


    void Update() {
        float inputValue = input.GetInputValue();
        Vector3 force = new Vector3(  0, inputValue, 0);
        rigidBody.AddForce(force);
        command.RunNextCommand();

        output.SetOutputValue(transform.position.y);
    }
}
