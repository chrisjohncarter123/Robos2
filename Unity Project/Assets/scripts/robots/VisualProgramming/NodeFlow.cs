using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFlow : MonoBehaviour
{
    public Node nextNode;
    public NodePut nodePut;

    void Start() {
        nodePut = GetComponent<NodePut>();
    }

    public void SetNextNode(Node nextNode){
        this.nextNode = nextNode;
    }
}
