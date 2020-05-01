using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{

    [SerializeField]
    public string variableName;

    [SerializeField]
    public string variableValue;

    public string initialValue;

    Programs programs;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPrograms(Programs p){
        programs = p;
    }

   
    public void SetToInitialValue(){
        SetValue(initialValue);
    }
   
   public string GetName(){
       return variableName;
   }
   public void SetName(string n){
       variableName = n;
   }

    public float GetValue(){
        float result;
        if(float.TryParse(variableValue, out result)){
            return result;
        }
        return 0;
 
    }

    public void SetValue(string value){
        this.variableValue = value;
    }

    public void SetValue(float value){
        this.variableValue = value.ToString();
    }


    public void DeleteVariable(){
        programs.DeleteGlobalVariable(this);

    }

    public void MoveVariableUp(){
        programs.MoveVariable(this, 1);

    }
    public void MoveVariableDown(){
        programs.MoveVariable(this, -1);

    }
}
