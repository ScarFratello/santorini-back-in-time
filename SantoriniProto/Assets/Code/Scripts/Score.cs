using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScoreManager;

public class Score : MonoBehaviour
{
    public GameObject Player;
    public int Value;
    public bool IsCollectable;

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
            Destroy(gameObject);
        }
    }
}
