using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeOutputFlowGUI : MonoBehaviour
{
    NodeFlow nodeFlow;
    public NodePut nodePut;

    NodeInputFlowGUI nodeInputFlowGUI;

    public void SetNodeFlow(NodeFlow nodeFlow){
        this.nodeFlow = nodeFlow;
    }

    public NodeFlow GetOutputFlow(){
        return nodeFlow;
    }

    public void SetNodeInputFlow(NodeInputFlowGUI nodeInputFlowGUI){
        this.nodeInputFlowGUI = nodeInputFlowGUI;
        nodeFlow.SetNextNode(nodeInputFlowGUI.GetNodeFlow().GetNode());

    }
}
