using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInputGUI : MonoBehaviour
{
    NodeInput nodeInput;
    public NodePut nodePut;
    RectTransform rectTransform;

    NodeOutputGUI nodeOutputGUI;
    LineGUI lineGUI;

    public void SetNodeInput(NodeInput nodeInput){
        this.nodeInput = nodeInput;
        lineGUI = GetComponent<LineGUI>();
        lineGUI.SetLineColor(Color.green);
        lineGUI.SetLineWidth(4f);
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetNodeOutput(NodeOutputGUI nodeOutputGUI){
        nodeInput.SetOutput(nodeOutputGUI.GetNodeOutput());
        this.nodeOutputGUI = nodeOutputGUI;
        lineGUI.CreateLine();
        
    }


    void Update() {
        lineGUI.TryUpdateLine(nodeInput.HasAnOutput(), nodeOutputGUI.GetComponent<RectTransform>());
    }
    public NodeInput GetNodeInput(){
        return nodeInput;
    }

}
