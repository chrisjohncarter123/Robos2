using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotGUI : EventTrigger
{

    MouseLineGUI mouseLine;
    private bool dragging;
    private NodePutGUI nodePutGUI;


    void Start() {
        nodePutGUI = GetComponent<NodePutGUI>();
        
    }

    public void SetMouseLine(MouseLineGUI mouseLine){
        this.mouseLine = mouseLine;
    }

    public override void OnPointerDown(PointerEventData eventData) {

        Debug.Log(mouseLine);

        if(mouseLine){
            
            dragging = true;
        
            mouseLine.StartMouseLine(nodePutGUI);
        }
        


        
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
        mouseLine.EndMouseLine();

        
    }
    
}
