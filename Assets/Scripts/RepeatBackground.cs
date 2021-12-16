using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.y  * 5.17f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < startPos.y - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
