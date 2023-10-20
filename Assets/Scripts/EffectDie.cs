using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDie : MonoBehaviour
{
    private float timer = 0;
    private float setTime = 1f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= setTime)
        {
            Destroy(gameObject);
        }
    }
}
