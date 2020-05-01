using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandomizer : MonoBehaviour
{
    public Color colorMin, colorMax;
    public Vector3 yColor;
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void SetColor(Color newColor){

        

        light = GetComponent<Light>();
        Color color = 
            new Color(
            Random.Range(colorMin.r, colorMax.r),
            Random.Range(colorMin.g, colorMax.g),
            Random.Range(colorMin.b, colorMax.b)

        );
        color.r += transform.position.y * yColor.x / 100;
        color.g += transform.position.y * yColor.y / 100;
        color.b += transform.position.y * yColor.z / 100;
        
        light.color = newColor + color;
        
    }

    public void SetRange(float range){
        light.range = range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
