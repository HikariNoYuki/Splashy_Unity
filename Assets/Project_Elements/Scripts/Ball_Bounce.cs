using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Ball_Bounce : MonoBehaviour
{
    [SerializeField] public GameController GameController;
    private float moveDuration = 1.5f;
    [SerializeField] public  Ease moveEase = Ease.Linear;
    private int touchDone = 0;

    private int test = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Equals(touchDone,0))
        {
            BounceSequence();
            touchDone = 1;
        }
        
    }
    
    public void BounceSequence()
    {
        Vector3 offset = new Vector3(0.0f, 0.0f, 9.0f);
        Vector3 value = new Vector3(transform.position.x, 0.0f, transform.position.z);
        transform.DOJump((value + offset), 3.5f, 1, moveDuration).SetEase(moveEase);
    }
    

}
