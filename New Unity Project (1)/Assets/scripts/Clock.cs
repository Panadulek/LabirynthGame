using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public byte b; 
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    public override void Picked()
    {
        GameManager.gameManager.addTime(time * b);
        Destroy(this.gameObject);
    }
}
