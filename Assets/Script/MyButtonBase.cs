using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButtonBase : Button
{
    public GameManager GM;

    public override void OnPointerClick(PointerEventData eventData)
    {
        GM.OnClick();
    }

    protected override void Start()
    {
        GM = GameManager.singleton;
    }
}
