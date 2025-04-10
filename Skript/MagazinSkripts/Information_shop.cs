using UnityEngine;

public abstract class Information_shop : ScriptableObject
{
    [field: SerializeField] public GameObject Model { get; private set; }

    [field: SerializeField] public Sprite Image { get; private set; }

    [field: SerializeField, Range(0, 1000)] public int Price { get; private set; }
}
