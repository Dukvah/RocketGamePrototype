using RocketGame.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace RocketGame.UIs
{
 
    public class FuelSlider : MonoBehaviour
    {
        Slider _slider;
        Fuel _fuel;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _fuel = FindObjectOfType<Fuel>();
        }

        private void Update()
        {
            _slider.value = _fuel.CurrentFuel;
        }
    }
   
}