using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgramGUI : MonoBehaviour
{
    public GameObject newNodeBase;
    public GameObject nodeGUIParent;
    public VisualProgram visualProgram;
    public NewNodeGUI newNodeGUI;
    public MouseLineGUI mouseLine;
    public VisualProgramPositionGUI positionGUI;

    void Start() {
        positionGUI.SetProgramGUI(this);
        
    }


    public void CreateNode(){
        
        Node newNodeObject = visualProgram.CreateNode(newNodeGUI.GetDropdownValue());

        GameObject newNodeGameObject = Instantiate(newNodeBase);

        
        newNodeGameObject.transform.SetParent(nodeGUIParent.transform, false);
        newNodeGameObject.GetComponent<NodeGUI>().SetMouseLine(mouseLine);
        newNodeGameObject.GetComponent<NodeGUI>().InitGUI(newNodeObject);
        newNodeGameObject.GetComponent<NodeGUI>().SetPositionGUI(positionGUI);

    }

    public void DeleteNode(NodeGUI nodeGUI){
        visualProgram.DestroyNode(nodeGUI);
        Destroy(nodeGUI.gameObject);

    }

    public NodeGUI[] GetAllNodes(){
        return GetComponentsInChildren<NodeGUI>();

    }



}
