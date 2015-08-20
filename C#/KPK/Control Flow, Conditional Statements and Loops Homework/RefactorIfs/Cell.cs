namespace RefactorIfs
{
    internal class Cell
    {
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.IsVisited = false;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsVisited { get; set; }

        public static bool IsInRange(Cell cell)
        {
            bool isInRangeOfX = cell.X <= Constants.Cell.MaxX && cell.X >= Constants.Cell.MinX;
            bool isInRangeOfY = cell.Y <= Constants.Cell.MaxY && cell.Y >= Constants.Cell.MinY;
            if (isInRangeOfX && isInRangeOfY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void VisitCell()
        {
            this.IsVisited = true;
        }
    }
}
