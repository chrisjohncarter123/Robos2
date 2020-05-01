using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotOnOffButtons : MonoBehaviour
{

    [SerializeField]
    Text statusText;

    [SerializeField]
    GameObject onGameObject;

    [SerializeField]
    GameObject offGameObject;

    [SerializeField]
    ProgramableObject programable;






    // Start is called before the first frame update
    void Start()
    {
        TurnOff();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStatusTextToIsRunning(){
        statusText.text = "Program Is Running";
    }

    void SetStatusTextToIsStopped(){
        statusText.text = "Program Is Stopped";
    }

    public void OnOnButton(){
        programable.StartProgram();
        TurnOn();
        

    }

    public void OnOffButton(){
        programable.ForceStopProgram();
        TurnOff();
        

    }

    public void OnProgramEnd(){
        onGameObject.SetActive(false);
        offGameObject.SetActive(true);
        TurnOff();

    }

    void TurnOn(){
        onGameObject.SetActive(true);
        offGameObject.SetActive(false);
        SetStatusTextToIsRunning();


    }
    void TurnOff(){
        onGameObject.SetActive(false);
        offGameObject.SetActive(true);
        SetStatusTextToIsStopped();

    }
}
