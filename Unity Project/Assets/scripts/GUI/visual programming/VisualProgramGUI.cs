using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgramGUI : MonoBehaviour
{
    public GameObject newNodeBase;
    public GameObject nodeGUIParent;
    public VisualProgram visualProgram;
    public NewNodeGUI newNodeGUI;


    public void CreateNode(){
        
        Node newNodeObject = visualProgram.CreateNode(newNodeGUI.GetDropdownValue());

        GameObject newNodeGameObject = Instantiate(newNodeBase);

        
        newNodeGameObject.transform.SetParent(nodeGUIParent.transform);
        newNodeGameObject.GetComponent<NodeGUI>().InitGUI(newNodeObject);

    }

    public void DeleteNode(NodeGUI nodeGUI){
        visualProgram.DestroyNode(nodeGUI);
        Destroy(nodeGUI.gameObject);

    }
}
