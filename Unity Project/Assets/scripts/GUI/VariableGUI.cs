using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableGUI : MonoBehaviour
{

    
    [SerializeField]
    public InputField nameInputField;

    [SerializeField]
    public InputField initialValueInputField;

    [SerializeField]
    public Text nameText;

    public Text valueText;

 //   [SerializeField]
//    public InputField valueInputField;

    [SerializeField]
    public Variable variable;

    public Dropdown optionsDropdown;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = variable.variableName;
    }

    // Update is called once per frame
    void Update()
    {
        if(variable == null){
            Destroy(gameObject);
        }
       // variable.variableName = nameInputField.text;
       // variable.initialValue = initialValueInputField.text;
       valueText.text = variable.GetValue().ToString();
       
    }
    public void UpdateVariablesList(){
        
    }

    public void OnOptionsDropdownChange(){
        int value = optionsDropdown.value;

        if(value == OptionsDropdownVariable.Delete){
            variable.DeleteVariable();
        }
        else if(value == OptionsDropdownVariable.MoveUp){
            variable.MoveVariableUp();
        }
        else if(value == OptionsDropdownVariable.MoveDown){
            variable.MoveVariableDown();
        }

    }
}
