using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorManager : MonoBehaviour
{

    public Material[] Colors;
    //element 0 - standart / element 1 - Dissolve / element 2 - Red / element 3 - Blue / element 4 - Green
    public enum PlayerCollors {Standart=1 ,Red = 2,Blue=3,Green=4}
    public PlayerCollors currentPlayerCollors;

    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    public void ChangeToStart()
    {
        //element 0 - standart
        rend.sharedMaterial = Colors[0];
        gameObject.layer = 0;
    }
    public void Dissolve()
    {
        //element 1 - Dissolve
        rend.sharedMaterial = Colors[1];
    }
    public void ChangeToRed()
    {
        //element 2 - Red
        rend.sharedMaterial = Colors[2];
        currentPlayerCollors = PlayerCollors.Red;
        gameObject.layer = 8;

    }
    public void ChangeToBlue()
    {
        //element 3 - Blue
        rend.sharedMaterial = Colors[3];
        currentPlayerCollors = PlayerCollors.Blue;
        gameObject.layer = 9;
    }
    //Add ChangeToGreen later
    //element 4 - Green
    //currentPlayerCollors = PlayerCollors.Green;
    //gameObject.layer = 10;

}
