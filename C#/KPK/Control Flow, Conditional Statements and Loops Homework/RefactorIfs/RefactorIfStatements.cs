namespace RefactorIfs
{
    using System;

    internal class RefactorIfStatements
    {
        internal static void Main(string[] args)
        {
            #region PotatoStuff
            /* Potato potato;
            //... 
            if (potato != null)
                if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                    Cook(potato); */

            Potato potato = new Potato();

            if (potato != null)
            {
                if (!potato.IsPeeled && !potato.IsRotten)
                {
                    potato.Cook();
                }
            }
            #endregion

            #region MinMaxStuff
            /* if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
                    {
                        VisitCell();
                    } */
            Cell cell = new Cell(5, 10);
            if (Cell.IsInRange(cell))
            {
                cell.VisitCell();
            }
            #endregion
        }
    }
}
