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
       Animator animator = GetComponent<Animator>();
       int flag = animator.GetInteger("flag");

       if(Input.GetKeyDown(KeyCode.UpArrow))
       {
           flag++;
           Debug.Log(flag);
       }
       if(Input.GetKeyDown(KeyCode.DownArrow))
       {
           flag--;
           Debug.Log(flag);
       }
       animator.SetInteger("flag",flag);
       

    }
}
