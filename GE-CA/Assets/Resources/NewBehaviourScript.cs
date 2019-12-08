using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform cameraTarget;

    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.z += 5;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 2.0f);

    }

    private void OnDrawGizmos()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z += 10;
        Gizmos.DrawSphere(cameraPos,  1);
    }
}
