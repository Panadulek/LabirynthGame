using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    GameManager.Keys colorKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    public override void Picked()
    {
        GameManager.gameManager.addKey(colorKey);
        Destroy(this.gameObject);
    }
}
