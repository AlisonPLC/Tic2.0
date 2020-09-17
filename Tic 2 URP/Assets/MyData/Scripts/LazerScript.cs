using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LazerScript : MonoBehaviour
{
    public Material[] Colors;
    //element 0 - standart /  element 1 - Red / element 2 - Blue / element 3 - Green
    public enum WallColors { Standart, Red , Blue , Green }

    [SerializeField]
    private WallColors wallColors;

    //public Material dissolve;

    Renderer rend;

    private GameObject target;
    PlayerColorManager targuerScript;
    private PlayerColorManager playerColorVariable;
    private PlayerMovement playerMovementVariable;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    private void Update()
    {
        if (wallColors == WallColors.Red)
        {
            rend.sharedMaterial = Colors[1];
            gameObject.tag = "RedWall";
        }
        else if (wallColors == WallColors.Blue)
        {
            rend.sharedMaterial = Colors[2];
            gameObject.tag = "BlueWall";
        }
        else
        {//plataformCollor == Collors.Green
            rend.sharedMaterial = Colors[3];
            gameObject.tag = "GreenWall";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            targuerScript = target.gameObject.GetComponent<PlayerColorManager>();
            switch (wallColors)
            {
                case WallColors.Red:
                    // IF THE WALL IS RED
                    if (targuerScript.currentPlayerCollors == PlayerColorManager.PlayerCollors.Red)
                    {
                        break;
                    }
                    else
                    {
                        StartCoroutine(DissolveCorrotine());
                    }
                    break;
                case WallColors.Blue:
                    // IF THE WALL IS bLUE
                    if (targuerScript.currentPlayerCollors == PlayerColorManager.PlayerCollors.Blue)
                    {
                        break;
                    }
                    else
                    {
                        StartCoroutine(DissolveCorrotine());
                    }
                    break;
                    
                case WallColors.Green:
                    // IF THE WALL IS GREEN
                    if (targuerScript.currentPlayerCollors == PlayerColorManager.PlayerCollors.Red)
                    {
                        break;
                    }
                    else
                    {
                        StartCoroutine(DissolveCorrotine());
                    }
                    break;
                default:
                    Debug.Log("SWITCH on LazerScript Returned Default");
                    break;
            }
            //check player collor and compare to the wall, if the collor is diferent apply the Dissolve
            /* target = other.gameObject;
             targuerScript = target.gameObject.GetComponent<PlayerColorManager>();
             if (targuerScript.currentPlayerCollors == PlayerColorManager.PlayerCollors.Red)
             {
             StartCoroutine(DissolveCorrotine());
             }else if (targuerScript.currentPlayerCollors == PlayerColorManager.PlayerCollors.Blue)
             {

             }else if (1==1)
             {

             }*/
        }
    }

    IEnumerator DissolveCorrotine()
    {
        playerMovementVariable = target.GetComponent<PlayerMovement>();
        playerMovementVariable.ControlesON = false;
        playerColorVariable = target.GetComponent<PlayerColorManager>();
        playerColorVariable.Dissolve();

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
