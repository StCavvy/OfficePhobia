using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
   [SerializeField] InputAction flashLightControll;
   [SerializeField] Light flashLight;

    void Start()
    {
        flashLightControll.Enable();
    }

   
    void Update()
    {
        if (flashLightControll.triggered)
        {
            FlashlightController();
        }

    }

    void FlashlightController() 
    {
        if (flashLight.enabled == false) flashLight.enabled = true ;
        else if (flashLight.enabled == true) flashLight.enabled = false;
    }
}
