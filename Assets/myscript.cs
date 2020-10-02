using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Animation animation = GetComponent<Animation>();

        //1つ目のアニメーションクリップ
        AnimationClip clipA = new AnimationClip();
        clipA.legacy=true;
        AnimationCurve curveA= AnimationCurve.Linear(0f,3f,3f,3f);
        Keyframe keyA=new Keyframe(1.5f,10f);
        curveA.AddKey(keyA);
        clipA.SetCurve("",typeof(Transform),"localPosition.z",curveA);
        clipA.wrapMode=WrapMode.Loop;
        animation.AddClip(clipA,"anim1");
        //animation.Play("clip1");

        //2つ目のアニメーションクリップ
        AnimationClip clipB=new AnimationClip();
        clipB.legacy=true;
        AnimationCurve curveB=AnimationCurve.Linear(0f,2f,2f,2f);
        Keyframe key1 = new Keyframe(0.5f,7f);
        curveB.AddKey(key1);
        Keyframe key2 = new Keyframe(1.0f,3f);
        curveB.AddKey(key2);
        Keyframe key3 = new Keyframe(1.5f,7f);
        curveB.AddKey(key3);
        clipB.SetCurve("",typeof(Transform),"localPosition.z",curveB);
        clipB.wrapMode=WrapMode.Loop;
        animation.AddClip(clipB,"anim2");
        animation.Play("anim1");
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0.1f,0.1f,0.1f);
       Animation animation = GetComponent<Animation>();
       if(Input.GetKeyDown(KeyCode.Space))
       {
           if(animation.IsPlaying("anim1"))
           {
               animation.PlayQueued("anim2",QueueMode.PlayNow);
           }
           else
           {
               animation.PlayQueued("anim1",QueueMode.PlayNow);
           }
       }

    }
}
