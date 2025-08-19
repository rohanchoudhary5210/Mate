using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cardPrefab;
    void Start()
    {
        Instantiate(cardPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
