
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{

    public float width, height, depth;
    public int count;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < count; i++){
            float x = Random.Range(-width, width);
            float y = Random.Range(-height, height);
            float z = Random.Range(-depth, depth);

            GameObject clone = Instantiate(go);
            
            clone.transform.localPosition = new Vector3(x,y,z);
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(2,5,2));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
