using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramGUI : MonoBehaviour
{


    [SerializeField]
    ProgramListGUI programListGUI;


    [SerializeField]
    Transform programParent;

    [SerializeField]
    InputField titleInputField;

    [SerializeField]
    Text titleText;

    [SerializeField]
    Transform commandsParent;

    [SerializeField]
    GameObject newCommandParent;


    [SerializeField]
    GameObject command;

    [SerializeField]
    public Button selectButton;


    [SerializeField]
    Button runProgramButton;

    [SerializeField]
    Button stopProgramButton;

    [SerializeField]
    Button newCommandButton;
    

    [SerializeField]
    Dropdown newCommandDropdown;

    CommandType[] simpleCommands;


    static ProgramGUI programGUI;

    [SerializeField]
    public ProgramableObject programableObject;

    [SerializeField]
    public bool setSimpleCommands = false;

    [SerializeField]
    float newCommandDistance = 50;

    [SerializeField]
    GameObject runningPannel;

    [SerializeField]
    GameObject noProgramPannel;

    [SerializeField]
    bool getSimpleCommandTypesFromSimpleCommandTypesParent = true;

    [SerializeField]
    public GameObject simpleCommandTypesParent;

    [SerializeField]
    CommandType[] simpleCommandTypes;

    List<GameObject> allCommandGUIs = new List<GameObject>();





    GameObject selectedCommand;


    // Start is called before the first frame update
    void Start()
    {
        //TurnOffSelf();
        programGUI = this;
        allCommandGUIs = new List<GameObject>();
        UpdateStopStartProgramButtons();

        if(getSimpleCommandTypesFromSimpleCommandTypesParent){

 
            simpleCommandTypes = simpleCommandTypesParent.GetComponentsInChildren<CommandType>();
        }

    }

    public void SetSingleProgram(ProgramableObject selected){

        programableObject = selected;
        SetSimpleCommands(simpleCommandTypes);
        Display();
        

    }

    public void SetSimpleCommands(CommandType[] sc){


        if(newCommandDropdown){
            simpleCommands = sc;

            List<string> options = new List<string> ();
            foreach (CommandType t in  simpleCommands){
                options.Add(t.GetCommandNameType());
            }

            newCommandDropdown.ClearOptions ();

            newCommandDropdown.AddOptions(options);
        }


    }

    public void Display() {

        Debug.Log("Display");
        TurnOffSelf();

       // programParent.gameObject.SetActive(true);

        if(!programableObject)
        {
            return;
        }




        titleInputField.text = programableObject.title;

        Command[] poCommands = programableObject.GetAllRobotCommands();

        int counter = 1;
        foreach(Command e in poCommands) {

            AddCommandGUI(e);
        
            counter += 1;
            
        }

       // RectTransform r = newCommandParent.GetComponent<RectTransform>();
       // r.anchoredPosition = new Vector2(0, newCommandDistance * poCommands.Length);

    }

    public void RunProgram(){
        programableObject.StartProgram();
        UpdateStopStartProgramButtons();

    }

    public void StopProgram(){
        programableObject.ForceStopProgram();
        UpdateStopStartProgramButtons();
    }

    public void Update(){

        
        if(!programableObject)
        {
            noProgramPannel.SetActive(true);
            return;
        }
        else {
            noProgramPannel.SetActive(false);

        }

        if(programableObject.IsRunning() == true){
            runningPannel.SetActive(true);
        }
        else {
            runningPannel.SetActive(false);
        }


         UpdateStopStartProgramButtons();

        if(titleText){
            titleText.text = programableObject.title;
        }

       // programableObject.title = titleInputField.text;
    }

    public void TurnOffSelf(){

       // programParent.gameObject.SetActive(false);

        /*
        Debug.Log("STRAT");
        Debug.Log(commandsParent.GetComponentsInChildren<Transform>());
        
        foreach(Transform t in commandsParent.GetComponentsInChildren<Transform>()) {
            if(t.gameObject != commandsParent.gameObject)
            {
                Debug.Log(t.gameObject);
            }
        }
        Debug.Log("END");
        Transform[] ts = commandsParent.GetComponentsInChildren<Transform>();
        foreach(Transform t in ts) {
            if(t.gameObject != commandsParent.gameObject)
            {
                GameObject.Destroy(t.gameObject);
            }
        }
        */

        foreach(GameObject go in allCommandGUIs){
            Destroy(go);
            
        }
        allCommandGUIs = new List<GameObject>();


    } 

    public void UpdateGUI() {
        Display();
    }
    int counter = 0;

    void AddCommandGUI(Command newCommand){
        GameObject clone;
        clone = Instantiate(command);
        clone.transform.SetParent(commandsParent, false);
        clone.GetComponent<CommandGUI>().command = newCommand;
        clone.GetComponent<CommandGUI>().commandNameText.text = newCommand.commandName;
        clone.GetComponent<CommandGUI>().lineNumberText.text = counter.ToString();
        clone.GetComponent<CommandGUI>().SetProgramGUI(this);
        allCommandGUIs.Add(clone);

        GameObject clone2;
        clone2 = Instantiate(newCommandParent);
        clone2.transform.SetParent(commandsParent, false);
        allCommandGUIs.Add(clone2);

        counter += 1;

    }


    public void AddNewCommand(){

        Debug.Log(newCommandDropdown.value);
        selectedCommand = simpleCommands[newCommandDropdown.value].gameObject;

        Command[] commands = programableObject.AddCommand(selectedCommand);
        foreach(Command c in commands){
            AddCommandGUI(c);
        }
        
        UpdateGUI();
    }

    public void DeleteCommand(Command command){
        Destroy(command.gameObject);
        UpdateGUI();
    }
    

    void UpdateStopStartProgramButtons(){
        if(!programableObject)
        {
            stopProgramButton.gameObject.SetActive(false);
            runProgramButton.gameObject.SetActive(false);
        }
        else if(programableObject.IsRunning()){
            runProgramButton.gameObject.SetActive(false);
            stopProgramButton.gameObject.SetActive(true);
        }
        else if(programableObject.IsRunning() == false){
            runProgramButton.gameObject.SetActive(true);
            stopProgramButton.gameObject.SetActive(false);
        }

    }

}
