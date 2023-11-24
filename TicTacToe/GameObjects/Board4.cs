using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.GameObjects
{
    public class Board4 : Board
    {
        private IWinningStrategy winningStrategy;

        public Board4(CellFactory cellFactory) : base(cellFactory)
        {
            Set(4);
            winningStrategy = new FourByFourWinningStrategy();
        }

        public bool IsFourInRow
        {
            get
            {
                return winningStrategy.IsFourInRow(Pieces);
            }
        }

        public override bool GameEnded => this.IsFourInRow;
        private Stack<IBoardCommand> commandHistory = new Stack<IBoardCommand>();

        public void ExecuteCommand(IBoardCommand command)
        {
            command.Execute(this);
            commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (commandHistory.Count > 0)
            {
                IBoardCommand lastCommand = commandHistory.Pop();
                lastCommand.Undo(this);
            }
        }
    }
}