namespace OceanLife;

public class Obstacle : Cell
{
    #region varaibles

        protected int _numObstacles;

    #endregion

    #region default ctors

        public Obstacle(int x, int y) : base(x, y, Image.Obstacle)
        {
            _numObstacles = (int)Consts.DEFAULT_NUM_OBSTACLES;
        }
        
    #endregion

    #region prop


        
    #endregion
}
