using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArgumentGUI : MonoBehaviour
{

    [SerializeField]
    public Text titleText;

    [SerializeField]
    Dropdown typeDropdown;

    [SerializeField]
    Dropdown vairableDropdown;

    [SerializeField]
    InputField constantInputField;

    [SerializeField]
    Dropdown outputVariableDropdown;

    

    [SerializeField]
    RobotPart robotPart;

    [SerializeField]
    Text noVariablesText;

    Variable selectedVariable;

    [SerializeField]
    Dropdown comparerDropdown;

    [SerializeField]
    DisplayForm displayForm;

    public enum DisplayForm{
        Normal,
        Comparer
    }

/*

    //Not implemented yet .....

    VariableSource variableSource = VariableSource.SelectedPrograms;
    enum VariableSource{
        SelectedPrograms,
        AllProgramsFromHead
    }
    */

    public Command command;

    Programs programs;

     Argument argument;

     



    // Start is called before the first frame update
    public void SetArgumentGUI(Argument arg, Command com, Programs p)
    {

        
        argument = arg;
        command = com;
        programs = p;

        displayForm = arg.displayForm;
        

        if(titleText && argument){
            titleText.text = argument.title;
        }

        if(displayForm == DisplayForm.Normal) {
            if(comparerDropdown){
                Destroy(comparerDropdown.gameObject);
            }
            

            OnChangeDropdown();

            typeDropdown.onValueChanged.AddListener(delegate {
                OnChangeDropdown();
            });

            if(argument.assignmentType == Argument.AssignmentType.Input){
                Destroy(outputVariableDropdown.gameObject);
                
            }
            else if(argument.assignmentType == Argument.AssignmentType.Output){
                Destroy(typeDropdown.gameObject);
                Destroy(constantInputField.gameObject);
            }
            PopulateVariableDropdowns();

            noVariablesText.text = "No Variables";
        }
        else if(displayForm == DisplayForm.Comparer) {
            Destroy(noVariablesText.gameObject);
            Destroy(constantInputField.gameObject);
            Destroy(outputVariableDropdown.gameObject);
            Destroy(typeDropdown.gameObject);
            Destroy(vairableDropdown.gameObject);
          //  Destroy();

        }

     
        
        
    }

    public void OnComparerDropdown(){
        
    }
    public void SetPrograms(Programs p){
        this.programs = p;
    }


    public void SetCurrentValuesToGUI(){
        if(typeDropdown.value == 0){
            //constant
            
        }
        else if(typeDropdown.value == 1){
            //variable
            argument.argumentType = Argument.ArgumentType.Variable;
            
        }
    }

    public void PopulateVariableDropdowns(){

        if(displayForm == DisplayForm.Normal){
            Debug.Log("Pop Var Drop");

            if(!programs || programs.GetAllGlobalVariables().Length == 0){

                noVariablesText.gameObject.SetActive(true);
                vairableDropdown.gameObject.SetActive(false);
                return;
            }
            else {

                noVariablesText.gameObject.SetActive(false);
                vairableDropdown.gameObject.SetActive(true);

            }
            

            Dropdown drop = null; 

            if(argument.assignmentType == Argument.AssignmentType.Input){
                drop = vairableDropdown;
                
            }
            else if(argument.assignmentType == Argument.AssignmentType.Output){
                drop = outputVariableDropdown;
            }

            drop.ClearOptions();
            var options = new List<string>();

        
            foreach(Variable v in programs.GetAllVariables()){
                options.Add(v.GetName());
            }

            drop.AddOptions(options);

            drop.RefreshShownValue();
        }
     

        
    }
    

    // Update is called once per frame
    void Update()
    {
        SetArgumentValues();

        if(typeDropdown.value == 0){
            argument.argumentType = Argument.ArgumentType.Constant;
        }
        else if(typeDropdown.value == 1){
            argument.argumentType = Argument.ArgumentType.Variable;
            
        }

        SetVariable();
        PopulateVariableDropdowns();
        
        
        
    }
    public void SetVariable(){
        if(!programs){
            return;
        }

        if(outputVariableDropdown.value < programs.GetAllGlobalVariables().Length){

            //Debug.Log(programs.GetAllGlobalVariables()[ outputVariableDropdown.value ]);
            argument.variable = programs.GetAllGlobalVariables()[ outputVariableDropdown.value ];
        }
        
    }

    private void SetArgumentValues(){

        if(displayForm == DisplayForm.Normal){

            if(argument.assignmentType == Argument.AssignmentType.Input){
                //Set value uesed for input to command

                float value = 0;
                if(argument.argumentType == Argument.ArgumentType.Constant){
                    float parseResult;
                    if(float.TryParse(constantInputField.text, out parseResult)){
                        value = parseResult;
                    } else {
                        value = 0;
                    }
                
                } else if(argument.argumentType == Argument.ArgumentType.Variable){
                    if(argument.variable){
                        value = argument.variable.GetValue();
                    }
                    else {
                        value = 0;
                    }
                    
                }

                argument.SetValue(value.ToString());

                
            }
            else if(argument.assignmentType == Argument.AssignmentType.Output){
            //  argument.variable.SetValue(value);

            }
        }
        else if (displayForm == DisplayForm.Comparer){
            int value = comparerDropdown.value;
            argument.SetValue(value);
        }
       
    }

    void OnChangeDropdown(){
        int value = typeDropdown.value;

        if(value == 0){
            OnSelectConstant();
            
        }
        else if(value == 1){
            OnSelectVariable();
        }

    }

    void OnSelectVariable(){
        vairableDropdown.gameObject.SetActive(true);
        constantInputField.gameObject.SetActive(false);
        PopulateVariableDropdowns();

    }
    void OnSelectConstant(){
        vairableDropdown.gameObject.SetActive(false);
        constantInputField.gameObject.SetActive(true);

    }

}
