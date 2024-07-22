using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [SerializeField] private RectTransform rect;
    public bool isPresentFridge;
    private bool canClean = false;

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();

        if(canClean)
        {
            Debug.Log("Clean started");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isPresentFridge = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!GameManager.Instance.areAllItemsPresentInFirdge())
        {
            canClean = true;
        }
    }

}
