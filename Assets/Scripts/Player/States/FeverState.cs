namespace Player.States
{
    public class FeverState : IPlayerState
    {
        private readonly float _speed;
        public float Speed => _speed;

        public FeverState(float speed) => _speed = speed;
    }
}