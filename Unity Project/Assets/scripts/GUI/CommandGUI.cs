using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandGUI : MonoBehaviour
{
    [SerializeField]
    public Text commandNameText;

    [SerializeField]
    public GameObject argumentsParent;

    [SerializeField]
    public GameObject argument;

    [SerializeField]
    public Command command;

    [SerializeField]
    public Text lineNumberText;

    ArgumentGUI[] allArguments;

    public Dropdown optionsDropdown;

    ProgramGUI programGUI;

    // Start is called before the first frame update
    void Start()
    {
        allArguments = new ArgumentGUI[command.arguments.Length];
        int count = 0;
        Programs programs = command.programable.programs;
        foreach(Argument a in command.arguments){
            GameObject clone;
            clone = Instantiate(argument);
            clone.transform.SetParent(argumentsParent.transform, false);

            clone.GetComponent<ArgumentGUI>().SetArgumentGUI(a, command, programs);
            
            //clone.GetComponent<ArgumentGUI>().titleText.text = command.arguments[count].title;
            count += 1;
        }
    }

    public void SetProgramGUI(ProgramGUI programGUI){
        this.programGUI = programGUI;
    }

    // Update is called once per frame
    void Update()
    {
        if(command == null){
            Destroy(gameObject);
        }

        //int index = command.transform.GetSiblingIndex();

        //float y = index * 200;

        //GetComponent<RectTransform>().anchoredPosition = new Vector2(0, y);
        
    }
    public void UpdateVariablesDropdownLists(){
        for(int i = 0; i < GetComponentsInChildren<ArgumentGUI>().Length; i++){
            GetComponentsInChildren<ArgumentGUI>()[i].PopulateVariableDropdowns();
        }
    }

    public void MoveUp(){
        command.MoveUp();

    }

    public void MoveDown(){
        command.MoveDown();
    }

    public void Delete(){
        command.Delete();
    }


    public void OnOptionsDropdownChange(){
        int value = optionsDropdown.value;

        if(value == OptionsDropdownCommand.Delete){
            programGUI.DeleteCommand(command);
        }
        else if(value == OptionsDropdownCommand.MoveUp){
            command.MoveUp();
        }
        else if(value == OptionsDropdownCommand.MoveDown){
            command.MoveDown();
        }


    }
}
