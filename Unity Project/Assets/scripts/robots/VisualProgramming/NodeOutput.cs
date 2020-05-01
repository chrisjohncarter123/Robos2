using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOutput : MonoBehaviour
{

    public enum OutputType{
        Normal,
        Constant
    }

    public OutputType outputType;
    public NodePut nodePut;

    void Start() {
        nodePut = GetComponent<NodePut>();
    }

    public double GetValue(){
        return nodePut.GetNodePutValue();

    }

    public void SetValue(double value){
        nodePut.SetNodePutValue(value);

    }

    public OutputType GetOutputType(){
        return outputType;

    }
}
