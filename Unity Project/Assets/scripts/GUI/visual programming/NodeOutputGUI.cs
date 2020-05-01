using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeOutputGUI : MonoBehaviour
{

    NodeOutput nodeOutput;
    public NodePut nodePut;
    NodePutGUI nodePutGUI;

    public InputField constantTextField;


    public NodeOutput GetNodeOutput(){
        return nodeOutput;
    }

    public void SetNodeOutput(NodeOutput nodeOutput){
        
        this.nodeOutput = nodeOutput;
        nodePutGUI = GetComponent<NodePutGUI>();

        if(nodeOutput.GetOutputType() == NodeOutput.OutputType.Normal){
            if(constantTextField){
                Destroy(constantTextField.gameObject);
            }

        }
        else {
            Destroy(nodePutGUI.valueText);

        }
    }

    void Update(){
        if(nodeOutput.GetOutputType() == NodeOutput.OutputType.Constant){
            string textValue = constantTextField.text;
            double result;
            double value = 0;
            if(double.TryParse(textValue, out result)){
                value = result;
            }
            
            nodeOutput.SetValue(value);

        }

    }
}
