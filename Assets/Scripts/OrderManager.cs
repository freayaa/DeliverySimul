using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    public GameObject primaCollider;
    public GameObject sdachaCollider;
    public TextMeshProUGUI takeOrderText;
    public TextMeshProUGUI deliveredOrdersText;

    public List<Transform> points;

    private bool hasOrder = false;
    private int deliveredOrders = 0;

    private void Start()
    {
        Vector3 spawnPosition = points[Random.Range(0, points.Count)].position;
    }

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