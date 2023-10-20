using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pet4Behavior : MonoBehaviour
{
    private void Start()
    {
        Tween moveTween = transform.DOMoveY(3f, 1f);
        moveTween.SetLoops(-1, LoopType.Yoyo);
    }
}
