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

    public void SetLineColor(Color color){
        lineGUI.SetLineColor(color);

    }

    public void SetLineWidth(float width){
        lineGUI.SetLineWidth(width);

    }

    public void Update() {
        if (dragging) {
           
            if(currentNodePutDragger)
                if(lineGUI.GetIsDrawing() == false){
                    CreateLine();

                }
                lineGUI.UpdateLine(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            }
            else {
                lineGUI.TryDestroyLine();
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

         currentNodePutDragger = this;
    }

    public override void OnPointerUp(PointerEventData eventData) {

        lineGUI.DestroyLine();

        dragging = false;
        Debug.Log(currentNodePutDragger + "     " + hoveringNodePutDragger);

        //output to input works, input to output doesn't

        if(currentNodePutDragger && hoveringNodePutDragger){

            if(currentNodePutDragger != hoveringNodePutDragger){
    
                if(currentNodePutDragger.GetComponent<NodeInputGUI>()
                 && hoveringNodePutDragger.GetComponent<NodeOutputGUI>()){


                    currentNodePutDragger.GetComponent<NodeInputGUI>().SetNodeOutput(
                        hoveringNodePutDragger.GetComponent<NodeOutputGUI>());


                }
                else if(currentNodePutDragger.GetComponent<NodeOutputGUI>()
                     && hoveringNodePutDragger.GetComponent<NodeInputGUI>()){

                    
                    hoveringNodePutDragger.GetComponent<NodeInputGUI>().SetNodeOutput(
                        currentNodePutDragger.GetComponent<NodeOutputGUI>());
                    
                    
                }
                else if(currentNodePutDragger.GetComponent<NodeOutputFlowGUI>()
                && hoveringNodePutDragger.GetComponent<NodeInputFlowGUI>()){

                     Debug.Log("here3");

                    currentNodePutDragger.GetComponent<NodeOutputFlowGUI>().SetNodeInputFlow(
                        hoveringNodePutDragger.GetComponent<NodeInputFlowGUI>()
                    );
                    
                    
                    
                }
                else if(hoveringNodePutDragger.GetComponent<NodeInputFlowGUI>()
                && currentNodePutDragger.GetComponent<NodeOutputFlowGUI>()){

                     Debug.Log("here4");
                    
                    hoveringNodePutDragger.GetComponent<NodeOutputFlowGUI>().SetNodeInputFlow(
                        currentNodePutDragger.GetComponent<NodeInputFlowGUI>()
                    );
                    
                    
                }
            }
        }

        currentNodePutDragger = null;
        hoveringNodePutDragger = null;

    }
    public override void OnPointerEnter(PointerEventData eventData) {
        

        hoveringNodePutDragger = null;
        if(currentNodePutDragger){
            if(this != currentNodePutDragger){
                hoveringNodePutDragger = this;

            }
        }

        
    }

    public override void OnPointerExit(PointerEventData eventData) {
        hoveringNodePutDragger = null;

    }

}
