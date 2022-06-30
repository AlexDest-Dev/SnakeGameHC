using Player;
using Player.States;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerPrefab;
    [SerializeField] private PlayerConfig _playerConfig;
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<MobileInput>().AsSingle();
        Container.Bind<PlayerConfig>().FromScriptableObject(_playerConfig).AsSingle();
        Container.Bind<PlayerStateContainer>().FromFactory<PlayerStateContainerFactory>().AsSingle();
        PlayerMovement playerMovement = Container.InstantiatePrefabForComponent<PlayerMovement>(_playerPrefab);
        Container.Bind<PlayerMovement>().FromInstance(playerMovement).AsSingle();
    }
}