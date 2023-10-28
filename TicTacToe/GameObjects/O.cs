using System.ComponentModel;
using Component = TicTacToe.Interfaces.Component;

namespace TicTacToe.GameObjects
{
    public class O : Piece, Component
    {
        public O(string value) : base(value)
        {
            
        }

        public string operation()
        {
            return base.Value;
        }
    }
}