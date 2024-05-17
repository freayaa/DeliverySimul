using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameObject TakeDownArea;
    public GameObject TakeUpArea;
    public int DeliveriesCompleted = 0;
    public bool IsBusy = false;
    public List<Transform> Points;

    public GameObject ActivePickUpPoint;
    public GameObject ActivePickDownPoint;

    private void Start()
    {
        CreateNewOrder();
    }

    public void CompleteDelivery()
    {
        if (IsBusy)
        {
            DeliveriesCompleted++;
            IsBusy = false;
            Destroy(ActivePickUpPoint);
            Destroy(ActivePickDownPoint);
            CreateNewOrder();
        }
    }

    public void CreateNewOrder()
    {
        Vector3 pickUpPointPosition = CreateNewPoint();

        ActivePickUpPoint = Instantiate(TakeUpArea, pickUpPointPosition, Quaternion.identity);

        Vector3 deliveryPointPosition = CreateNewPoint();

        while (deliveryPointPosition == pickUpPointPosition)
        {
            deliveryPointPosition = CreateNewPoint();
        }

        ActivePickDownPoint = Instantiate(TakeDownArea, deliveryPointPosition, Quaternion.identity);
    }

    public Vector3 CreateNewPoint()
    {
        return Points[Random.Range(0, Points.Count)].position;
    }

    public void PickUpNewDelivery()
    {
        if (IsBusy == false)
        {
            IsBusy = true;
        }
    }
}