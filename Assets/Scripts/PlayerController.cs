using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    private bool canControl = true;
    private SpriteRenderer pointerRenderer;

    public static PlayerController _PlayerController;
    private void Start()
    {
         pointerRenderer= gameObject.GetComponent<SpriteRenderer>();

         if (_PlayerController != null)
         {
             Destroy(gameObject);
         }
         else
         {
             _PlayerController = this;
         } 

    }

    void Update()
    {
       SlowlyMoveToMouse();

       if (GameManager.Instance.killPlayer)
       {
           GameManager.Instance.killPlayer = false;
           Destroy(gameObject);
       }
       
       int childCount = GameObject.FindWithTag("RedList").transform.childCount;
       if (childCount == 1)
       {
           GameManager.Instance.GameWin();
           Destroy(gameObject);
           GameManager.Instance.spawnPlayer = false;
       }
    }

    void SlowlyMoveToMouse()
    {
        if (canControl)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            mousePos.y -= 0.3f;
        
            //both 0.2 and 2 are interesting
            transform.position += (mousePos - transform.position) * Time.deltaTime * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pet4"))
        {
            pointerRenderer.DOFade(0.5f, 0.1f);
            canControl = false;
            GameManager.Instance.DieEffect(transform.position);
            transform.DOMove(new Vector3(1.2f, 2.8f), 5f).OnComplete(() =>
            {
                canControl = true;
                pointerRenderer.DOFade(1f, 0.1f);
            });
        }

        if (other.CompareTag("green"))
        {
            pointerRenderer.DOFade(0.5f, 0.1f);
            canControl = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pet3"))
        {
            Die();
        }

        if (other.gameObject.CompareTag("Pet1"))
        {
            pointerRenderer.DOFade(0.5f, 0.1f);
            canControl = false;
            GameManager.Instance.DieEffect(transform.position);
            transform.DOMove((transform.position - other.gameObject.transform.position).normalized + transform.position, 1f).OnComplete(
                () =>
                {
                    canControl = true;
                    pointerRenderer.DOFade(1f, 0.1f);
                });
        }

        
    }

    void Die()
    {
        
        pointerRenderer.DOFade(0, 3f);
        GameManager.Instance.DieEffect(transform.position);
        canControl = false;
        GameManager.Instance.GameDie();
        GameManager.Instance.spawnPlayer = false;
        Destroy(gameObject);
    }
}
