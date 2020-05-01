using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string title;
    public GameObject nodeGameObject;
    public NodeFlow inputFlow;
    public NodeFlow[] outputFlows;
    public NodeInput[] inputs;
    public NodeOutput[] outputs;

    NodeFlow nextFlow;

    void Start() {
        foreach(NodePut n in GetComponentsInChildren<NodePut>()){
            n.SetNode(this);

        }
    }

   
    public string GetNodeTitle(){
        return title;
    }
    public Node RunNode(){

        nextFlow = outputFlows[0];

        nodeGameObject.SendMessage("RunNode", this);

        return nextFlow.nextNode;

    }

    public double GetInput(int index){
        return inputs[index].GetValue();
    }

    public void SetOutput(int index, double value){
        outputs[index].SetValue(value);
    }

    public void SetOutputFlow(int index){
        nextFlow = outputFlows[index];

    }


}
