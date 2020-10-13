using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class myscript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.Find("Cube");
        cube.GetComponent<Renderer>().material.color=new Color (1f,0,0,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cube= GameObject.Find("Cube");
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        try
        {
            cube.transform.Rotate(0.1f,-0.1f,-0.1f);
        }
        catch(System.NullReferenceException e){}
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector3(-1f,0f,1f));
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector3(1f,0f,-1f));
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(new Vector3(1f,0f,1f));
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(new Vector3(-1f,0f,-1f));
        }
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Renderer>().material.color=new Color(0,1,0,0.5f);

        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Renderer>().material.color=new Color(1,0,0,0.5f);
        }
        
    }
    
}
