using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{
    int counter =0;
    GameObject obj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cube= GameObject.Find("Cube");
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if(obj!=null)
        {
            if(counter++>1000)
            {
                obj.SetActive(true);
                obj=null;
            }
        }
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
    void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.SetActive(false);
                obj=collision.gameObject;
                counter=0;
            }
        }
}
