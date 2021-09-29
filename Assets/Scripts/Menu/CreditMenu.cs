using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMenu : MonoBehaviour
{
    public RectTransform nameCanvas;
    public RectTransform[] names;

    private Vector2 tmpPos;

    public float speed = 1f;

    private void Start()
    {
        tmpPos = Vector2.zero;
        tmpPos.y = -nameCanvas.rect.height;
        names[0].anchoredPosition = tmpPos;

        for (int i = 1; i < names.Length; i++)
        {
            tmpPos = Vector2.zero;
            tmpPos.y = names[i - 1].anchoredPosition.y - names[i - 1].rect.height;
            names[i].anchoredPosition = tmpPos;
        }
    }

    private void Update()
    {
        tmpPos = names[0].anchoredPosition;
        //print("1 : "+tmpPos.y + " : " + Time.deltaTime);
        tmpPos.y = tmpPos.y + Time.deltaTime * speed;
        //print("2 : " + tmpPos.y + " : " + Time.deltaTime);
        names[0].anchoredPosition = tmpPos;

        for (int i = 1; i < names.Length; i++)
        {
            tmpPos = Vector3.zero;
            tmpPos.y = names[i - 1].anchoredPosition.y - names[i - 1].rect.height;
            names[i].anchoredPosition = tmpPos;
        }

        if (names[0].anchoredPosition.y >= names[0].rect.height)
        {
            RectTransform tmpRec = names[0];

            for (int i = 1; i < names.Length; i++)
            {
                names[i - 1] = names[i];
            }
            names[names.Length - 1] = tmpRec;
        }
    }
}
