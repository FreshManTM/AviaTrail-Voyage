using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _roadPrefabs;
    [SerializeField] Country TEST_COUNTRY;
    [SerializeField]List<GameObject> _tiles = new List<GameObject>();

    [SerializeField] float _speed = 5f;
    float _speedIncrement = .5f;
    int _tilesAmount = 10;
    float _tileOffset = 11.5f;
    int _spawnedAmount;

    private void Start()
    {
        TEST_COUNTRY = Saver.Instance.LoadInfo().SetCountry;
        SpawnRoads();
    }


    private void Update()
    {
        //if (_spawnedAmount < _tilesAmount & _tiles[_spawnedAmount].transform.position.y < 2 * _tileOffset)
        //{
        //    print("activate");
        //    _tiles[_spawnedAmount].SetActive(true);
        //    _spawnedAmount++;
        //}
        //if (_tiles[0].transform.position.y < -_tileOffset)
        //{
        //    print("deactivate");
        //    var go = _tiles[0];
        //    _tiles.RemoveAt(0);
        //    go.SetActive(false);
        //    //_spawnedAmount--;
        //}
        MoveRoads();
    }

    void SpawnRoads()
    {
        Vector2 spawnPos = Vector2.up;
        GameObject go;
        int _tileNum = 0;

        for (int i = 0; i < _tilesAmount + 2; i++)
        {
            spawnPos = Vector2.up * _spawnedAmount * _tileOffset;
            //Spawn 2 first roads
            if (i == 0 || i == 1)
            {
                _tileNum = 0;
            }
            //spawn last road
            else if (i == _tilesAmount + 1)
            {
                _tileNum = 1;
            }
            else
            {
                _tileNum = Random.Range(2, _roadPrefabs.Length - 1);
            }

            go = Instantiate(_roadPrefabs[_tileNum], spawnPos, Quaternion.identity, transform);
            _spawnedAmount++;
            go.GetComponent<RoadTile>().SetCountry(TEST_COUNTRY);
            //go.SetActive(false);
            _tiles.Add(go);
        }

        _spawnedAmount = 0;
    }

    void MoveRoads()
    {
        transform.position += Vector3.down * _speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, Vector2.down * _tilesAmount * _tileOffset, _speed * Time.deltaTime);
    }
}
