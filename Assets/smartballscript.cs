﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartballscript : MonoBehaviour
{
    float power=0f;
    GameObject[] cubes=new GameObject[5];
    Vector3[] moves=new Vector3[5];
    // Start is called before the first frame update
    void Start()
    {
        moves[0]=new Vector3(0f,1f,0f);
        moves[1]=new Vector3(-3f,1f,5f);
        moves[2]=new Vector3(3f,1f,0f);
        moves[3]=new Vector3(-3f,1f,-3f);
        moves[4]=new Vector3(3f,1f,-3f);
        for(int i=0;i<5;i++)
        {
            cubes[i]=GameObject.Find("BoardCube"+i);
            Vector3 move =cubes[i].transform.position;

            //アニメーションクリップ作成
            AnimationClip clip = new AnimationClip();
            clip.legacy=true;

            //キーフレーム1
            Keyframe[] keysX=new Keyframe[2];
            keysX[0]=new Keyframe(0f,move.x-3);
            keysX[1]=new Keyframe(i+1f,move.x+3);

            //アニメーションカーブ1
            AnimationCurve curveX=new AnimationCurve(keysX);
            clip.SetCurve("",typeof(Transform),"localPosition.x",curveX);
            clip.wrapMode=WrapMode.PingPong;

            //キーフレーム2
            Keyframe[] keysY=new Keyframe[2];
            keysY[0]=new Keyframe(0f,move.y);
            keysY[1]=new Keyframe(i+1f,move.y);

            //アニメーションカーブ2
            AnimationCurve curveY=new AnimationCurve(keysY);
            clip.SetCurve("",typeof(Transform),"localPosition.y",curveY);
            clip.wrapMode=WrapMode.PingPong;

            //キーフレーム3
            Keyframe[] keysZ=new Keyframe[2];
            keysZ[0]=new Keyframe(0f,move.z);
            keysZ[1]=new Keyframe(i+1f,move.z);

            //アニメーションカーブ3
            AnimationCurve curveZ=new AnimationCurve(keysZ);
            clip.SetCurve("",typeof(Transform),"localPosition.z",curveZ);
            clip.wrapMode=WrapMode.PingPong;

            //アニメーションクリップを設定
            cubes[i].GetComponent<Animation>().AddClip(clip,"clip1");
            cubes[i].GetComponent<Animation>().Play("clip1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Renderer renderer=GetComponent<Renderer>();

        MoveCube();//障害物を動かす
        rigidbody.AddForce(0f,0f,-1f);

        //スペースキーの処理
        if(Input.GetKey(KeyCode.Space))
        {
            power+=0.01f;
            if(power>1f)
            {
                power=1f;
            }
            renderer.material.color=new Color(1f,power,0f);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector3(0f,0f,power*2500f));
            power=0f;
            renderer.material.color=Color.red;
        }
    }

    void MoveCube()
    {
        for(int i=0;i<5;i++)
        {
            cubes[i].transform.Rotate(new Vector3(0f,0.25f,0f));
        }
    }
}
