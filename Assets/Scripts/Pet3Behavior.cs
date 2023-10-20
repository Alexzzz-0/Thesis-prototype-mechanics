using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pet3Behavior : MonoBehaviour
{
    public Transform lover;
    private bool eat;
    private bool hitGreen;
    
    private void Start()
    {
        if (lover == null)
        {
            int Index = Random.Range(0, GameObject.FindWithTag("RedList").transform.childCount);
            lover = GameObject.FindWithTag("RedList").transform.GetChild(Index);
        }
    }

    void Update()
    {
        if (hitGreen == false)
        {
            int childCount = GameObject.FindWithTag("RedList").transform.childCount;
            if (childCount == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                if (lover == null)
                {
                    int Index = Random.Range(0, childCount);
                    lover = GameObject.FindWithTag("RedList").transform.GetChild(Index);

                    if (eat == false)
                    {
                        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    }

                    eat = true;
                }
                else
                {
                    eat = false;
                } 
            }
            
            
        
            Vector3 direction = lover.transform.position - transform.position;
            transform.position += direction.normalized * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("green"))
        {
            Die();
        }
    }

    void Die()
    {
        hitGreen = true;
        Vector3 newPos = new Vector3(Random.Range(3.2f, 5.4f), Random.Range(0.83f, 4.7f));
        GameManager.Instance.DieEffect(transform.position);
        transform.DOMove(newPos, 5f);
    }
}
