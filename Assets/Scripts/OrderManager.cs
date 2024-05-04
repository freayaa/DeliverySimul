using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public GameObject primaCollider;
    public GameObject sdachaCollider;
    public TextMeshProUGUI takeOrderText;
    public TextMeshProUGUI deliveredOrdersText;

    private bool hasOrder = false;
    private int deliveredOrders = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (primaCollider.GetComponent<Collider>().bounds.Intersects(transform.GetComponent<Collider>().bounds) && !hasOrder)
            {
                TakeOrder();
            }
            else if (sdachaCollider.GetComponent<Collider>().bounds.Intersects(transform.GetComponent<Collider>().bounds) && hasOrder)
            {
                DeliverOrder();
            }
        }
    }

    private void TakeOrder()
    {
        hasOrder = true;
        takeOrderText.text = "Заказ взят";
    }

    private void DeliverOrder()
    {
        takeOrderText.text = "Заказ сдан";
        hasOrder = false;
        deliveredOrders++;
        deliveredOrdersText.text = $"Сдано заказов: {deliveredOrders}";
    }
}