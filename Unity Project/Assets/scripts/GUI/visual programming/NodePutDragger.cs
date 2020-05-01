using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodePutDragger : EventTrigger, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    bool dragParent = true;
    RectTransform rectTransform;
    LineGUI lineGUI;

    private bool dragging;
    Vector2 mouseStart;
    Vector2 posStart;

    static NodePutDragger currentNodePutDragger;
    static NodePutDragger hoveringNodePutDragger;


    

    void Start() {
        lineGUI = GetComponent<LineGUI>();
        rectTransform = GetComponent<RectTransform>();


        
    }

    public void Update() {
        if (dragging) {
           if(lineGUI.GetIsDrawing() == false){
               CreateLine();

           }
            lineGUI.UpdateLine(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    void CreateLine(){
         Vector2 start = rectTransform.anchoredPosition;
        lineGUI.CreateLine(start, 3, Color.red);
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;

        Debug.Log("Here");
       

        CreateLine();

         if(currentNodePutDragger == null){
             currentNodePutDragger = this;
         }
    }

    public override void OnPointerUp(PointerEventData eventData) {

        lineGUI.DestroyLine();

        dragging = false;
        Debug.Log(currentNodePutDragger + "     " + hoveringNodePutDragger);


        if(currentNodePutDragger && hoveringNodePutDragger){
            Debug.Log("here");
            if(currentNodePutDragger != hoveringNodePutDragger){
                Debug.Log("here");
                if(currentNodePutDragger.GetComponent<NodeInputGUI>() && hoveringNodePutDragger.GetComponent<NodeOutputGUI>()){
                    Debug.Log("here");

                    currentNodePutDragger.GetComponent<NodeInputGUI>().SetNodeOutput(
                        hoveringNodePutDragger.GetComponent<NodeOutputGUI>());


                }
                else if(currentNodePutDragger.GetComponent<NodeOutputGUI>() && hoveringNodePutDragger.GetComponent<NodeInputGUI>()){
                    
                    hoveringNodePutDragger.GetComponent<NodeInputGUI>().SetNodeOutput(
                        currentNodePutDragger.GetComponent<NodeOutputGUI>());
                    
                    
                }
                else if(currentNodePutDragger.GetComponent<NodeOutputFlowGUI>() && hoveringNodePutDragger.GetComponent<NodeInputFlowGUI>()){
                    
                    hoveringNodePutDragger.GetComponent<NodeOutputFlowGUI>().SetNodeInputFlow(
                        currentNodePutDragger.GetComponent<NodeInputFlowGUI>());
                    
                    
                }
                else if(hoveringNodePutDragger.GetComponent<NodeOutputFlowGUI>() && currentNodePutDragger.GetComponent<NodeInputFlowGUI>()){
                    
                    currentNodePutDragger.GetComponent<NodeOutputFlowGUI>().SetNodeInputFlow(
                        hoveringNodePutDragger.GetComponent<NodeInputFlowGUI>());
                    
                    
                }
            }
        }

        currentNodePutDragger = null;
        hoveringNodePutDragger = null;

        /*

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
        */



        /*
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
        */
    }
    public override void OnPointerEnter(PointerEventData eventData) {
        if(hoveringNodePutDragger == null){
            hoveringNodePutDragger = this;

        }

        
    }

    public override void OnPointerExit(PointerEventData eventData) {

        if(hoveringNodePutDragger == this){
            hoveringNodePutDragger = null;

        }

        
    }

}
