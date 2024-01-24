using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string TypeofButton;

    public int Num; //my assigned number

    public Keypad KP_script;

    public void Input()
    {
        if (TypeofButton == "Number")
        {
            KP_script.Number(Num);
        }

        if (TypeofButton == "Enter")
        {
            KP_script.Enter();
        }

        if (TypeofButton == "Reset")
        {
            KP_script.Reset();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Input();
        }
        
    }



    void Start()
    {

    }


    void Update()
    {

    }



}
