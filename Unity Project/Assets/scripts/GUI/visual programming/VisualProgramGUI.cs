using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgramGUI : MonoBehaviour
{
    public GameObject newNodeGUIBase;
    public GameObject nodeGUIParent;
    public VisualProgram visualProgram;
    public NewNodeGUI newNodeGUI;
    public MouseLineGUI mouseLine;
    public VisualProgramPositionGUI positionGUI;
    public VisualProgramScalerGUI scalerGUI;
    NodeGUI startNodeGUI;
    Node startNode;

    void Start() {
        positionGUI.SetProgramGUI(this);
        CreateStartNode();
        
    }

    public VisualProgramScalerGUI GetVisualProgramScalerGUI(){
        return scalerGUI;
    }

    public void CreateNode(Node newNodeBase, out NodeGUI newNodeGUI, out Node newNode){
        newNode = visualProgram.CreateNode(newNodeBase);

        GameObject newNodeGUIObject = Instantiate(newNodeGUIBase);
        newNodeGUIObject.transform.SetParent(nodeGUIParent.transform, false);
        newNodeGUIObject.GetComponent<NodeGUI>().SetMouseLine(mouseLine);
        newNodeGUIObject.GetComponent<NodeGUI>().InitGUI(newNode);
        newNodeGUIObject.GetComponent<NodeGUI>().SetPositionGUI(positionGUI);
        newNodeGUI = newNodeGUIObject.GetComponent<NodeGUI>();

    }

    public NodeGUI CreateNode(Node newNodeBase){
        NodeGUI newNodeGUI;
        Node newNode;
        CreateNode(newNodeBase, out newNodeGUI, out newNode);
        return newNodeGUI;

        
    }

    public void CreateNodeFromDropdown(){
        Node newNode = (newNodeGUI.GetDropdownNode());
        CreateNode(newNode);
        
    }

    void CreateStartNode(){

        CreateNode(visualProgram.GetStartNodeType(), out startNodeGUI, out startNode);
        startNodeGUI.SetCanBeDeleted(false);
        visualProgram.SetStartNode(startNode);

    }

    public void RunProgram(){
        visualProgram.RunProgram();
    }

    public void DeleteNode(NodeGUI nodeGUI){
        visualProgram.DestroyNode(nodeGUI);
        Destroy(nodeGUI.gameObject);

    }

    public NodeGUI[] GetAllNodes(){
        return GetComponentsInChildren<NodeGUI>();

    }



}
