using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pet1;
    [SerializeField] private GameObject pet3;
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject explodeEffect;
    [SerializeField] private GameObject crushEffect;
    [SerializeField] private Transform RedList;
    [SerializeField] private Transform GreenList;
    
    private float clock1 = 0;
    private float timer1 = 5f;
    private int times = 0;

    public static GameManager Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    private void Update()
    {
        clock1 += Time.deltaTime;
        if (clock1 >= timer1)
        {
            clock1 = 0;
            GameObject newRed = Instantiate(pet1);
            newRed.transform.position = new Vector3(3.3f, -4.5f);
            newRed.transform.parent = RedList;
        }
    }

    public void DieEffect(Vector3 pos)
    {
        GameObject newEffect = Instantiate(explodeEffect);
        newEffect.transform.position = pos;
    }

    public void Crush(Vector3 pos)
    {
        GameObject newEffect = Instantiate(crushEffect);
        newEffect.transform.position = pos;
    }

    public void SpwanNewPink(Vector3 pos)
    {
        GameObject newPink = Instantiate(pet3);
        newPink.transform.position = pos + new Vector3(0,-1f);
    }

    public void SpawnNewGreen()
    {
        
        times += 1;
        GameObject newGreen = Instantiate(green);
        newGreen.transform.position = new Vector3(-1f, 1f) * times + new Vector3(6f, -2.3f);
        newGreen.transform.parent = GreenList;
    }
}
