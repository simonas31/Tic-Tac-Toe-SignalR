namespace TicTacToe.GameObjects
{
    // Flyweight: Common interface for concrete flyweights
    public interface ICell
    {
        string Value { get; set; }
        string GetStatus();
        void Set(string v);
    }

    // Concrete Flyweight: Represents the intrinsic state of a cell
    public class Cell : ICell
    {
        public string Value { get; set; }

        public Cell()
        {
            Value = "";
        }

        public Cell(string value)
        {
            Value = value;
        }

        public void Set(string value)
        {
            Value = value;
        }

        public string GetStatus()
        {
            return "general";
        }

        public override string ToString()
        {
            return Value;
        }
    }

    // Flyweight Factory: Creates and manages flyweight objects
    public class CellFactory
    {
        private Dictionary<string, ICell> cellPool = new Dictionary<string, ICell>();

        public ICell GetCell(int row, int column)
        {
            string key = $"{row}-{column}";

            if (!cellPool.TryGetValue(key, out ICell cell))
            {
                cell = new Cell();
                cellPool[key] = cell;
            }

            return cell;
        }
    }
}
