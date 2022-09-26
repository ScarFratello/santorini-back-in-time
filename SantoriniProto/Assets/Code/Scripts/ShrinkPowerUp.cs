using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerUp : MonoBehaviour, IPowerUp
{
    public float LifeTime;
    // Start is called before the first frame update
    public byte Activate()
    {
        
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        LifeTime -= Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
