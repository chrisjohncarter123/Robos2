using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramHead : MonoBehaviour
{

    public GameObject robot;

    public GameObject target;

    GameObject hologram;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public GameObject CreateHologram(GameObject head){
        if(hologram){
            DestroyHologram();
        }

        GameObject newHologram = new GameObject();
        newHologram.transform.position = head.transform.position;
        newHologram.name = "New Hologram";
        

       // newHologram.transform.SetParent(transform, true);
       
        

        Transform[] transforms = head.GetComponentsInChildren<Transform>();

    
        bool isCenter = true;

        Transform center = null;

        foreach(Transform t in transforms){
            if(t.GetComponent<Hologram>()){
                
                GameObject clone = Instantiate(t.gameObject);

                if(isCenter ){
                    clone.transform.position = t.position;
                    clone.transform.eulerAngles = t.eulerAngles;
                    center = clone.transform;

                    isCenter = false;
                }
                else {
                    clone.transform.position = t.position - center.position;
                    clone.transform.eulerAngles = t.eulerAngles;
                }

                clone.transform.SetParent(newHologram.transform, true);
                TransformHelper.SetLayerOfAllChildren(clone.gameObject, TransformHelper.ScreenLayer);

            }
        }

        hologram = newHologram;


        return newHologram;

    }

    public void DestroyHologram() {
        Destroy(hologram);
    }
}
