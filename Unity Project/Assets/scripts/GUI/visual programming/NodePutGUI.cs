using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodePutGUI : MonoBehaviour
{

    public Text titleText;
    public Text valueText;
    public SlotGUI slotGUI;
    public NodePut nodePut;

    float selectorSize = 50;

    public RectTransform selectorRectTransform;


    public Node node;
 

    void Start() {
        slotGUI = GetComponent<SlotGUI>();

        selectorRectTransform.sizeDelta = new Vector2(selectorSize, selectorSize);
     
    }


    public void SetSize(float size){
        selectorSize = size;
        selectorRectTransform.sizeDelta = new Vector2(selectorSize, selectorSize);

    }
    public void SetTitleText(string value){
        if(titleText){
            titleText.text = value;
        }

    }
    public void SetValueText(string value){
        if(valueText){
            valueText.text = value;
        }

    }
    public Node GetNode(){
        return nodePut.GetNode();
    }

    public void SetNodePut(NodePut nodePut){
        this.nodePut = nodePut;
    }
    public NodePut GetNodePut(){
        return nodePut;
    }

    

    void Update(){

        if(nodePut){

            if(nodePut.GetNodePutTitle() != null){
                SetTitleText(nodePut.GetNodePutTitle());

            }

            if(nodePut.GetNodePutValue() != null){
                SetValueText(nodePut.GetNodePutValue().ToString());

            }
        }


    }

}
