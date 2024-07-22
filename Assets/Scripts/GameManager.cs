using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<Food> foods;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool areAllItemsPresentInFirdge()
    {
        for(int i = 0; i < foods.Count; i++)
        {
            if (foods[i].isNearTable)
                return true;
        }

        return false;
    }
}
