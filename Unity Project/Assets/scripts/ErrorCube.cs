using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCube : MonoBehaviour
{

    [SerializeField]
    GameObject errorObject;

    int count = 0;

    List<GameObject> hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = new List<GameObject>();
        UpdateCube();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsTouchingAnything(){
        return (count > 0);
    }

    public bool IsTouchingAnythingInvalid(PartGroup partGroup){
        foreach(GameObject go in hits){
            if(go.GetComponent<RobotPart>()){
                if(go.GetComponent<RobotPart>().partGroup == partGroup){
                
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        return true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<ConnectionPoint>()){
            return;
        }
        count += 1;
        hits.Add(collision.gameObject);

        UpdateCube();
        
    }
    void OnTriggerExit(Collider collision)
    {
         if(collision.gameObject.GetComponent<ConnectionPoint>()){
            return;
        }
        count -= 1;
        hits.Remove(collision.gameObject);

        UpdateCube();
    }

    void UpdateCube(){
        
        if(IsTouchingAnything()){
            errorObject.SetActive(true);
        }else {
            errorObject.SetActive(false);
        }
        
    }

}
