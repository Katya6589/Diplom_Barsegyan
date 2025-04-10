using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Chek : MonoBehaviour
{
    private int collisionCount = 0; // ������� ��������
    [SerializeField] GameObject _oknoVigrisha;
    [SerializeField] GameObject _oknoIgrovoe;

    void OnTriggerEnter(Collider other)
    {
        collisionCount++; // ����������� ������� �������� ��� ����� ������� ���������� � ������� �������� ����������
    }

    void OnTriggerExit(Collider other)
    {
        collisionCount--; // ��������� ������� �������� ��� ������ ������� ���������� �� �������� �������� ����������
    }

    void Update()
    {
        if (collisionCount >= 4)
        {
            _oknoIgrovoe.SetActive(false);
            _oknoVigrisha.SetActive(true);
        }
    }
}
