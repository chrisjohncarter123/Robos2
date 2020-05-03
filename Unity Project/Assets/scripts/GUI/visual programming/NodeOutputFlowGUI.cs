using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeOutputFlowGUI : MonoBehaviour
{
    NodeFlow nodeFlow;
    NodePutGUI nodePutGUI;

    NodeInputFlowGUI nodeInputFlowGUI;
    PutLineGUI putLineGUI;



    void Start() {

        nodePutGUI = GetComponent<NodePutGUI>();

        putLineGUI = GetComponent<PutLineGUI>();
        
    }

    public void SetNodeFlow(NodeFlow nodeFlow){
        this.nodeFlow = nodeFlow;
        
    }

    public NodeFlow GetOutputFlow(){
        return nodeFlow;
    }

    public void SetNodeInputFlow(NodeInputFlowGUI nodeInputFlowGUI){
        this.nodeInputFlowGUI = nodeInputFlowGUI;
        nodeFlow.SetNextNode(nodeInputFlowGUI.GetNodeFlow().GetNode());
        putLineGUI.SetPut(nodePutGUI) ;
        putLineGUI.StartLine(nodeInputFlowGUI.GetComponent<NodePutGUI>());
        
        putLineGUI.SetLineParent(nodeInputFlowGUI.transform);
        
        
    }

    void Update(){
        if(nodeFlow.HasANextNode()){
            
        } else if (putLineGUI.GetIsDrawing()){
            putLineGUI.EndLine();
        }
    }
}
