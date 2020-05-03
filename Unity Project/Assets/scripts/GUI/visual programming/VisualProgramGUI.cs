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
    public VisualProgramScalerGUI scalerGUI;

    void Start() {
        positionGUI.SetProgramGUI(this);
        CreateNode();
        
    }

    public VisualProgramScalerGUI GetVisualProgramScalerGUI(){
        return scalerGUI;
    }

    public void CreateNode(GameObject newNodeGameObject){
        Node newNodeObject = visualProgram.CreateNode(newNodeGUI.GetDropdownValue());

        GameObject newNodeGameObject = Instantiate(newNodeBase);

        
        newNodeGameObject.transform.SetParent(nodeGUIParent.transform, false);
        newNodeGameObject.GetComponent<NodeGUI>().SetMouseLine(mouseLine);
        newNodeGameObject.GetComponent<NodeGUI>().InitGUI(newNodeObject);
        newNodeGameObject.GetComponent<NodeGUI>().SetPositionGUI(positionGUI);
    }

    public void CreateNode(){
    //    CreateNode
        
        

    }

    public void DeleteNode(NodeGUI nodeGUI){
        visualProgram.DestroyNode(nodeGUI);
        Destroy(nodeGUI.gameObject);

    }

    public NodeGUI[] GetAllNodes(){
        return GetComponentsInChildren<NodeGUI>();

    }



}
