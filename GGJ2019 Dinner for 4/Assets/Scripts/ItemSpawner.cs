using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ingredientPrefab;
    GameObject ingredientObj;

    int timer;
    public int respawnAfter = 2000;

    private void Start() {
        ingredientObj = Instantiate(ingredientPrefab, transform);
        timer = 0;
    }

    private void Update() {
        print(timer);
        if(transform.childCount == 0){
            timer++;
        }

        if(timer > respawnAfter){
            Start();
        }
        
    }
}
