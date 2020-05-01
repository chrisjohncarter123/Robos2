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
        if(nodeOutputGUI){
            Debug.Log(nodeOutputGUI.GetComponent<RectTransform>().rect.x.ToString() + " " + nodeOutputGUI.GetComponent<RectTransform>().rect.y.ToString());
            lineGUI.TryUpdateLine(
                nodeInput.HasAnOutput(),
                nodeOutputGUI.transform.position);
        }
        else {
            lineGUI.TryDestroyLine();
        }
    }
    public NodeInput GetNodeInput(){
        return nodeInput;
    }

}
