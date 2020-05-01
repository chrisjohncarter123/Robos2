using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPartMaterial : MonoBehaviour
{
    public Color color;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

       //Call SetColor using the shader property name "_Color" and setting the color to red
       renderer.material.SetColor("_Color", color);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color){
        this.color = color;
        UpdateMaterial();

    }

    public void SetRed(float r){
        Color c = color;
        c.r = r;
        color = c;
        UpdateMaterial();
    }

    public void SetBlue(float r){
        Color c = color;
        c.b = r;
        color = c;
        UpdateMaterial();
    }

    public void SetGreen(float r){
       Color c = color;
        c.g = r;
        color = c;
        UpdateMaterial();
    }

    void UpdateMaterial(){
        renderer.material.SetColor("_Color", color);
    }
}
