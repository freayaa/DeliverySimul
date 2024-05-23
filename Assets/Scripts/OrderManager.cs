using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OrderManager : SOUNDS
{
    public float ost;
    public TextMeshProUGUI ostTXT;

    public GameObject TakeDownArea;
    public GameObject TakeUpArea;
    public int DeliveriesCompleted ;
    public bool IsBusy = false;
    public List<Transform> Points;

    public GameObject ActivePickUpPoint;
    public GameObject ActivePickDownPoint;

    public float money = 1;

    public TextMeshProUGUI ComplitOrderTXT;  //Показывает сколько заказов сдано
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

            ComplitOrderTXT.text = $"Сдано заказов: {DeliveriesCompleted}";
            MoneyNum.text = $"{money} рублей";
            Destroy(ActivePickUpPoint);
            Destroy(ActivePickDownPoint);
            ostTXT.text = $"{ost}";

            CreateNewOrder();

            money += Random.Range(100,190);
            ost -= money;
            DeliverOrderTXT.text = "Вы сдали заказ";
            PlaySound(sounds[0]);
        }
    }
    private void Update()
    {
        GameEnd();
    }
    private void GameEnd()
    {
        if (ost < 0)
        {
            SceneManager.LoadScene(2);
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
            DeliverOrderTXT.text = "Вы взяли заказ";
            PlaySound(sounds[1]);
        }
    }
}