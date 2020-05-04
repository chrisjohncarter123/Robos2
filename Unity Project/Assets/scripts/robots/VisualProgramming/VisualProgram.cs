using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgram : MonoBehaviour
{

    public GameObject nodesParent;
    public GameObject nodeTypesParent;
    public GameObject nodeStartTyoe;
    Node startNode;
    Node currentNode;

    bool isRunning = false;

    void StartProgram(){
        currentNode = startNode;
        isRunning = true;
    }

    void EndProgram(){
        isRunning = false;
    }

    void FixedUpdate() {
        if(isRunning){
            RunNextNode();
        }
        
    }

    public Node GetStartNodeType(){
        return nodeStartTyoe.GetComponent<Node>();

    }
    public void SetStartNode(Node startNode){
        this.startNode = startNode;
        
    }

    public void RunProgram(){

    }

    void RunNextNode(){
        currentNode = currentNode.RunNode();

    }

    public Node[] GetAllNodeTypes(){
        return nodeTypesParent.GetComponentsInChildren<Node>();

    }

    public Node[] GetAllNodes(){
        return nodesParent.GetComponentsInChildren<Node>();

    }

    public Node CreateNode(int newNodeIndex){
        Node newNodeType = GetAllNodeTypes()[newNodeIndex].gameObject.GetComponent<Node>();
        return CreateNode(newNodeType);
        


    }
     public Node CreateNode(Node newNodeType){
        GameObject newNodeGameObject = Instantiate(newNodeType.gameObject);
        newNodeGameObject.transform.SetParent(nodesParent.transform);
        return newNodeGameObject.GetComponent<Node>();

     }

    public void DestroyNode(NodeGUI nodeGUI){
        Destroy(nodeGUI.node.gameObject);

    }
}
