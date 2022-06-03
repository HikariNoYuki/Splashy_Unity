using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    //public static System.Windows.Forms.Screen PrimaryScreen { get; }
    // Start is called before the first frame update
    [SerializeField] public GameObject Plateform;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition =
                    Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 8.0f));
                if (Plateform.transform.position.x < -2.5f)
                {
                    touchPosition.x = -2.5f;
                }
                else if(Plateform.transform.position.x > 2.5f)

                {
                    touchPosition.x = 2.5f;
                }
                transform.position = new Vector3(Plateform.transform.position.x - touchPosition.x, transform.position.y, transform.position.z);
            }
        }
    }
}
