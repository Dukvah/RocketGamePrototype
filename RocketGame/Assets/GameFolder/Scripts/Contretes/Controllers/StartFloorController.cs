using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketGame.Controllers
{
 
    public class StartFloorController : MonoBehaviour
    {
        private void OnCollisionExit(Collision other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
   
}