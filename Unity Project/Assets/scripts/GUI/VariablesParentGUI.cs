using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariablesParentGUI : MonoBehaviour
{


    [SerializeField]
    GameObject variablesParent;

    [SerializeField]
    GameObject variable;

    [SerializeField]
    InputField newVariableNameField;

    [SerializeField]
    Programs programs;



    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetNewVariableName(){
        return  newVariableNameField.text;
    }

    public void Display(){



        foreach(Transform t in variablesParent.GetComponentsInChildren<Transform>()) {
            if(t.gameObject != variablesParent.gameObject)
            {
              
                Destroy(t.gameObject);
            }
        }

        Variable[] variables = programs.GetAllGlobalVariables();



        foreach(Variable v in variables) {
            if(v){
                GameObject clone;
                clone = Instantiate(variable);
                clone.transform.SetParent(variablesParent.transform, false);
                clone.GetComponent<VariableGUI>().variable = v;

            }
           
            
            
        }
    }

}
