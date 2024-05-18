using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Priem zakaza

public class TakeUpArea : MonoBehaviour
{
    public TextMeshProUGUI _order;

    public OrderManager UP;
    public PlayerPrefs playerPrefs;

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