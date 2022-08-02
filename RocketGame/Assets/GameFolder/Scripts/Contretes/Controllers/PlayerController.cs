using System;
using System.Collections;
using System.Collections.Generic;
using RocketGame.Inputs;
using RocketGame.Managers;
using RocketGame.Movements;
using RocketGame.UIs;
using UnityEngine;

namespace RocketGame.Controllers
{ 
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject _menuCanvasObj;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;
        
        DefaultInput _input;
        Mover _mover;
        Rotator _rotator;
        Fuel _fuel;
        MenuCanvas _menuCanvas;

        bool _canMove;
        bool _canForceUp;
        float _leftRight;
        public bool canMove => _canMove;
        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();
            _menuCanvas = _menuCanvasObj.GetComponent<MenuCanvas>();
        }

        private void Start()
        {
            _canMove = true;
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += GameOverTriggered;
            GameManager.Instance.OnGameCompleted += GameCompletedTriggered;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= GameOverTriggered;
            GameManager.Instance.OnGameCompleted -= GameCompletedTriggered;
        }

        private void Update()
        {
            if (!_canMove) return;
            
            if (_input.IsForceUp && !_fuel.IsEmpty)
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
                _fuel.FuelIncrease(0.01f);
            }

            _leftRight = _input.LeftRight;
        }

        private void FixedUpdate()
        {
            if (_canForceUp)
            {
                _mover.FixedTick(_canForceUp);
                _fuel.FuelDecrease(0.2f);
            }
            _rotator.FixedTick(_leftRight);
        }
        
        private void GameOverTriggered()
        {
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
            _menuCanvas.LoseGame();
        }
        private void GameCompletedTriggered()
        {
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
            _menuCanvas.WinGame();
        }
    }
}

