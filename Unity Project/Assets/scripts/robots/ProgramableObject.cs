using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramableObject : MonoBehaviour
{

    [SerializeField]
    public string title = "Unnamed Program";

    [SerializeField]
    ComputerGUI computerGUI;

    [SerializeField]
    public Programs programs;

    [SerializeField]
    GameObject commands;

   // [SerializeField]
  //  GameObject command;

    [SerializeField]
    bool looping = true;

    [SerializeField]
    RobotOnOffButtons onOffButtons;

    int currentCommand = 0;

    bool isRunning = false;

    static ProgramableObject currentpo;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetIsLooping(bool value){
        this.looping = value;
    }

    public void SetCurrentCommandNumber(int value){
        currentCommand = value;
    }

    public void GoToNextEndIf(){

        currentCommand = GetNextEndIfIndex();
        RunCurrentCommand();   
        
    }

    public EndIfStatement GetNextEndIf(){
        Command[] all = GetAllRobotCommands();
        for(int i = currentCommand; i < GetAllRobotCommands().Length; i++){
            if(all[i].IsAnEndIf()){
                return all[i].GetComponent<EndIfStatement>();
                
            }
        }
        return null;
    }
    public int GetNextEndIfIndex(){
        Command[] all = GetAllRobotCommands();
        for(int i = currentCommand; i < GetAllRobotCommands().Length; i++){
            if(all[i].IsAnEndIf()){
                return i;
                
            }
        }
        return -1;
    }

    public void RunCommand(Command command){

        //Get index of command
        int index = Array.IndexOf(GetAllRobotCommands(), command);

        SetCurrentCommandNumber(index);

        RunCurrentCommand();
    }



    public static ProgramableObject CurrentProgramableObject(){
        return currentpo;
    }

    public static void SetCurrentProgramableObject(ProgramableObject po){
        currentpo = po;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public Command[] GetAllRobotCommands(){
         return commands.GetComponentsInChildren<Command>();
     }


     public Command[] AddCommand(GameObject command){

         List<Command> commandsList = new List<Command>();


        foreach(Command c in command.transform.GetComponentsInChildren<Command>()){
            GameObject clone = Instantiate(c.gameObject);
            clone.GetComponent<Command>().SetProgramableObject(this);
            clone.transform.parent = (commands.transform);
            commandsList.Add(clone.GetComponent<Command>());
         }
    
        
        

        return commandsList.ToArray();

     }

     public void MoveCommandUp(Command c){
        MoveCommand(c, 1);

    }
    public void MoveCommandDown(Command c){
        MoveCommand(c, -1);
       
    }

    public void MoveCommand(Command c, int move){
        TransformHelper.MoveSiblingIndex(c.transform, move);

    }
    public void DeleteCommand(Command c){

        if(c.IsAnEndIf()){
           // DeleteCommand(c.GetComponent<IfStatement>());
            
        }

        if(c.IsAnIf()){

        }

        Destroy(c.gameObject);
       

    }

     public void StartProgram(){

         if(GetAllRobotCommands().Length == 0){
             ForceStopProgram();
         }

        ForceStopProgram();

        programs.SetAllVariablesToInitialValues();

        isRunning = true;
      //  Debug.Log("Start Program");

        currentCommand = 0;
        RunCurrentCommand();

     }

     public void RunNextCommand(){
        currentCommand += 1;
        RunCurrentCommand();
     }

     void RunCurrentCommand(){

         
            
         if(currentCommand < GetAllRobotCommands().Length) {

            Debug.Log( "Running command " + GetAllRobotCommands()[currentCommand].gameObject.name); 
            GetAllRobotCommands()[currentCommand].RunCommand();
         }else {
             if(looping){
                 StartProgram();
         
             }
             else{
                EndProgram();
             }
         }
        
     }

     public void ForceStopProgram(){

         if(currentCommand < GetAllRobotCommands().Length){

            GetAllRobotCommands()[currentCommand].gameObject.SendMessage("StopCommand");
         }

         computerGUI.OnProgramEnd();
         EndProgram();
         
     }

     void EndProgram(){
         isRunning = false;
         if(onOffButtons){
            onOffButtons.OnProgramEnd();
         }
         
     }


     public bool IsRunning(){
         return isRunning;
     }

}
