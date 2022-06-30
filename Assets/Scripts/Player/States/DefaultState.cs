namespace Player.States
{
    public class DefaultState : IPlayerState
    {
        private readonly float _speed;
        public float Speed => _speed;

        public DefaultState(float speed) => _speed = speed;
    }
}