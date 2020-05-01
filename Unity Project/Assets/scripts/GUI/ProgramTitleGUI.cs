using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramTitleGUI : MonoBehaviour
{
    [SerializeField]
    public Text title;

    [SerializeField]
    public Button selectButton;

    [SerializeField]
    public Text statusText;

    public ProgramableObject programableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(programableObject.IsRunning() == true){
            statusText.text = "Running";
        }
        else if(programableObject.IsRunning() == false){
            statusText.text = "Stopped";
        }
    }
}
