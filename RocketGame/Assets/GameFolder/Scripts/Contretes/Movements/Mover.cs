using System.Collections;
using System.Collections.Generic;
using RocketGame.Controllers;
using UnityEngine;

namespace RocketGame.Movements
{
 
    public class Mover
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(bool isForceUp)
        {
            if (isForceUp)
            {
                _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * _playerController.Force);
            }
        }
    }   
}
