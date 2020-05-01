using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInput : MonoBehaviour
{

    
    public NodeOutput nodeOutput;
    public NodePut nodePut;

    void Start() {
        nodePut = GetComponent<NodePut>();
    }

    public void SetOutput(NodeOutput nodeOutput){
        this.nodeOutput = nodeOutput;
    }

    public double GetValue(){
        if(nodeOutput == null){
            return 0;
        }
        return nodeOutput.GetValue();

    }

    public bool HasAnOutput(){
        return (nodeOutput != null);
    }

    public void RemoveCurrentOutput(){
        nodeOutput = null;
    }

}
