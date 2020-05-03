using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInputGUI : MonoBehaviour
{
    NodePutGUI nodePutGUI;
    NodeInput nodeInput;
    RectTransform rectTransform;

    NodeOutputGUI nodeOutputGUI;

    LineGUI lineGUI;

    PutLineGUI putLineGUI;

    void Start() {
        nodePutGUI = GetComponent<NodePutGUI>();

        putLineGUI = GetComponent<PutLineGUI>();
        putLineGUI.SetPut(nodePutGUI);
    }


    public void SetNodeInput(NodeInput nodeInput){
        this.nodeInput = nodeInput;
        nodePutGUI = gameObject.GetComponent<NodePutGUI>();
        
    }

    public void SetNodeOutput(NodeOutputGUI nodeOutputGUI){
        if (putLineGUI.GetIsDrawing()){
            putLineGUI.EndLine();
        }
        nodeInput.SetOutput(nodeOutputGUI.GetNodeOutput());
        this.nodeOutputGUI = nodeOutputGUI;
        putLineGUI.StartLine(
            nodeOutputGUI.GetComponent<NodePutGUI>());
        putLineGUI.SetLineParent(nodePutGUI.transform);
        

    }



    void Update(){
        if(nodeInput.HasAnOutput()){
            
        } else if (putLineGUI.GetIsDrawing()){
            putLineGUI.EndLine();
            nodeOutputGUI = null;
        }
    }

    public NodeInput GetNodeInput(){
        return nodeInput;
    }

}
