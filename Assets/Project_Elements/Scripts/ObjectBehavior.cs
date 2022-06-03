using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    public Transform targetObject;
    private float initialOffset;
    private float objectPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position.z - targetObject.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        objectPosition = targetObject.position.z + initialOffset;
        transform.position = new Vector3(transform.position.x, transform.position.y, objectPosition);
    }
}
