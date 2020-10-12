using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class myscript : MonoBehaviour
{
    int counter=0;
    GameObject obj = null;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs =GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject obj in objs)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material.SetFloat("_Mode",3f);
            renderer.material.SetInt("_SrcBlend",(int)BlendMode.SrcAlpha);
            renderer.material.SetInt("_DstBlend",(int)BlendMode.OneMinusSrcAlpha);
            renderer.material.SetInt("_ZWrite",0);
            renderer.material.DisableKeyword("_ALPHATEST_ON");
            renderer.material.EnableKeyword("_ALPHABLEND_ON");
            renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            renderer.material.renderQueue=3000;
        }
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
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Renderer renderer=collision.gameObject.GetComponent<Renderer>();
            Color color = renderer.material.color;
            color.a=0.25f;
            renderer.material.color=color;
        }
    }

    void OnCollisionExit(Collision collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            Color color=renderer.material.color;
            color.a=1.0f;
            renderer.material.color=color;
        }
        
    }
    
}
