using RocketGame.Managers;
using UnityEngine;

namespace RocketGame.Controllers
{
 
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _finishEffects;

        private void OnCollisionEnter(Collision collision)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController == null || !playerController.canMove) return;

            if (collision.GetContact(0).normal.y == -1)
            {
                _finishEffects.SetActive(true);
                GameManager.Instance.GameCompleted();
            }
            else
            {
                GameManager.Instance.GameOver();
            }
        }
    }
   
}