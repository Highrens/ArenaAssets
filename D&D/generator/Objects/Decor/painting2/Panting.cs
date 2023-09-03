using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panting : MonoBehaviour
{
    public bool PaintingRandom;
    public Texture[] textures;
    // Start is called before the first frame update
    void Start()
    {
        if (PaintingRandom)
        {
            int i = Random.Range(0, textures.Length);
            GetComponent<Renderer>().material.mainTexture = textures[i];
        }
    }


}
