using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private List<Fruit> FruitList;

    public static ObjectManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject SpawnFruit(int id, Vector2 position) 
    {
        return Instantiate(FindFruit(id), position, new Quaternion());
    }

    private GameObject FindFruit(int id) 
    {
        return FruitList.Find(f => f.id == id)._gameObject;
    }
}

[System.Serializable]
struct Fruit 
{
    public int id;
    public GameObject _gameObject;
}
