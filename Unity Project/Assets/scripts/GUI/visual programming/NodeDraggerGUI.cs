using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeDraggerGUI : EventTrigger {

    private bool dragging;
    Vector2 mouseStart;
    Vector2 posStart;

    NodeGUI nodeGUI;

    void Start() {
        nodeGUI = GetComponent<NodeGUI>();
     
        
    }

    public void Update() {
        if (dragging) {


            Vector2 mouseDifference 
                = new Vector2(
                    Input.mousePosition.x,
                    Input.mousePosition.y) 
                - mouseStart;

                float scale = VisualProgramScalerGUI.GetCurrentScale();

                mouseDifference /= scale;
            nodeGUI.SetNodePosition(posStart + mouseDifference);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
         if (eventData.button == PointerEventData.InputButton.Left) {
            dragging = true;
            mouseStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            posStart = nodeGUI.GetNodePosition();
         }
     
        
    }

    public override void OnPointerUp(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            if(dragging){
                dragging = false;
            }

        }

        
    }




}

