# 3DUnity
作业项目

主要代码如下：

    using System.Collections; 
    using System.Collections.Generic;
    using UnityEngine;
 

    public class NewBehaviourScript : MonoBehaviour
    {
    private int[,] chessBoard = new int[3, 3];//抽象棋盘，表示棋盘的逻辑
    private int turn = 1;//决定到哪一方
 
    void Start()
    {
        Reset();//初始化界面
    }
    int checkWin()//判断胜负
    {
        for (int i = 0; i < 3; i++)
        {
            if (chessBoard[i, 0] == chessBoard[i, 1] && chessBoard[i, 0] == chessBoard[i, 2] && chessBoard[i, 0] != 0)
                return chessBoard[i, 0];//]
 
        }//竖着赢
        for (int i = 0; i < 3; i++)
        {
            if (chessBoard[0, i] == chessBoard[1, i] && chessBoard[0, i] == chessBoard[2, i] && chessBoard[0, i] != 0)
                return chessBoard[0, i];
        }//横着赢
 
        if (chessBoard[0, 0] == chessBoard[1, 1] && chessBoard[0, 0] == chessBoard[2, 2] && chessBoard[0, 0] != 0)
            return chessBoard[0, 0];//斜着赢
 
        if (chessBoard[2, 0] == chessBoard[1, 1] && chessBoard[2, 0] == chessBoard[0, 2] && chessBoard[2, 0] != 0)
            return chessBoard[2, 0];//斜着赢
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
 
        if (count == 9)//被填满仍无人胜利，平局
            return 0;
        return 3;
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(300, 50, 150, 50), "Start Game"))
        {
            Reset();//点击Start Game按钮重置游戏
        }
        GUISkin skin = GUI.skin;
        skin.button.normal.textColor = Color.green;
        skin.button.hover.textColor = Color.blue;//设置按钮样式
        int State = checkWin();//判断当前状态2:x赢1：O赢0：平局
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
                {//按钮没被点击时，被点击后改变棋盘状态，然后根据棋盘状态改变按钮显示
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
    {//重置棋盘
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

