using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<Item> items;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool areAllItemsPresentInFirdge()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].isPresentFridge)
                return true;
        }

        return false;
    }
}
