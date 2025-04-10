using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    private List<ShopInformationView> _shopItems = new List<ShopInformationView>();

    [SerializeField] private Transform _itemsParent;

    public void Show(IEnumerable<Information_shop> items)
    {

    }
}
