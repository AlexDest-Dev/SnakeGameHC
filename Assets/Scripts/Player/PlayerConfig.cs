using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Game Configs/PlayerConfig", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _standardSpeed;
        [SerializeField] private float _feverSpeed;

        public float StandardSpeed => _standardSpeed;
        public float FeverSpeed => _feverSpeed;
    }
}