namespace OceanLife;

public class Obstacle : Cell
{
    #region varaibles

    #endregion

    #region default ctors

        public Obstacle(int x, int y) : base(x, y, Image.Obstacle)
        {
        }

        public Obstacle(Coordinates coord) : this(coord.X, coord.Y)
        {}

    #endregion

    #region prop



    #endregion

    public override void ReduceTTL()
    {}
}
