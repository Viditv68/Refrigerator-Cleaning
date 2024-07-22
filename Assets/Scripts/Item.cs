using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [SerializeField] private RectTransform rect;
    [SerializeField] private Animator anim;
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
            anim.enabled = true;
        }
        else
        {
            GameManager.Instance.chefController.gameObject.SetActive(true);
            GameManager.Instance.chefController.Init(false, "Please remove items from Fridge First");

            Destroy(gameObject);
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

        Debug.Log(collision.gameObject.name);
        if (!GameManager.Instance.isAnyItemPresentInFirdge())
        {
            canClean = true;
        }
    }


    public void OnAnimationbComplete()
    {
        GameManager.Instance.chefController.Init(false, "Good Job! Now keep items back in the fridge");
        Destroy(gameObject);
    }

}
