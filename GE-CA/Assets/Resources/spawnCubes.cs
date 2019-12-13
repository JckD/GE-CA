using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour
{

    public int numObjects = 64;
    public int maxObj = 1000;
    public static int gameObjCount = 0;
    public int numRings = 40;
    public GameObject Cube;
    public GameObject[,] ring = new GameObject[300, 300];
    public int radius = 10;
    public float maxScale = 50;

    // Start is called before the first frame update
    void Start()
    {
        MakeRing();
        InvokeRepeating("MakeRing", 2.1f, 0.2f);
       
    }

    void MakeRing()
    {
        int numRings = 1;
        // After the first call of method when invoking make numRings 1
        if (!IsInvoking("MakeRing"))
        {
            numRings = 80;
        }
        //Get position of camera
        Vector3 centerPos = transform.position;
        centerPos.z += 15;
  

        for (int j = 0; j < numRings; j++)
        {
            centerPos.z += 1;
        
            for (int i = 0; i < numObjects; i++)
            {
                Vector3 vec = Quaternion.Euler(0, -90, 0) * Vector3.right;
                Quaternion rot = Quaternion.AngleAxis(i * 8, vec);
                Vector3 direction = rot * Vector3.up;

                Vector3 position = centerPos + (direction * radius);
                if (gameObjCount <= maxObj)
                {
                    GameObject instanceCube = (GameObject)Instantiate(Cube, position, rot);
                    //Use Mathf.Pingpong to go back and fourth through range of colours
                    instanceCube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Mathf.PingPong(Time.time * 1, 1), 1,1);

                    gameObjCount++;
                    ring[j, i] = instanceCube;

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {      
        for (int l = 0; l < numRings; l++)
        {
            for (int k = 0; k < numObjects; k++)
            {
                if (ring != null)
                {
                    ring[l,k].transform.localScale = new Vector3(1, (getAudioData.fa_samples[k] * maxScale) + 2, 1);
                }
            }
        }
    }
}
