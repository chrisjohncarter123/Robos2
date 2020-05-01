using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleProgrammingScreen : MonoBehaviour
{

    [SerializeField]
    GameObject  programmingScreen;

    

    bool enable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SetToggle(!enable);
        }
    }

    public void SetToggle(bool value){
        enable = value;
        programmingScreen.SetActive(enable);
    }
}
