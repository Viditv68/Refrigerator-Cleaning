using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{

    [SerializeField] private RectTransform rect;
    [SerializeField] private Animator anim;
    [SerializeField] int score;
    public bool isPresentFridge;
    private bool canClean = false;



    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isPresentFridge = true;
        if (!GameManager.Instance.isAnyItemPresentInFirdge())
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




    public void OnAnimationbComplete()
    {
        GameManager.Instance.IncrementScore(score);
        GameManager.Instance.chefController.Init(false, "Good Job! Now keep items back in the fridge");
        Destroy(gameObject);
    }

}
