
using UnityEngine;

public class TakeDownArea : MonoBehaviour
{
    public OrderManager Down;

    private void Start()
    {
        Down = FindAnyObjectByType<OrderManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Down.CompleteDelivery();// ������� ����� ������ // ���� CompleteDelivery ���� ��� ������� ����� ������
        }
    }
}