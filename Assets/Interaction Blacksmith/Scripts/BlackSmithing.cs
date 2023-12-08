using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackSmithing : MonoBehaviour
{

    public Animator Hammer_Down;
    public Animator Sword_Down;
    public GameObject Hammer_Dummy;
    public GameObject Sword_Dummy;
    public GameObject Sword;
    public GameObject CompletionBar;
    public GameObject BurnoutBar;
    public float MaxBurnoutBar = 1.1f;
    public float MaxCompletionBar = 1.0f;
    public float CompletionIncrement = 0.1f;
    public float BurnoutIncrement = 0.2f;
    public float DecrementRate = 0.1f;
    private const float MinimumScale = 0.0f;
    public int Overheat_Limit = 10;
    private bool isOverHeated = false;
    private const float ReloadTime = 3.0f;
    private float ReloadTimer = 0.0f;
    //private float CoolDown = 1f;

    public bool counter;
    public int timer, delay;

    public bool CountdownReset;

    //public AnimationClip Hit;
    //public Animation hamhit;


    void Start()
    {
        InvokeRepeating("CoolDownOverheatMeter", 1f, 1f);

        CountdownReset = false;

    }

    private void Awake()
    {
        // Set the completion bar to zero
        CompletionBar.transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        BurnoutBar.transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }

    void Update()
    {

        if (counter == true)
        {
            timer++;
        }

        if (timer > delay)
        {
            Hammer_Down.SetBool("Down_Clicked", false);
            counter = false;
            timer = 0;
        }
        if (!isOverHeated)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CompletionBar.transform.localScale += new Vector3(0, CompletionIncrement, 0);
                CompletionBar.transform.localScale = new Vector3(CompletionBar.transform.localScale.x, Mathf.Min(CompletionBar.transform.localScale.y, MaxCompletionBar), transform.localScale.z);
                BurnoutBar.transform.localScale += new Vector3(0, BurnoutIncrement, 0);
                BurnoutBar.transform.localScale = new Vector3(BurnoutBar.transform.localScale.x, Mathf.Min(BurnoutBar.transform.localScale.y, MaxBurnoutBar), transform.localScale.z);
                ReloadTimer = ReloadTime;
                Hammer_Down.SetFloat("Limiter", CompletionBar.transform.localScale.y);
               Hammer_Down.SetBool("Down_Clicked", true);
                counter = true;

                //hamhit.clip = Hit;

                //hamhit.Play();



            }
        }
        if (CompletionBar.transform.localScale.y >= 1.0f && !isOverHeated)
        {
            print("complete");

            Hammer_Dummy.SetActive(false);
            Sword_Dummy.SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                print("dunkwater");
                Sword_Down.SetBool("Space_Clicked", true);
                //Scene reloads after 3 seconds

                CountdownReset = true;
                //while (ReloadTimer > 0.0f)
                //{
                //    print("Time");
                //    ReloadTimer -= Time.deltaTime;
                //}
                //SceneManager.LoadScene("Blacksmith");

            }

        }


        float NewBurnoutBarScaleY = Mathf.Max(BurnoutBar.transform.localScale.y - DecrementRate * Time.deltaTime, MinimumScale);
        BurnoutBar.transform.localScale = new Vector3(BurnoutBar.transform.localScale.x, NewBurnoutBarScaleY, transform.localScale.z);


        if (BurnoutBar.transform.localScale.y >= 1 )
        {
            print("burnout");
            isOverHeated = true;
            Destroy(Sword);
            //while(ReloadTimer > 0.0f)
            //{
            //    print("Time");
            //    ReloadTimer -= Time.deltaTime;
            //}

            CountdownReset = true;
        }

        if (CountdownReset)
        {
            ReloadTimer -= Time.deltaTime;

            if (ReloadTimer < 0.0f)
            {
                SceneManager.LoadScene("Blacksmith");

            }
        }


        //if (Mathf.Approximately(NewBurnoutBarScaleY, MaxCompletionBar))
        //{
        //    print("burnout");
        //    isOverHeated = true;
        //    Destroy(Sword);
        //    ReloadTimer -= Time.deltaTime;
        //    if (ReloadTimer <= 0.0f)
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    }
        //}
    }
}
