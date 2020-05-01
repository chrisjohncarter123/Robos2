using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInputFlowGUI : MonoBehaviour
{
    public NodeFlow nodeFlow;
    public NodePut nodePut;


    NodeOutputFlowGUI nodeOutputFlowGUI;


    public NodeFlow GetNodeFlow(){
        return nodeFlow;
    }


    public void SetNodeFlow(NodeFlow nodeFlow){
        this.nodeFlow = nodeFlow;
        
    }

    /*
    public void SetOutputFlowGUI(NodeOutputFlowGUI nodeOutputFlowGUI){
        this.nodeOutputFlowGUI = nodeOutputFlowGUI;
        
    }
    */
}
