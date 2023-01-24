using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosticButton : MonoBehaviour
{

	//TTT ARRAY ARRANGEMENT
	//[0][1][2]
	//[3][4][5]
	//[6][7][8]

	// <summary>
    //	Project Name: TicTacToe
	//	Contribution: Creator
	//	Feature: Handles click events by player
	//	Start Date:	3/3/2021
	//	End Date: 3/5/2021
	//	References: https://venngage.com/blog/color-blind-friendly-palette/
	//	Links:	ENTERTUTORIAL USED (do not plagiarize any code)
	// </summary>

	public int myNumericID;
	public bool haveIBeenClicked;
    public int myValue;

	public DiagnosticGameManager myGameManager;

    private void OnMouseDown()
	{
		//If no AI, players can click
        if (myGameManager.Player2IsAI == false)
        {
			if (haveIBeenClicked == false)
            {
                interactiveFunction(myNumericID);
            }
		}
        else
        {
			//If AI is active, only allow click on Player 1's Turn
            if (myGameManager.currentTurn == 0)
            {
				if (haveIBeenClicked == false)
                {
                    interactiveFunction(myNumericID);
                }
			}
        }

	}

	public void interactiveFunction(int _indexID = -1)
	{
		
		if (_indexID >= 0 && haveIBeenClicked == false)
		{
			int currentPlayerTurn = myGameManager.getTurn();
			myGameManager.GetComponent<DiagnosticGameManager>().enterMove(_indexID);
            myValue = currentPlayerTurn + 1;
        }
		haveIBeenClicked = true;
	}



	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
