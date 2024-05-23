using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderManager : SOUNDS
{
    public GameObject TakeDownArea;
    public GameObject TakeUpArea;
    public int DeliveriesCompleted = 0;
    public bool IsBusy = false;
    public List<Transform> Points;

    public GameObject ActivePickUpPoint;
    public GameObject ActivePickDownPoint;

    public float money = 1;

    public TextMeshProUGUI ComplitOrderTXT;  //���������� ������� ������� �����
    public TextMeshProUGUI MoneyNum; // deneg zarabotano
    public TextMeshProUGUI DeliverOrderTXT;

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

            ComplitOrderTXT.text = $"����� �������: {DeliveriesCompleted}";
            MoneyNum.text = $"{money} ������";
            Destroy(ActivePickUpPoint);
            Destroy(ActivePickDownPoint);

            CreateNewOrder();

            money += Random.Range(100,190);
            DeliverOrderTXT.text = "�� ����� �����";
            PlaySound(sounds[0]);
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
            DeliverOrderTXT.text = "�� ����� �����";
            PlaySound(sounds[1]);
        }
    }
}