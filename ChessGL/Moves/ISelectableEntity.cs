namespace ChessGL.Moves
{
    interface ISelectableEntity
    {
        public bool Selected { get; set; }
        bool Selectable { get; set; }
    }
}
