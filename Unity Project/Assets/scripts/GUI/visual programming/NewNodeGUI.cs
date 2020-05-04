using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewNodeGUI : MonoBehaviour
{

    public VisualProgram visualProgram;
    public Dropdown dropdown;
    Node[] allNodeTypes;
    
    void Start() {
        //clear/remove all option item
        dropdown.options.Clear ();
        allNodeTypes = visualProgram.GetAllNodeTypes();
        
        //fill the dropdown menu OptionData with all COM's Name in ports[]
        foreach (Node node in allNodeTypes) 
        {
            dropdown.options.Add (new Dropdown.OptionData() {text=node.GetNodeTitle()});
        }
        //this swith from 1 to 0 is only to refresh the visual DdMenu
        dropdown.value = 1;
        dropdown.value = 0;
    }

    public Node GetDropdownNode(){
        return allNodeTypes[dropdown.value];

    }

}
