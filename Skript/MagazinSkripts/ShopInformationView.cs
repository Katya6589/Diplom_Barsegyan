using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShopInformationView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopInformationView> Click;

    [SerializeField] private Sprite _standardBackground;
    [SerializeField] private Sprite _highlightBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockImage;

    [SerializeField] private IntValueView _priceView;

    [SerializeField] private Image _selectionText;

    private Image _backgroundImage;

    public Information_shop Item { get; private set; }
    public bool IsLock { get; private set; }

    public int Price => Item.Price;
    public GameObject Model => Item.Model;

    public void Initialize(Information_shop item)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standardBackground;

        Item = item;

        _contentImage.sprite = item.Image;
        _priceView.Show(Price);
    }


    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

    public void Lock()
    {
        IsLock = true;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Show(Price);
    }

    public void Unlock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Hide();
    }
    
    public void Select() => _selectionText.gameObject.SetActive(true);

    public void Unselect() => _selectionText.gameObject.SetActive(false);
    public void Highlight() => _backgroundImage.sprite = _highlightBackground;
    public void UnHighlight() => _backgroundImage.sprite = _standardBackground;
}
