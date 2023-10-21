using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pet1;
    [SerializeField] private GameObject pet3;
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject pointerRed;
    [SerializeField] private GameObject pointerRed_empty;
    [SerializeField] private GameObject explodeEffect;
    [SerializeField] private GameObject crushEffect;
    [SerializeField] private TextMeshPro dieText;
    [SerializeField] private Transform RedList;
    [SerializeField] private Transform GreenList;
    
    public bool spawnPlayer = false;
    public bool killPlayer = false;
    
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

        dieText.text = null;

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

        if (spawnPlayer == false)
        {
            SpawnPlayer();
            
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

    public void GameDie()
    {
        dieText.text = "DIE";
    }

    private void SpawnPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y -= 0.3f;
        if (mousePos.x > -0.5f && mousePos.x < 0.5f && mousePos.y > 4.5f && mousePos.y < 5f)
        {
            GameObject newPointer = Instantiate(pointerRed);
            newPointer.transform.position = mousePos;
            newPointer.transform.parent = RedList;
            
            spawnPlayer = true;
        }
    }

    public void NewPointer()
    {
        GameObject newPointerLeft = Instantiate(pointerRed_empty);
        newPointerLeft.transform.position = PlayerController._PlayerController.gameObject.transform.position;
        killPlayer = true;
        spawnPlayer = false;
    }

    public void GameWin()
    {
        dieText.text = "WIN";
    }
}
