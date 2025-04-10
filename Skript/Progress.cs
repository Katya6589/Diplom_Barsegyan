using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Progress : MonoBehaviour
{
    public int Coins; //public �� �� ����� ����������� � ��� �� ����� ����
    public static Progress Instance;

    private void Awake() //����� �� ���� ��� �����, �� �� ����������� ��� ������� ��� �����
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;

            DontDestroyOnLoad(gameObject); //������� ���� �� ������� � ������� ������ � �������, ����� �� �� ����� ����������� ��� ������� ����� �������
        }
        else
        {
            Destroy(gameObject);
        }



    }
}
