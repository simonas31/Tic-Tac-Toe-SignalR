using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models;


public class BoardCreator
{

    /// <summary>
    /// create specific board
    /// </summary>
    /// <param name="type">dimensions for the board</param>
    /// <returns></returns>
    public static ITicTacToeBoard factoryMethod(int type)
    {
        if(type == 3)
        {
            return new Board3();
        }
        else if (type == 4)
        {
            return new Board4();
        }
        else if (type == 5)
        {
            return new Board5();
        }
        else if (type == 6)
        {
            return new Board6();
        }
        else if (type == 9)
        {
            Cell[,] megaBoard = new Cell[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    megaBoard[i, j] = new Cell(); // or initialize it with some default value if required
                }
            }
            return new MegaBoardAdapter(megaBoard);
        }
        else
        {
            return null; // wanted type is not implemented
        }
    }
}