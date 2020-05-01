using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgram : MonoBehaviour
{

    public GameObject nodesParent;
    public GameObject nodeTypesParent;
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
        GameObject newNodeType = GetAllNodeTypes()[newNodeIndex].gameObject;
        GameObject newNodeGameObject = Instantiate(newNodeType);
        newNodeGameObject.transform.SetParent(nodesParent.transform);
        return newNodeGameObject.GetComponent<Node>();


    }
    public void DestroyNode(NodeGUI nodeGUI){
        Destroy(nodeGUI.node.gameObject);

    }
}
