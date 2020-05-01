using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeOutputFlowGUI : MonoBehaviour
{
    NodeFlow nodeFlow;
    public NodePut nodePut;

    NodeInputFlowGUI nodeInputFlowGUI;

    bool isDrawing = false;

        LineGUI lineGUI;



    public void SetNodeFlow(NodeFlow nodeFlow){
        this.nodeFlow = nodeFlow;
        lineGUI = GetComponent<LineGUI>();
        lineGUI.SetLineColor(Color.green);
        lineGUI.SetLineWidth(4f);
        
    }

    public NodeFlow GetOutputFlow(){
        return nodeFlow;
    }

    public void SetNodeInputFlow(NodeInputFlowGUI nodeInputFlowGUI){
        Debug.Log("HEERE");
        this.nodeInputFlowGUI = nodeInputFlowGUI;
        nodeFlow.SetNextNode(nodeInputFlowGUI.GetNodeFlow().GetNode());
        lineGUI.CreateLine();
        
    }

    void Update() {
        
        if(nodeFlow && nodeInputFlowGUI){
            Debug.Log("HEERE2");

            if(!lineGUI.GetIsDrawing()){
                lineGUI.CreateLine();
                Debug.Log("HEERE3");

            }
            Debug.Log(nodeInputFlowGUI.transform.position);


            lineGUI.TryUpdateLine(
                nodeFlow.HasANextNode(),
                 nodeInputFlowGUI.transform.position);

        }
        else {
            lineGUI.TryDestroyLine();
        }
    }
}
