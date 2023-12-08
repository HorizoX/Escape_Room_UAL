using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BarSystem : MonoBehaviour
{
    public GameObject CompletionBar;
    public GameObject BurnoutBar;
    public GameObject Sword;
    private const float MaxBurnoutBar = 1.0f;
    private const float MaxCompletionBar = 1.0f;
    private const float CompletionIncrement = 0.1f;
    public const float BurnoutIncrement = 0.2f;
    public const float DecrementRate = 0.1f;
    private const float MinimumScale = 0.0f;
    


    private void Awake()
    {
        // Set the completion bar to zero
        CompletionBar.transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        BurnoutBar.transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CompletionBar.transform.localScale += new Vector3(0, CompletionIncrement, 0);
            CompletionBar.transform.localScale = new Vector3(CompletionBar.transform.localScale.x, Mathf.Min(CompletionBar.transform.localScale.y, MaxCompletionBar), transform.localScale.z);
            BurnoutBar.transform.localScale += new Vector3(0, BurnoutIncrement, 0);
            BurnoutBar.transform.localScale = new Vector3(BurnoutBar.transform.localScale.x, Mathf.Min(BurnoutBar.transform.localScale.y, MaxBurnoutBar), transform.localScale.z);
        }
        //If Burnoutbar yscale i sequal to 1.0f, Destroy Sword
        if (BurnoutBar.transform.localScale.y == MaxBurnoutBar)
        {
            Destroy(Sword);
        }
    }
}
