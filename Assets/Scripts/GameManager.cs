using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<Food> foods;
    public ChefController chefController;

    private string text = "Start cleaning the fridge";


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        chefController.Init(true, text);
    }

    public bool isAnyItemPresentInFirdge()
    {
        for(int i = 0; i < foods.Count; i++)
        {
            if (foods[i].isNearFridge)
                return true;
        }

        return false;
    }
}
