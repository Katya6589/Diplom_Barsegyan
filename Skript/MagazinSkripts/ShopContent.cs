using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]

public class ShopContent : ScriptableObject
{
    [SerializeField] private List<CharterSkinInformation> _characterSkinInformation;

    public IEnumerable<CharterSkinInformation> CharterSkinInformation => _characterSkinInformation;

    private void OnValidate()
    {
        var charaterSkeinsDuplicates = _characterSkinInformation.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (charaterSkeinsDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_characterSkinInformation));

    }
}
