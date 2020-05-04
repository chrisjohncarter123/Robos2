using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsItem : MonoBehaviour
{

    public Text titleText;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOptionsItem(string title, UnityEngine.Events.UnityAction action){
        titleText.text = title;
        AddListener(action);

    }

    public void AddListener(UnityEngine.Events.UnityAction action){
        button.onClick.AddListener(action);

    }
}
