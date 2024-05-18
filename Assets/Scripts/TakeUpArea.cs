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
            ON();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        OFF();
    }
    public void ON()
    {
        _order.gameObject.SetActive(true);
    }
    public void OFF()
    {
        _order.gameObject.SetActive(false);
    }

}
//UP.PickUpNewDelivery(); //область приёма