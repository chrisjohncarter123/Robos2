using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFlow : MonoBehaviour
{
    Node node;
    Node nextNode;
    NodePut nodePut;

    void Start() {
        nodePut = GetComponent<NodePut>();
    }

    public Node GetNextNode(){
        return nextNode;
    }
    public void SetNextNode(Node nextNode){
        this.nextNode = nextNode;
    }

    public Node GetNode(){
        return node;
    }

    public void SetNode(Node node){
        this.node = node;
    }

    public NodePut GetNodePut(){
        return nodePut;
    }

    public void SetNodePut(NodePut nodePut){
        this.nodePut = nodePut;
    }

    public bool HasAnOutput(){
        return nextNode != null;
    }



}
