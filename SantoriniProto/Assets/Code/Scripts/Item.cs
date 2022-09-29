using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScoreManager;

public class Item : MonoBehaviour
{
    public int Value;
    public bool IsCollectable;
    public bool IsPowerup;
    public bool IsHealth;

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
            PlayerStatus player = other.gameObject.GetComponent<PlayerStatus>();
            ScoreManager.GetInstance().AddPoints(Value);
            if (IsCollectable)
            {
                ScoreManager.GetInstance().AddCollectable(Value);
            }
            else if (IsPowerup)
            {
                
                if (player.ActivePowerup != null)
                {
                    StopCoroutine(player.ActivePowerup.Destroyer);
                    Destroy(player.ActivePowerup.PowerupObject);
                    Destroy(player.ActivePowerup);
                }
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
            else if (IsHealth)
            {
                player.RecoverHealth();
            }
            Destroy(gameObject);
        }
    }
}
