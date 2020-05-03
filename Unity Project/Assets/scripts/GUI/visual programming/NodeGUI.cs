using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeGUI : MonoBehaviour
{

    //GUI Objects
    public Text titleText;
    public RectTransform rectTransform;
    public Color textColor;
    public float baseHeight;
    public float distance;
    public float putSize = 20;
    public RectTransform inputFlowsParentRectTransform;
    public RectTransform outputFlowsParentRectTransform;
    public RectTransform inputsParentRectTransform;
    public RectTransform outputsParentRectTransform;
    public GameObject inputFlowBase;
    public GameObject outputFlowBase;
    public GameObject inputBase;
    public GameObject outputBase;
    public GameObject outputConstantBase;
    MouseLineGUI mouseLine;
    public float flowLineWidth;
    public float variableLineWidth;
    public Color flowLineColor;
    public Color variableLineColor;
    public GameObject lineBase;


    //"Back-End" objects
    public Node node;
    NodeFlow inputFlow;
    NodeFlow[] outputFlows;
    NodeInput[] inputs;
    NodeOutput[] outputs;
    Vector2 position;
    VisualProgramPositionGUI positionGUI;

    void Start()
    {
        position = new Vector2(0,0);
    }

    public void SetNodePosition(Vector2 position){
        this.position = position;
    }

    public Vector2 GetNodePosition(){
        return position;
    }

    public void SetPositionGUI(VisualProgramPositionGUI positionGUI){
        this.positionGUI = positionGUI;
    }

    public void UpdateNodePosition(Vector2 add){
        Vector2 pos = position + (add * 2);
        GetComponent<RectTransform>().anchoredPosition = pos;


    }
    void Update() {
        UpdateNodePosition(positionGUI.GetProgramPosition());
    }

    public void SetMouseLine(MouseLineGUI mouseLine){
        this.mouseLine = mouseLine;
    }

    void SetRectTransform(NodeFlow[] outputFlows, NodeInput[] inputs, NodeOutput[] outputs){
        rectTransform = GetComponent<RectTransform>();

        int count = Mathf.Max(1, outputFlows.Length) + Mathf.Max(inputs.Length, outputs.Length);

        Vector2 sizeDelta = rectTransform.sizeDelta;
        sizeDelta.y += baseHeight + (count * distance);
        rectTransform.sizeDelta = sizeDelta;

        rectTransform.anchoredPosition = new Vector2(0,0);

    }

    void SetTextColor (){
        
        foreach(Text t in GetComponentsInChildren<Text>()){
            t.color = textColor;
        }

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


        int seperationCounter = 0;
        foreach(NodeFlow n in outputFlows){
            GameObject clone = CreatePut(outputFlowBase, outputFlowsParentRectTransform, n.GetComponent<NodePut>());
            clone.GetComponent<NodeOutputFlowGUI>().SetNodeFlow(n);
            clone.GetComponent<PutLineGUI>().SetLineWidth(flowLineWidth);
            clone.GetComponent<PutLineGUI>().SetLineColor(flowLineColor); 
            clone.GetComponent<PutLineGUI>().SetLineBase(lineBase);  
            clone.GetComponent<PutLineGUI>().SetLineSeperation(--seperationCounter);     

        }

        seperationCounter = 0;

        foreach(NodeInput n in inputs){
            GameObject clone = CreatePut(inputBase, inputsParentRectTransform, n.GetComponent<NodePut>());
            clone.GetComponent<NodeInputGUI>().SetNodeInput(n);
            clone.GetComponent<PutLineGUI>().SetLineWidth(variableLineWidth);
            clone.GetComponent<PutLineGUI>().SetLineColor(variableLineColor); 
            clone.GetComponent<PutLineGUI>().SetLineBase(lineBase);  
            clone.GetComponent<PutLineGUI>().SetLineSeperation(++seperationCounter);    
        }
        foreach(NodeOutput n in outputs){
            GameObject clone = CreatePut(outputBase, outputsParentRectTransform, n.GetComponent<NodePut>());
            clone.GetComponent<NodeOutputGUI>().SetNodeOutput(n); 

        }

        SetTextColor();

    }



    GameObject CreatePut(
        GameObject baseObject,
         RectTransform parentObject,
          NodePut nodePut){

        GameObject clone = Instantiate(baseObject);
        clone.transform.SetParent(parentObject, false);
        clone.GetComponent<NodePutGUI>().SetNodePut(nodePut);
        clone.GetComponent<NodePutGUI>().node = node;
        clone.GetComponent<NodePutGUI>().SetSize(putSize);
        clone.GetComponent<SlotGUI>().SetMouseLine(mouseLine);

        //clone.GetComponent<SlotGUI>().nodeGUI = this;

        return clone;
    }

    
}
