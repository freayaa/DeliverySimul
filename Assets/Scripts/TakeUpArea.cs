using UnityEngine;


// Priem zakaza

public class TakeUpArea : MonoBehaviour
{
    public OrderManager UP;

    private void Start()
    {
        UP = FindAnyObjectByType<OrderManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            UP.PickUpNewDelivery(); //область приёма
        }
    }

}
//UP.PickUpNewDelivery(); //область приёма