using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithing : MonoBehaviour
{

    public Animator Hammer_Down;
    public Animator Sword_Down;
    public GameObject Hammer_Dummy;
    public GameObject Sword_Dummy;
    public int Smacks = 0;
    public int Overheat_Meter = 0;
    public int Overheat_Limit = 10;
    private bool isOverHeated = false;
    //private float CoolDown = 1f;

    public bool counter;
    public int timer, delay;

    void Start()
    {
        InvokeRepeating("CoolDownOverheatMeter", 1f, 1f);
    }
    void Update()
    {         

        if (counter == true)
        {
            timer++;
        }

        if (timer > delay)
        {
            Hammer_Down.SetBool("Button_Clicked", false);
            counter = false;
            timer = 0;
        }
        if (!isOverHeated)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Smacks++;


                Hammer_Down.SetInteger("Limiter", Smacks);
                Hammer_Down.SetBool("Button_Clicked", true);
                Overheat_Meter++;
                counter = true;

                if (Smacks >= 10 & !isOverHeated)
                {
                    Hammer_Dummy.SetActive(false);
                    Sword_Dummy.SetActive(true);

                }

            }
        }

        else
        {

        }
        if (Overheat_Meter == Overheat_Limit)
        {
            isOverHeated = true;
        }
    }

    void CoolDownOverheatMeter()
    {
        if (Overheat_Meter > 0)
        {
            Overheat_Meter--;
        }
    }
}
