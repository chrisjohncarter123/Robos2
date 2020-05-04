using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuClose : MonoBehaviour, IPointerExitHandler
{
    public OptionsMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");

        menu.gameObject.SetActive(false);
    }
}
