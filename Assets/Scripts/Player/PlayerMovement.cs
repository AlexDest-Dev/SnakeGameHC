using Player.States;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private IInput _input;
        private PlayerStateContainer _stateContainer;

        [Inject]
        public void Construct(IInput input, PlayerStateContainer stateContainer)
        {
            _input = input;
            _stateContainer = stateContainer;
        }

        private void Update()
        {
            var horizontalDirection = _input.GetDeltaPosition().x;
            Move(horizontalDirection, _stateContainer.CurrentState.Speed);
        }

        private void Move(float horizontalDirection, float speed)
        {
            float distance = speed * Time.deltaTime;
            Vector3 currentPosition = transform.position;
            Vector3 direction = new Vector3(horizontalDirection, 0f, 1f);
            var newHorizonatalPosition = (currentPosition + direction * speed * Time.deltaTime).x;
            if(TryHorizontalMovement(direction, newHorizonatalPosition))
                transform.Translate(direction * distance);
            else 
                transform.Translate(Vector3.forward * distance);
        }
        
        //TODO: Borders from instance of Field
        private bool TryHorizontalMovement(Vector3 direction, float newHorizonatalPosition)
        {
            return direction.x switch
            {
                < 0 when newHorizonatalPosition < -4.5 => false,
                > 0 when newHorizonatalPosition > 4.5 => false,
                _ => true
            };
        }
    }
}