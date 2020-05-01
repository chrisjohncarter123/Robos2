using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public GameObject cube;
    public int xSize, ySize, zSize;
    public float distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < xSize; x++){
            for(int y = 0; y < ySize; y++){
                for(int z = 0; z < zSize; z++){
                    GameObject copy = Instantiate(cube);
                    copy.transform.position = new Vector3(x* distance, y* distance, z* distance);
                    copy.transform.SetParent(transform);
                
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
