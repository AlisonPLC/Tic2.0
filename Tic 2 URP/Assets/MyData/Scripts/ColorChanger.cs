using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public enum Collors { Red, Blue, Green}//this is for code porpouses

    public Material[] Colors;//this is for  A S T H E T I C  porpouses
    // element 1 - Red / element 2 - Blue / element 3 - Green
    Renderer rend;


    [SerializeField]
    private Collors plataformCollor;

    private GameObject target;
    private PlayerColorManager playerColorVariable;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void Update()
    {
        if (plataformCollor == Collors.Red)
        {
            rend.sharedMaterial = Colors[0];
        }
        else if (plataformCollor == Collors.Blue)
        {
            rend.sharedMaterial = Colors[1];
        }
        else
        {//plataformCollor == Collors.Green
            rend.sharedMaterial = Colors[2];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Our Hero Has touched us");
            target = other.gameObject;
            ColorChange();
        }
    }

    void ColorChange()
    {
        playerColorVariable = target.GetComponent<PlayerColorManager>();
        if (plataformCollor == Collors.Red)
        {
            playerColorVariable.ChangeToRed();
        }
        else if (plataformCollor == Collors.Blue)
        {
            playerColorVariable.ChangeToBlue();
        }
        /*else (plataformCollor == Collors.Green)
        {
            playerColorVariable.ChangeToGreen();
        }*/
    }
}