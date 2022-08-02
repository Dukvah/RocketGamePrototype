using System.Collections;
using System.Collections.Generic;
using RocketGame.Controllers;
using RocketGame.Managers;
using UnityEngine;

namespace RocketGame.Abstracts.Controllers
{
 
    public abstract class WallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null && playerController.canMove)
            {
                GameManager.Instance.GameOver();
            }
        }
        
        
    }
   
}