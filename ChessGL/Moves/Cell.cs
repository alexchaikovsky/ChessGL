using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ChessGL.Moves
{
    class Cell
    {
        private Point position;
        private string name;
        Cell(Point position, string name)
        {
            this.position = position;
            this.name = name;
        }
        public Point CellPosition 
        {
            get
            {
                return position;
            }
        }
        public bool Empty { get; set; }
    }
}
