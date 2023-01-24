using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DiagnosticGameManager : MonoBehaviour
{
    //TTT ARRAY ARRANGEMENT
    //[0][1][2] n 0 n
    //[3][4][5] n 0 1
    //[6][7][8] n 0 1

    // <summary>
    //	Project Name: TicTacToe
    //	Contribution: Creator
    //	Feature: Holds the core game data and runs the game
    //	Start Date:	3/3/2021
    //	End Date: 3/5/2021
    //	References: https://venngage.com/blog/color-blind-friendly-palette/
    //	Links:	ENTERTUTORIAL USED (do not plagiarize any code)
    // </summary>

    public int?[] gridArray;
    public int currentTurn = 0;
    public int turnCounter = 0;
    public GameObject[] gameObjectArray;
    public GameObject[] gameGridDiamondsArray;
    public Text playerTurnText;
    public bool Player2IsAI = false;

    public Material Player1Material;

    public Material BaseMaterial;

    //public Material Player2Material;


    //Check if a player has won & print win message
    public bool checkWinFunction()
    {
        int currentPlayer = currentTurn + 1;

        //Check Columns for Win
        for (int i = 0; i < 3; i++)
        {
            if (gridArray[i] != null && gridArray[i+3] != null && gridArray[i+6] != null)
            {
                if (gridArray[i] + gridArray[i + 3] + gridArray[i + 6] == currentTurn*3)
                {
                    print("Player " + currentPlayer + " wins along Column " + (i + 1));
                    playerTurnText.text = "Player " + currentPlayer + " Wins!";
                    return true;
                }
            }
        }
        //Check Rows for Win
        for (int i = 0; i < 7; i+=3)
        {
            if (gridArray[i] != null && gridArray[i + 1] != null && gridArray[i + 2] != null)
            {
                if (gridArray[i] + gridArray[i + 1] + gridArray[i + 2] == currentTurn * 3)
                {
                    print("Player " + currentPlayer + " wins along Row " + (i / 3 + 1));
                    playerTurnText.text = "Player " + currentPlayer + " Wins!";
                    return true;
                }
            }
        }
        //Check Diagonals for Win
        if (gridArray[0] != null && gridArray[4] != null && gridArray[8] != null )
        {
            if (gridArray[0] + gridArray[4] + gridArray[8] == currentTurn * 3)
            {
                print("Player " + currentPlayer + " wins along Diagonal Top Left -> Bottom Right");
                playerTurnText.text = "Player " + currentPlayer + " Wins!";
                return true;
            }
        }
        if (gridArray[2] != null && gridArray[4] != null && gridArray[6] != null)
        {
            if (gridArray[2] + gridArray[4] + gridArray[6] == currentTurn * 3)
            {
                print("Player " + currentPlayer + " wins along Diagonal Top Right -> Bottom Left");
                playerTurnText.text = "Player " + currentPlayer + " Wins!";
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        gridArray = new int?[9];
    }

    public void enterMove(int _index)
    {
        //Update both Arrays & Visuals with their new values
        if (gridArray[_index] == null)
        {
            gridArray[_index] = currentTurn;
            if (currentTurn == 0)
            {
                gameObjectArray[_index].GetComponent<Renderer>().material = Player1Material;
            }
            else
            {
                //gameObjectArray[_index].GetComponent<Renderer>().material = Player2Material;
                //gameObjectArray[_index].GetComponent<DiagnosticButton>().haveIBeenClicked = true;
                gameObjectArray[_index].SetActive(false);
                gameGridDiamondsArray[_index].SetActive(true);
            }
        }

        //Update the turnCounter
        turnCounter++;

        bool checkIfPlayerWon = checkWinFunction();

        if (checkIfPlayerWon == true && turnCounter >= 5)
        {
            foreach (var grid in gameObjectArray)
            {
                grid.GetComponent<DiagnosticButton>().haveIBeenClicked = true;
            }
        }
        else if (checkIfPlayerWon == false && turnCounter >= 9)
        {
            playerTurnText.text = "It's a tie.";
            playerTurnText.color = Color.white;
        }
        else
        {
            //Change to the next Player's Turn
            currentTurn++;
            if (currentTurn >= 2)
            {
                currentTurn = 0;
            }

            //Update the on screen text for the Player Turn
            playerTurnText.text = "Player " + (currentTurn + 1) + "'s Turn";

            if (currentTurn == 0)
            {
                playerTurnText.color = new Color(169f / 255f, 90f / 255f, 161f / 255f);
            }
            else
            {
                if (Player2IsAI == true)
                {
                    playerTurnText.text = "(Computer) Player " + (currentTurn + 1) + "'s Turn";
                }
                playerTurnText.color = new Color(245f / 255f, 121f / 255f, 58f / 255f);
            }
            //If Computer's Turn
            if (currentTurn == 1 && Player2IsAI == true)
            {
                ComputerTurn();
            }
        }

    }

    public async void ComputerTurn()
    {
        if (getTurn() == 1 && Player2IsAI == true)
        {
            for (int i = 0; i < 100;)
            {
                int computerMove = Random.Range(0, 9);
                if (gridArray[computerMove] == null)
                {
                    await Task.Delay(800);
                    enterMove(computerMove);
                    break;
                }
            }
        }

        
    }


    public int getTurn()
    {
        return currentTurn;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
