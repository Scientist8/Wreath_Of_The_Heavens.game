using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject _goldPrefab;
    [SerializeField] GameObject[] _UIButtons;

    LevelEnder _levelEnder;
    LevelManager _levelManager;

    [SerializeField] bool _onOffSwitch = false;

    public int _maxGoldCoin = 25 , _minGoldCoin = 15;

    private void Awake()
    {
        _levelEnder = FindObjectOfType<LevelEnder>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        SpawnGoldCoins();

        if (_onOffSwitch)
        {
            for (int i = 0; i < _UIButtons.Length; i++)
            {
                _UIButtons[i].SetActive(false);
            }
            Invoke("CallNextLevel", 5f);
        }
    }

    void SpawnGoldCoins()
    {
        if (_levelEnder._levelHasEnded == true && _onOffSwitch == false)
        {
            _onOffSwitch = true;

            for (int i = 0; i < Random.Range(_minGoldCoin, _maxGoldCoin); i++)
            {
                Instantiate(_goldPrefab, new Vector3(Random.Range(-10, 10), transform.position.y, Random.Range(-2, 2)), Quaternion.identity);
            }
        }
    }

    void CallNextLevel()
    {
        _levelManager.LoadNextLevel();
    }
}
