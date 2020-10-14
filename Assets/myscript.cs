﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class myscript : MonoBehaviour
{
    GameObject[] cubes = new GameObject[4];
    GameObject[] gos = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<4 ; i++)
        {
            cubes[i]=GameObject.Find("Cube"+i);
            gos[i]=GameObject.Find("GameObject"+i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody=GetComponent<Rigidbody>();
        foreach(GameObject obj in cubes)
        {
            obj.transform.Rotate(new Vector3(0.1f,0.1f,0.1f));
        }
        Vector3 v = transform.position;
        v.y +=2;
        v.z -=7;
        Camera.main.transform.position=v;
        
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
        if(other.gameObject.name.StartsWith("Cube"))
        {
            for(int i=0; i<4;i++)
            {
                if(cubes[i]==other.gameObject)
                {
                    ParticleSystem ps = gos[i].GetComponent<ParticleSystem>();
                    ps.Play();
                    cubes[i].SetActive(false);
                }
            }

        }
    }

    
}
