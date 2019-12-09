using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, 1, 1);
        Destroy(gameObject, 3.2f);
        spawnCubes.gameObjCount--;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
