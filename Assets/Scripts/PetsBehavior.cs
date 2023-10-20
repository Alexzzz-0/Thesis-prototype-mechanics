using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class PetsBehavior : MonoBehaviour
{
    private Tween pet1Move;
    private Tween pet2Move;

    private Transform green;

    public bool added;
    private bool touched;
    
    void Start()
    {
        // pet1Move = transform.DOMoveY(2f, 3f).OnComplete(() =>
        // {
        //     pet2Move = transform.DOMoveX(-10f, 5f).OnComplete(() =>
        //     {
        //         
        //         Die();
        //     });
        // });

        int randomIndex = Random.Range(0, 2);
        green = GameObject.FindWithTag("GreenList").transform.GetChild(randomIndex);
        
    }

    private void Update()
    {
        if (touched == false)
        {
            Vector3 direction = green.position - transform.position;
            transform.position = direction.normalized * Time.deltaTime * 1.5f + transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pet4"))
        {
            DOTween.Kill(pet1Move);
            DOTween.Kill(pet2Move);

            touched = true;
            transform.DOMove(new Vector3(1.2f, 2.8f),5f);
            
            // GameObject.FindWithTag("Pet4").transform.position =
            //     new Vector3(Random.Range(-10f, 0f), Random.Range(-2f, 3.4f));
            
            //Destroy(gameObject);
            
            GameManager.Instance.Crush(transform.position);
            GameManager.Instance.SpwanNewPink(transform.position);
        }

        // if (other.CompareTag("green"))
        // {
        //     
        //     if (added == false)
        //     {
        //         added = true;
        //         GameManager.Instance.SpawnNewGreen();
        //     }
        //     
        // }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pet3"))
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.DieEffect(transform.position);
        Destroy(gameObject);
    }
}
