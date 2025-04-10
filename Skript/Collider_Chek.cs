using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Chek : MonoBehaviour
{
    private int collisionCount = 0; // Счетчик коллизий
    [SerializeField] GameObject _oknoVigrisha;
    [SerializeField] GameObject _oknoIgrovoe;

    void OnTriggerEnter(Collider other)
    {
        collisionCount++; // Увеличиваем счетчик коллизий при входе другого коллайдера в триггер текущего коллайдера
    }

    void OnTriggerExit(Collider other)
    {
        collisionCount--; // Уменьшаем счетчик коллизий при выходе другого коллайдера из триггера текущего коллайдера
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
