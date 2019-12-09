using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour
{

    public int numObjects = 50;
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
        //Invoke("MakeRing", 0.0f);
        InvokeRepeating("MakeRing", 0.0f, 2.0f);
        //Get position of camera
        Vector3 centerPos = Camera.main.transform.position;
        centerPos.z += 10;
        float rand;
        for (int j = 0; j < 20; j++)
        {
            centerPos.z += 1;
            rand = Random.value;
            for (int i = 0; i < numObjects; i++)
            {
                Vector3 vec = Quaternion.Euler(0, -90, 0) * Vector3.right;
                Quaternion rot = Quaternion.AngleAxis(i * 8, vec);
                Vector3 direction = rot * Vector3.up;

                Vector3 position = centerPos + (direction * radius);
                if (gameObjCount <= maxObj)
                {
                    GameObject instanceCube = (GameObject)Instantiate(Cube, position, rot);
                    instanceCube.GetComponent<Renderer>().material.color = Color.HSVToRGB(rand, 1, 1);

                    gameObjCount++;
                    ring[j, i] = instanceCube;

                }

                //tunnel[j] = ring[i];

            }
        }
        Debug.Log(ring.Length);
        Debug.Log(getAudioData.fa_samples.Length);
    }

    void MakeRing()
    {
        numRings++;
        //Get position of camera
        Vector3 centerPos = Camera.main.transform.position;
        centerPos.z += 20;
        float rand;

        for (int j = 0; j < 40; j++)
        {
            centerPos.z += 1;
            rand = Random.value;
            for (int i = 0; i < numObjects; i++)
            {
                Vector3 vec = Quaternion.Euler(0, -90, 0) * Vector3.right;
                Quaternion rot = Quaternion.AngleAxis(i * 8, vec);
                Vector3 direction = rot * Vector3.up;

                Vector3 position = centerPos + (direction * radius);
                if (gameObjCount <= maxObj)
                {
                    GameObject instanceCube = (GameObject)Instantiate(Cube, position, rot);
                    instanceCube.GetComponent<Renderer>().material.color = Color.HSVToRGB(rand, 1, 1);

                    gameObjCount++;
                    ring[j, i] = instanceCube;

                }

                //tunnel[j] = ring[i];

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        //
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
