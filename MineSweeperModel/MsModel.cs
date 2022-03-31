namespace MineSweeperModel
{
    public class GameProperties
    {
        public Difficulty Difficulty { get; set; }
        public int BombCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public enum Difficulty {Easy, Medium, Hard}
    public class MsModel
    {
        public GameProperties Init(Difficulty diff)
        {
            return null;
        }
        public void SetBombCount(int bc) { }
        public void SetSize(int x, int y) { }

        public MoveResult OpenCell(int x, int y)
        {
            return null;
        }
        public MoveResult SetFlag(bool set)
        {
            return null;
        }
    }

    public class MoveResult
    {
        public GameStatus Status { get; init; }
        public List<Cell> ChangedCells { get; init; }
    }

    public enum GameStatus { CONTINUE, WON, LOSS }
    public class Cell
    {

        public int X { init; get; }
        public int Y { init; get; }
        public int BombNeighbors { init; get; }
        public int IsBomb { init; get; }

    }
}