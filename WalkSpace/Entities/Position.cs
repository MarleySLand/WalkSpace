namespace WalkSpace.Entities
{
    public class Position
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Position(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public void ChangePos(int row, int column)
        {
            Rows = row;
            Columns = column;
        }

        public override string ToString()
        {
            return Rows
                + ", "
                + Columns;
        }
    }

}
