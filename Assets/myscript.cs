using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{
    bool flg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0.1f,0.1f,0.1f);
       Animator animation = GetComponent<Animator>();
       if(Input.GetKeyDown(KeyCode.Space))
       {
           if(flg)
           {
               animation.CrossFade("anim2",5.0f);
           }
           else
           {
               animation.CrossFade("anim1",5.0f);
           }
           flg = !flg;
       }

    }
}
