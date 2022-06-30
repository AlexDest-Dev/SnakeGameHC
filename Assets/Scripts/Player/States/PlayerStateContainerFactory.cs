namespace Player.States
{
    public class PlayerStateContainerFactory : IPlayerStateContainerFactory
    {
        private readonly PlayerConfig _playerConfig;

        public PlayerStateContainerFactory(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
        }
        public PlayerStateContainer Create()
        {
            IPlayerState[] states = {
                new DefaultState(_playerConfig.StandardSpeed),
                new FeverState(_playerConfig.FeverSpeed),
            };
            PlayerStateContainer newStateContainer = new PlayerStateContainer(states);
            newStateContainer.ChangeState<DefaultState>();
            return newStateContainer;
        }
    }
}