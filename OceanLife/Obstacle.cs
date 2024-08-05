namespace OceanLife;

public class Obstacle : Cell
{
    #region varaibles

    #endregion

    #region default ctors

        public Obstacle(int x, int y) : base(x, y, Image.Obstacle)
        {
        }

    #endregion

    #region prop



    #endregion

    public override void ReduceTTL()
    {}
}
