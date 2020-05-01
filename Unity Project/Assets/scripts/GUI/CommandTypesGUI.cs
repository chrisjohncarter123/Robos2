using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandTypesGUI : MonoBehaviour
{

    [SerializeField]
    GameObject commandTypeParent;

    [SerializeField]
    GameObject commandTypeGUI;

    [SerializeField]
    ProgramGUI programGUI;


    // Start is called before the first frame update
    void Start()
    {
        TurnOffCommands();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnCommands(GameObject part){


        foreach(Transform t in commandTypeParent.GetComponentsInChildren<Transform>()) {
            if(t.gameObject != commandTypeParent.gameObject)
            {
                GameObject.Destroy(t.gameObject);
            }
        }


        commandTypeParent.gameObject.SetActive(true);

        foreach(CommandType t in part.GetComponentsInChildren<CommandType>()){
            GameObject clone;
            clone = Instantiate(commandTypeGUI);
            clone.transform.SetParent(commandTypeParent.transform, false);
            clone.GetComponent<CommandTypeGUI>().commandNameText.text = t.GetCommandNameType();

            ProgramableObject po = ProgramableObject.CurrentProgramableObject();

            clone.GetComponent<Button>().onClick.AddListener(() => po.AddCommand(t.command));
            clone.GetComponent<Button>().onClick.AddListener(() => programGUI.UpdateGUI());
        }

    }

    public void TurnOffCommands(){
        commandTypeParent.gameObject.SetActive(false);
    }
}
