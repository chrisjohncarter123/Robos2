using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeOutputFlowGUI : MonoBehaviour
{
    NodeFlow nodeFlow;
    public NodePut nodePut;

    public void SetNodeFlow(NodeFlow nodeFlow){
        this.nodeFlow = nodeFlow;
    }
}
