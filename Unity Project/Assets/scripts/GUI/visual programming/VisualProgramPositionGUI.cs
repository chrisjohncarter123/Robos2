using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VisualProgramPositionGUI : EventTrigger
{
    private bool dragging;
    Vector2 mouseStart;
    Vector2 posStart;
    Vector2 programPosition;
    float scale = .5f;

    float minWidth = 1000;

    float maxWidthExtra = 200;

    VisualProgramGUI programGUI;


    void Start() {
        
    }

    public void SetProgramGUI(VisualProgramGUI programGUI){
        this.programGUI = programGUI;

    }
    public Vector2 GetProgramPosition(){
        return programPosition ;

    }
/*    float GetNodeMinX(){

        int minIndex;
        float min = Mathf.Infinity;
        Node[] allNodes = programGUI.GetAllNodes();
        if(allNodes.Length == 0){
            return -minWidth;
        }
        else{
            foreach(NodeGUI node in programGUI.GetAllNodes()){
                if(node.GetNodePosition().x )

            }
        }

    }
    */

    public void Update() {

        
        if (dragging) {
            Vector2 mouseDifference =
             new Vector2(
                Input.mousePosition.x, Input.mousePosition.y) 
                - mouseStart;
            programPosition = posStart + (mouseDifference * scale) ;
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
        mouseStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        posStart = programPosition;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
    }
}
