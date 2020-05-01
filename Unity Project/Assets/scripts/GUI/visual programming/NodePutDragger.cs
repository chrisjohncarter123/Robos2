using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodePutDragger : EventTrigger
{

    bool dragParent = true;

    private bool dragging;
    Vector2 mouseStart;
    Vector2 posStart;

    static NodePut currentNodePut;
    

    void Start() {

        
    }

    public void Update() {
        if (dragging) {
            Vector2 mouseDifference = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - mouseStart;
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
        mouseStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        posStart = transform.position;

         if(currentNodePut == null){
             currentNodePut = GetComponent<NodePut>();
         }
    }

    public override void OnPointerUp(PointerEventData eventData) {

        dragging = false;
        Debug.Log("Here");

        if(currentNodePut != null){
            Debug.Log("Here");
            if(currentNodePut != GetComponent<NodePut>()){
                Debug.Log("Here");
                if(currentNodePut.GetComponent<NodeInputGUI>()){
                    Debug.Log("Here");
                    if(GetComponent<NodeOutputGUI>()){
                        Debug.Log("Here");
                        if(GetComponent<NodePutGUI>().GetNode() != currentNodePut.GetComponent<NodePutGUI>().GetNode()){
                            currentNodePut.GetComponent<NodeInputGUI>().GetNodeInput().SetOutput(GetComponent<NodeOutputGUI>().GetNodeOutput());
                            currentNodePut = null;
                            Debug.Log("Connected ");
                        }
                    }    
                }
            }
        }




        if(currentNodePut != null){
            if(currentNodePut != GetComponent<NodePut>()){
                if(currentNodePut.GetComponent<NodeOutputGUI>()){
                    if(GetComponent<NodeOutputGUI>()){
                        if(GetComponent<NodePutGUI>().GetNode() != currentNodePut.GetComponent<NodePutGUI>().GetNode()){
                            GetComponent<NodeInputGUI>().GetNodeInput().SetOutput(currentNodePut.GetComponent<NodeOutputGUI>().GetNodeOutput());
                            currentNodePut = null;
                            Debug.Log("Connected ");
                        }
                    }    
                }
            }
        }
    }
    public override void OnPointerEnter(PointerEventData eventData) {

        
    }

    public override void OnPointerExit(PointerEventData eventData) {

        
    }

}
