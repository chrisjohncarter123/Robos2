using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePut : MonoBehaviour
{
    public string title;
    public double value;


    public Node node;
    public string GetNodePutTitle(){
        return title;
    }

    public double GetNodePutValue(){
        return value;
    }

    public void SetNodePutValue(double value){
        this.value = value;
    }

    public void SetNode(Node node){
        this.node = node;
    }
    public Node GetNode(){
        return node;

    }

}
