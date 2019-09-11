using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int[,] chessBoard = new int[3, 3];
    private int turn = 1;

    void Start()
    {
        Reset();
    }
    int checkWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (chessBoard[i, 0] == chessBoard[i, 1] && chessBoard[i, 0] == chessBoard[i, 2] && chessBoard[i, 0] != 0)
                return chessBoard[i, 0];//]

        }
        for (int i = 0; i < 3; i++)
        {
            if (chessBoard[0, i] == chessBoard[1, i] && chessBoard[0, i] == chessBoard[2, i] && chessBoard[0, i] != 0)
                return chessBoard[0, i];
        }

        if (chessBoard[0, 0] == chessBoard[1, 1] && chessBoard[0, 0] == chessBoard[2, 2] && chessBoard[0, 0] != 0)
            return chessBoard[0, 0];

        if (chessBoard[2, 0] == chessBoard[1, 1] && chessBoard[2, 0] == chessBoard[0, 2] && chessBoard[2, 0] != 0)
            return chessBoard[2, 0];
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chessBoard[i, j] != 0)
                {
                    count++;
                }
            }
        }

        if (count == 9)
            return 0;
        return 3;
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(300, 50, 150, 50), "Start Game"))
        {
            Reset();
        }
        GUISkin skin = GUI.skin;
        skin.button.normal.textColor = Color.green;
        skin.button.hover.textColor = Color.blue;
        int State = checkWin();
        if (State == 2)
        {

            skin.button.normal.textColor = Color.red;
            GUI.Label(new Rect(300, 105, 50, 50), "X Win!");
        }
        else if (State == 1)
        {
            skin.button.normal.textColor = Color.red;
            GUI.Label(new Rect(300, 105, 50, 50), "O Win");
        }
        else if (State == 0)
        {
            skin.button.normal.textColor = Color.red;
            GUI.Label(new Rect(300, 105, 50, 50), "Tied");
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chessBoard[i, j] == 1)
                {
                    // GUI.Label(new Rect(400, 105, 50, 50), "X's turn.");
                    GUI.Button(new Rect(300 + 50 * i, 130 + j * 50, 50, 50), "O");
                }
                else if (chessBoard[i, j] == 2)
                {
                    //GUI.Label(new Rect(400, 105, 50, 50), "O's turn.");
                    GUI.Button(new Rect(300 + 50 * i, 130 + j * 50, 50, 50), "X");
                }

                if (GUI.Button(new Rect(300 + 50 * i, 130 + j * 50, 50, 50), ""))
                {
                    if (State == 3)
                    {
                        if (turn == 1)
                            chessBoard[i, j] = 1;
                        else if (turn == -1)
                            chessBoard[i, j] = 2;
                        turn = -turn;
                    }
                }
            }
        }



    }

    void Reset()
    {
        turn = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                chessBoard[i, j] = 0;
            }
        }
    }

    void Update()
    {

    }
}