using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{
    Renderer renderer1;
    Texture texture1;
    Color color1;
    float size=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        renderer1=GetComponent<Renderer>();
        texture1=(Texture)Resources.Load("QS-GRASS-1.1");
        color1 = renderer1.material.color;
        renderer1.material.mainTexture=texture1;
        renderer1.material.color=Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.1f,0.1f,0.01f);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            size+=0.01f;
            renderer1.material.mainTextureScale=new Vector2(size,size);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            size-=0.01f;
            if(size<0){size=0.0f;}
            renderer1.material.SetTextureScale("_MainTex",new Vector2(size,size));
        }
    }
}
