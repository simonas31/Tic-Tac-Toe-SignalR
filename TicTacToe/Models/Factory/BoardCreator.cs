using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class BoardCreator
    {

        /// <summary>
        /// create specific board
        /// </summary>
        /// <param name="type">dimensions for the board</param>
        /// <returns></returns>
        public ITicTacToeBoard FactoryMethod(int type)
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
            else
            {
                return null; // wanted type is not implemented
            }
        }
    }
}