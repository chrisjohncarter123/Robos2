using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeGUI : MonoBehaviour
{

    //GUI Objects
    public Text titleText;
    public RectTransform rectTransform;
    public float distance;
    public RectTransform inputFlowsParentRectTransform;
    public RectTransform outputFlowsParentRectTransform;
    public RectTransform inputsParentRectTransform;
    public RectTransform outputsParentRectTransform;
    public GameObject inputFlowBase;
    public GameObject outputFlowBase;
    public GameObject inputBase;
    public GameObject outputBase;
    public GameObject outputConstantBase;
    public float flowLineWidth;
    public float variableLineWidth;
    public Color flowLineColor;
    public Color variableLineColor;


    //"Back-End" objects
    public Node node;
    NodeFlow inputFlow;
    NodeFlow[] outputFlows;
    NodeInput[] inputs;
    NodeOutput[] outputs;

    void Start()
    {
        
    }

    void SetRectTransform(NodeFlow[] outputFlows, NodeInput[] inputs, NodeOutput[] outputs){
        rectTransform = GetComponent<RectTransform>();

        int count = Mathf.Max(1, outputFlows.Length) + Mathf.Max(inputs.Length, outputs.Length);

        Vector2 sizeDelta = rectTransform.sizeDelta;
        sizeDelta.y += (count * distance);
        rectTransform.sizeDelta = sizeDelta;

    }

    public void InitGUI(Node node){
        inputs = node.inputs;
        outputs = node.outputs;
        inputFlow = node.inputFlow;
        outputFlows = node.outputFlows;

        SetRectTransform(outputFlows, inputs, outputs);
        

        this.node = node;

        titleText.text = node.GetNodeTitle();


            GameObject inputFlowClone = CreatePut(inputFlowBase, inputFlowsParentRectTransform, inputFlow.GetComponent<NodePut>());
            inputFlowClone.GetComponent<NodeInputFlowGUI>().SetNodeFlow(node.inputFlow);
            inputFlowClone.GetComponent<NodePutGUI>().SetLineWidth(flowLineWidth);
            inputFlowClone.GetComponent<NodePutGUI>().SetLineColor(flowLineColor); 


        foreach(NodeFlow n in outputFlows){
            GameObject clone = CreatePut(outputFlowBase, outputFlowsParentRectTransform, n.GetComponent<NodePut>());
            clone.GetComponent<NodeOutputFlowGUI>().SetNodeFlow(n);
            clone.GetComponent<NodePutGUI>().SetLineWidth(flowLineWidth);
            clone.GetComponent<NodePutGUI>().SetLineColor(flowLineColor); 

        }

        foreach(NodeInput n in inputs){
            GameObject clone = CreatePut(inputBase, inputsParentRectTransform, n.GetComponent<NodePut>());
            clone.GetComponent<NodeInputGUI>().SetNodeInput(n);
            clone.GetComponent<NodePutGUI>().SetLineWidth(variableLineWidth);
            clone.GetComponent<NodePutGUI>().SetLineColor(variableLineColor);    
        }
        foreach(NodeOutput n in outputs){
            GameObject clone = CreatePut(outputBase, outputsParentRectTransform, n.GetComponent<NodePut>());
            clone.GetComponent<NodeOutputGUI>().SetNodeOutput(n);
            clone.GetComponent<NodePutGUI>().SetLineWidth(variableLineWidth);
            clone.GetComponent<NodePutGUI>().SetLineColor(variableLineColor); 

        }

    }



    GameObject CreatePut(GameObject baseObject, RectTransform parentObject, NodePut nodePut){

        Debug.Log(nodePut);
        GameObject clone = Instantiate(baseObject);
        clone.transform.SetParent(parentObject);
        clone.GetComponent<NodePutGUI>().SetNodePut(nodePut);
        clone.GetComponent<NodePutGUI>().node = node;
        //clone.GetComponent<SlotGUI>().nodeGUI = this;

        return clone;
    }

    
}
