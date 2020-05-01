using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInputGUI : MonoBehaviour
{
    NodeInput nodeInput;
    public NodePut nodePut;

    NodeOutputGUI nodeOutputGUI;
    LineGUI lineGUI;

    public void SetNodeInput(NodeInput nodeInput){
        this.nodeInput = nodeInput;
        lineGUI = gameObject.AddComponent<LineGUI>();
    }

    void Update() {
        if(nodeInput.HasAnOutput()){
            Vector2 outputPos = new Vector2(
                 nodeOutputGUI.GetComponent<RectTransform>().anchoredPosition.x,
                 nodeOutputGUI.GetComponent<RectTransform>().anchoredPosition.y);

            lineGUI.UpdateLine(outputPos);
        }
    }
    public NodeInput GetNodeInput(){
        return nodeInput;
    }

}
