using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Keypad : MonoBehaviour
{

    //public Text Ans;
    public TMP_Text Ans;
    public GameObject New_BT;
    public string Answer = "1234";

    public int Input;

    public string K_State;


    public void Start()
    {
        K_State = "Lock";
        Input = 0;
        Ans.text = "";  //reset to nothing
    }


    public void Number(int number)
    {
        if (K_State == "Lock")
        {
        Ans.text += number.ToString();
        Input += 1;
        }
    }

    public void Enter()
    {
        if (K_State == "Lock")
        {
            if (Ans.text == Answer)
            {
                print("Correct");
                K_State = "Success";
                Ans.text = "" + K_State;
                New_BT.SetActive(true);
            }
            else
            {
                Reset();
            }
        }
    }

    public void Reset()
    {
        if (K_State == "Lock")
        {
            Input = 0;
            Ans.text = "";  //reset to nothing
        }
    }


    void Update()
    {
        if (K_State == "Lock")
        {
            if (Input > 8)
            {
                Input = 0;
                Ans.text = "";  //reset to nothing
            }
        }


    }
}
