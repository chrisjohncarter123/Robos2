using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodePutGUI : MonoBehaviour
{

    public Text titleText;
    public Text valueText;
    public NodePut nodePut;
    public NodePutDragger dragger;
    public SlotGUI slotGUI;
    float lineWidth;
    Color lineColor;


    public Node node;
 

    void Start() {
        dragger = gameObject.AddComponent<NodePutDragger>();
        slotGUI = GetComponent<SlotGUI>();
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
    public void SetLineColor(Color lineColor){
        this.lineColor = lineColor;

    }
    public void SetLineWidth(float lineWidth){
        this.lineWidth = lineWidth;

    }
    public Node GetNode(){
        return nodePut.GetNode();
    }

    public float GetLineWidth(){
        return lineWidth;

    }
    public Color GetLineColor(){
        return lineColor;

    }

    void Update(){

        SetTitleText(nodePut.GetNodePutTitle());


        SetValueText(nodePut.GetNodePutValue().ToString());

    }
}
