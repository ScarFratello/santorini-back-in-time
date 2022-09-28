using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _Instance;
    [SerializeField] private int _LevelScore;
    [SerializeField] private int _Collectables;
    [SerializeField] private int _TotalScore;

    private ScoreManager()
    {
        _LevelScore = 0;
        _Collectables = 0;
        _TotalScore = 0;
    }

    public void AddPoints(int value)
    {
        _LevelScore += value;
        _TotalScore += value;
    }
    public void AddCollectable(int value)
    {
        _Collectables++;
        _LevelScore += value;
        _TotalScore += value;
    }

    public static ScoreManager GetInstance()
    {
        return _Instance;
    }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
