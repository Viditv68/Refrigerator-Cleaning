using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private RectTransform fridgePosition;
    [SerializeField] private RectTransform tablePosition;

    public bool isNearTable = false;
    public bool isNearFridge = false;
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
        if(isNearTable)
        {
            gameObject.transform.SetParent(tablePosition.gameObject.transform, true);
            rect.localPosition = new Vector3(0, 0, 0);
        }
        else if(isNearFridge)
        {
            // rect.localPosition = firdgePosition.localPosition; 
            gameObject.transform.SetParent(fridgePosition.gameObject.transform, true);
            rect.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Table")
        {
            Debug.Log("Triggered with table");
            isNearTable = true;
            isNearFridge = false;
        }
        else
        {
            Debug.Log("Triggered with fridge");
            isNearFridge = true;
            isNearTable = false;
        }
    }
}
