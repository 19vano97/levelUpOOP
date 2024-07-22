namespace Galaga_OOP;

public class Spaceship : PositionOfSubject
{
    #region variables

        protected Guid _id;
        protected char _symbolOfSpaceship;
        protected PlayersKindsEnum _player;
        protected string _playerName;
        protected int _healthPoint;
        protected ulong _speed;

    #endregion

    #region default ctors

        public Spaceship(int x, int y, PlayersKindsEnum playerKind)
        {

        }


    #endregion

    #region properties

        
        
    #endregion

    private void IsHero(PlayersKindsEnum playerKind)
    {
        if (playerKind.HasFlag(PlayersKindsEnum.Hero))
        {
            
        }
    }


}
