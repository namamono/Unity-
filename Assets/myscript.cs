using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        AnimationClip clip = new AnimationClip();
        clip.legacy=true;
        AnimationCurve curve = AnimationCurve.Linear(0f,3f,3f,3f);
        Keyframe key = new Keyframe(1.5f,7f);
        curve.AddKey(key);
        clip.SetCurve("",typeof(Transform),"localPosition.z",curve);
        clip.wrapMode=WrapMode.Loop;
        Animation animation = GetComponent<Animation>();
        animation.AddClip(clip,"clip1");
        animation.Play("clip1");
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0.1f,0.1f,0.1f);
       Animation animation = GetComponent<Animation>();
       if(Input.GetKeyDown(KeyCode.Space))
       {
           animation.Stop();
       }
       if(Input.GetKeyUp(KeyCode.Space))
       {
           animation.Play("clip1");
       }
    }
}
