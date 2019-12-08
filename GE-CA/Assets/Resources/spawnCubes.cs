using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour
{

    public int numObjects = 50;
    public GameObject Cube;
    public GameObject[,] ring = new GameObject[300, 300];
   
    public int radius = 10;
    public float maxScale = 50;


    // Start is called before the first frame update
    void Start()
    {
        //Get position of camera
        Vector3 centerPos = Camera.main.transform.position;
        centerPos.z += 5;
       for (int j = 0; j < 40; j++)
       {
            centerPos.z += 1;
            for (int i = 0; i < numObjects; i++)
            {
                Vector3 vec = Quaternion.Euler(0, -90, 0) * Vector3.right;
                Quaternion rot = Quaternion.AngleAxis(i * 8, vec);
                Vector3 direction = rot * Vector3.up;

                Vector3 position = centerPos + (direction * radius);
                GameObject instanceCube = (GameObject)Instantiate(Cube, position, rot);

                ring[j,i] = instanceCube;
                //tunnel[j] = ring[i];

            }
            
        }
        Debug.Log(ring.Length);
        Debug.Log(getAudioData.fa_samples.Length);
    }

    // Update is called once per frame
    void Update()
    {
        for (int l = 0; l < 40; l++)
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
