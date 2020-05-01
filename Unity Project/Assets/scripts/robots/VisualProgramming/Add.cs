using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{

    Node node;

    public void InitNode(){
        


    }

    public void RunNode(Node node){

        this.node = node;

        double a = node.GetInput(0);
        double b = node.GetInput(1);

        node.SetOutput(0, a + b);

        node.SetOutputFlow(0);

    }
}
