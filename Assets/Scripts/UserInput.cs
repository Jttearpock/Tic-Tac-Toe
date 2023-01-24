using System.Collections;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class UserInput : MonoBehaviour
{
    /// <summary>
    /// GLOBAL SCOPE CLASS MEMBER VARIABLES
    //	Project Name: TicTacToe
    //	Contribution: Creator
    //	Feature: Handles Input from Buttons/Checkboxes
    //	Start Date:	3/3/2021
    //	End Date: 3/5/2021
    //	References: https://venngage.com/blog/color-blind-friendly-palette/
    //	Links:	ENTERTUTORIAL USED (do not plagiarize any code)
    /// </summary>


    public DiagnosticGameManager myGameManager;

    //public GameObject CheckBoxGameObject;

    public void ResetBoard()
    {
        //Reset Grid Squares
        foreach (var grid in myGameManager.gameObjectArray)
        {
            grid.SetActive(true);
            grid.GetComponent<Renderer>().material = myGameManager.BaseMaterial;
            grid.GetComponent<DiagnosticButton>().haveIBeenClicked = false;
        }
        //Reset Grid Circles
        foreach (var diamond in myGameManager.gameGridDiamondsArray)
        {
            diamond.SetActive(false);
        }
        //Reset scoring & tracking variables
        myGameManager.gridArray = new int?[9];
        myGameManager.currentTurn = 0;
        myGameManager.turnCounter = 0;
        myGameManager.playerTurnText.text = "Player 1's Turn";
        myGameManager.playerTurnText.color = new Color(169f / 255f, 90f / 255f, 161f / 255f);
    }

    public void ActivateAI()
    {
        // CheckBoxGameObject.GetComponent<Toggle>().isOn
        if (this.GetComponent<Toggle>().isOn)
        {
            //ResetBoard();
            myGameManager.Player2IsAI = true;
            myGameManager.ComputerTurn();
        }
        else
        {
            myGameManager.Player2IsAI = false;
        }
    }
}