using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Platefrom : MonoBehaviour
{
    [SerializeField]
    public GameController GameController;
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("Plateform"))
        {
            
            GameController.score++;
            GameController.Ball.BounceSequence();
            
            
           if (GameController.count == 16)
            {
                GameObject lastPlateform = Instantiate(gameObject, new Vector3(transform.position.x, 0, transform.position.z +24), Quaternion.identity);
                lastPlateform.tag = "Last_Plateform";
                lastPlateform.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                Slide script = lastPlateform.GetComponent<Slide>();
                script.Plateform = lastPlateform;
                GameController.count++;
            }
            else if(GameController.count < 16)
            {
                GameObject plateform = Instantiate(gameObject,
                    new Vector3((float)(rand.NextDouble()*4-2), transform.position.y, transform.position.z + 24),
                    Quaternion.identity);
                plateform.tag = "Plateform";
                Slide script = plateform.GetComponent<Slide>();
                script.Plateform = plateform;
                
                plateform.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                GameController.count++;
            }

            Destroy(this);

        }
        else if (collision.gameObject.CompareTag("Ball") && gameObject.CompareTag("Last_Plateform"))
        {
            GameController.Ball.GetComponent<Renderer>().material.SetColor( "_Color",Color.green); //Win
        }
        else
        {
            Destroy(GameController.Ball); //Lose
        }
    }
}
