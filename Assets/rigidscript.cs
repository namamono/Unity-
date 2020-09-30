using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(1f,1f,0.1f);
       if(Input.GetKeyDown(KeyCode.Space))
       {
           GetComponent<Renderer>().enabled=false;
       }
       if(Input.GetKeyUp(KeyCode.Space))
       {
           GetComponent<Renderer>().enabled=true;
       }
    }
}
