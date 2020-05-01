using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInputFlowGUI : MonoBehaviour
{
    public NodeFlow nodeFlow;
    public NodePut nodePut;


    NodeOutputFlowGUI nodeOutputFlowGUI;
    LineGUI lineGUI;

    public NodeFlow GetNodeFlow(){
        return nodeFlow;
    }


    public void SetNodeFlow(NodeFlow nodeFlow){
        this.nodeFlow = nodeFlow;
        nodeFlow.SetNextNode(nodeFlow.GetNode());
        lineGUI = GetComponent<LineGUI>();
        lineGUI.SetLineColor(Color.green);
        lineGUI.SetLineWidth(4f);
    }

    public void SetOutputFlow(NodeOutputFlowGUI nodeOutputFlowGUI){
        this.nodeOutputFlowGUI = nodeOutputFlowGUI;
        InitOutputFlow();
        
    }

    void InitOutputFlow(){
        nodeOutputFlowGUI.GetOutputFlow().SetNextNode(nodeFlow.GetNode());

        lineGUI.CreateLine();

    }

    void Update() {
        lineGUI.TryUpdateLine(nodeFlow.HasAnOutput(), nodeOutputFlowGUI.GetComponent<RectTransform>());
    }

}
