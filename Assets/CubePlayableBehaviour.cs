using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class CubePlayableBehaviour : PlayableBehaviour
{
    public GameObject cubeObject;
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if(cubeObject==null){return;}
        Renderer R =cubeObject.GetComponent<Renderer>();
        Color c = R.material.color;
        c.r=0f;
        c.g=1f;
        R.material.color=c;
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if(cubeObject==null){return;}
        Renderer R =cubeObject.GetComponent<Renderer>();
        Color c = R.material.color;
        c.r=1f;
        c.g=0f;
        R.material.color=c;
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        
    }
}
