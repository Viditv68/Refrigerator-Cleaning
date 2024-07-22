using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Transform parent;
    public void InstantiateItem()
    {
        Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 2.0f;       // we want 2m away from the camera position

        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        GameObject obj = Instantiate(item, objectPos, Quaternion.identity);
        obj.transform.SetParent(parent,false);
    }
}
