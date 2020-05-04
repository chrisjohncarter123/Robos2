using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public Transform optionsParent;
    public float heightAdd;
    public OptionsItem optionsItemBase;

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    RectTransform GetRectTransform(){
        if(!rectTransform){
            rectTransform = GetComponent<RectTransform>();

        }
        return rectTransform;
    }


    public Rect GetRect(){
        return GetRectTransform().rect;
    }


    
    public OptionsItem AddOption(string title, UnityEngine.Events.UnityAction  action){

        OptionsItem newOption = AddOption(title);
        newOption.AddListener(action);
        return newOption;
    }
    public OptionsItem AddOption(string title){

        Vector2 size = GetRectTransform().sizeDelta;
        size.y += heightAdd;
        GetRectTransform().sizeDelta = size;

        OptionsItem newOption = Instantiate(optionsItemBase.gameObject).GetComponent<OptionsItem>();
        newOption.transform.SetParent(optionsParent);
        
        return newOption;
    }
}
