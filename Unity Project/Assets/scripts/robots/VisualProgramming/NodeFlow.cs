using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFlow : MonoBehaviour
{
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
        Debug.Log(nodePut);
        Debug.Log(nodePut.GetNode());
        return nodePut.GetNode();
    }

    public NodePut GetNodePut(){
        return nodePut;
    }

    public void SetNodePut(NodePut nodePut){
        this.nodePut = nodePut;
    }

    public bool HasANextNode(){
        return nextNode != null;
    }



}
