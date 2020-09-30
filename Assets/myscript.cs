using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{
    Texture texture1;
    Renderer renderer;
    Color color1;

    // Start is called before the first frame update
    void Start()
    {
       texture1 = (Texture)Resources.Load("QS-GRASS-1.1");
       renderer = GetComponent<Renderer>();
       color1 = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1f,1f,0.1f);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            renderer.material.mainTexture=texture1;
            renderer.material.color=Color.white;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            renderer.material.mainTexture=null;
            renderer.material.color = color1;
        }
    }
}
