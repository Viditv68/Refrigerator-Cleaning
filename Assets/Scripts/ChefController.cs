using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ChefController : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite sadSprite;
    [SerializeField] private Image image;
    [SerializeField] private GameObject tooltip;
    [SerializeField] private TextMeshProUGUI text;
    public void Init(bool _isHappy, string _text)
    {
        image.sprite = _isHappy ? happySprite : sadSprite;
        text.text = _text;



        rect.DOMoveY(-3, 1f).OnComplete(() =>
        {
            tooltip.SetActive(true);

            StartCoroutine(MoveCharacterOut());

        });
    }

    IEnumerator MoveCharacterOut()
    {

        yield return new WaitForSeconds(2f);
        tooltip.SetActive(false);
        rect.DOMoveY(-7, 1f);
    }
}
