using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TicTacToe
{
    public class Logic
    {
        private int[,] _ResultArray = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private int Turn = 0;
        private int Player = 1;
        private int _Result = 0;

        public int Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        public void ClearResultArray()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _ResultArray[i, j] = 0;
                }
            }
        }

        public string GameTurn(int Pos)
        {
            Turn++;
            string PlayerMark;
            bool EndGame = false;
            if (Player == 1)
            {
                PlayerMark = "O";
                EndGame = DetermineArrayElement(Pos, 1);
                if (EndGame == true)
                {
                    _Result = Player;
                }
                Player = 2;
            }
            else
            {
                PlayerMark = "X";
                EndGame = DetermineArrayElement(Pos, 2);
                if (EndGame == true)
                {
                    _Result = Player;
                }
                Player = 1;
            }

            return PlayerMark;
        }

        public Boolean DetermineArrayElement(int Pos, int Player)
        {
            int counter = 1;
            int Row = 0;
            int Column = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (counter == Pos)
                    {
                        Row = i;
                        Column = j;
                    }
                    counter++;
                }
            }
            return CheckResultArray(Row, Column, Player);
        }

        public void ClearLogic()
        {
            ClearResultArray();
            Player = 1;
            Turn = 0;
            _Result = 0;
        }

        public Boolean CheckResultArray(int Row, int Column, int Player)
        {
            _ResultArray[Row, Column] = Player;
            for (int i = 0; i < 3; i++)
            {
                if (_ResultArray[i, 0] == _ResultArray[i, 1] && _ResultArray[i, 2] == _ResultArray[i, 1] && _ResultArray[i, 1] != 0) { return true; }
                if (_ResultArray[0, i] == _ResultArray[1, i] && _ResultArray[2, i] == _ResultArray[1, i] && _ResultArray[1, i] != 0) { return true; }
            }
            if (_ResultArray[0, 0] == _ResultArray[1, 1] && _ResultArray[2, 2] == _ResultArray[1, 1] && _ResultArray[1, 1] != 0) { return true; }
            if (_ResultArray[0, 2] == _ResultArray[1, 1] && _ResultArray[2, 0] == _ResultArray[1, 1] && _ResultArray[1, 1] != 0) { return true; }
            if (Turn == 9)
            {
                _Result = 3;
            }
            return false;
        }
    }
}