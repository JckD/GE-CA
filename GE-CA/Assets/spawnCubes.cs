using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour
{

    public int numObjects = 50;
    public GameObject Cube;
    public int radius = 10;


    // Start is called before the first frame update
    void Start()
    {
        //Get position of camera
        Vector3 centerPos = Camera.main.transform.position;
        centerPos.z += 5;
        for (int j = 0; j < 20; j++)
        {
            centerPos.z += 1;
            for (int i = 0; i < numObjects; i++)
            {
                Vector3 vec = Quaternion.Euler(0, -90, 0) * Vector3.right;
                Quaternion rot = Quaternion.AngleAxis(i * 8, vec);
                Vector3 direction = rot * Vector3.up;

                Vector3 position = centerPos + (direction * radius);
                Instantiate(Cube, position, rot);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
