using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Animator _animator;
        private InputManager _inputManager;
        private PlayerLocomotion _playerLocomotion;
        
        public bool isInteracting;
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsInteracting = Animator.StringToHash("IsInteracting");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _inputManager = GetComponent<InputManager>();
            _playerLocomotion = GetComponent<PlayerLocomotion>();
        }
        
        private void Update()
        {
            _inputManager.HandleAllInput();
        }
        
        private void FixedUpdate()
        {
            _playerLocomotion.HandleAllMovement();
        }
        
        private void LateUpdate()
        {
            isInteracting = _animator.GetBool(IsInteracting);
            _playerLocomotion.isJumping = _animator.GetBool(IsJumping);
            _animator.SetBool(IsGrounded,_playerLocomotion.isGrounded);
        }
    }
}
