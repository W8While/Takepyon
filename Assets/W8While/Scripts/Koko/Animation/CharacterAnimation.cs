using UnityEngine;

namespace Game.Koko
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private Animator _animator;

        private Vector2 _speedProcent;

        private void Awake()
        {
            _speedProcent = Vector2.zero;
        }

        private void OnEnable()
        {
            _moveController.OnMove += Move;
            _moveController.OnJump += Jump;
        }

        private void Move(Vector2 obj, float moveSpeed)
        {
            _speedProcent = moveSpeed / _moveController.FastMoveSpeed * obj;
        }

        private void Update()
        {
            _animator.SetFloat("Forward", _speedProcent.y, 0.1f, Time.deltaTime);
            _animator.SetFloat("Side", _speedProcent.x, 0.1f, Time.deltaTime);
        }

        private void Jump()
        {
            if (_speedProcent.sqrMagnitude <= 0.01f)
                _animator.SetTrigger("PlaceJump");
            else
                _animator.SetTrigger("ForwardJump");

        }

        private void OnDisable()
        {
            _moveController.OnMove -= Move;
            _moveController.OnJump -= Jump;
        }
    }
}
