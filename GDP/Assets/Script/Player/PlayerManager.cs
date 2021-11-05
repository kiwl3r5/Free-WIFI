﻿using System;
using Script.Manager;
using UnityEngine;
using UnityEngine.UI;
namespace Script.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Animator _animator;
        private InputManager _inputManager;
        private PlayerLocomotion _playerLocomotion;
        [SerializeField] private Image healthBar;
        [SerializeField] private float hp = 100;
        private float maxHp;
        public bool godmode = false;

        public bool isInteracting;
        private static readonly int IsInteracting = Animator.StringToHash("IsInteracting");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _inputManager = GetComponent<InputManager>();
            _playerLocomotion = GetComponent<PlayerLocomotion>();
            maxHp = hp;
            healthBar.fillAmount = hp/maxHp;
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

        public void OnTakeDamage(int damageReceive)
        {
            if (!godmode)
            {
                GameManager.Instance.TakeDmgUI(true);
                hp -= damageReceive;
                Invoke(nameof(ResetDmgUI), 0.7f);
            }
            healthBar.fillAmount = hp/maxHp;
            if (hp<=0)
            {
                GameManager.Instance.GameOverUI(true);
            }
        }

        private void ResetDmgUI()
        {
            GameManager.Instance.TakeDmgUI(false);
        }
    }
}