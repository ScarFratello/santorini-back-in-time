using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScoreManager;

public class Item : MonoBehaviour
{
    public int Value;
    public bool IsCollectable;
    public bool IsPowerup;

    // Start is called before the first frame update


    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.GetInstance().AddPoints(Value);
            if (IsCollectable)
            {
                ScoreManager.GetInstance().AddCollectable(Value);
            }
            else if (IsPowerup)
            {
                PlayerStatus player = other.gameObject.GetComponent<PlayerStatus>();
                switch (tag)
                {
                    case "ShrinkPowerup":
                        Debug.Log("Shrink activated!");
                        player.ActivePowerup = other.gameObject.AddComponent<ShrinkPowerUp>();
                        break;
                    case "MagnetPowerup":
                        Debug.Log("Magnet activated!");           
                        player.ActivePowerup = other.gameObject.AddComponent<MagnetPowerUp>();
                        break;
                }
            }
            Destroy(gameObject);
        }
    }
}
