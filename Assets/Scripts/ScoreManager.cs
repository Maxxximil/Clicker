using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private Dictionary<string, int> _wonderCubes;
    private NetworkService _network;

    
    public void Startup(NetworkService service)
    {
        Debug.Log("Inventory manager starting...");

        _network = service;

        _wonderCubes = new Dictionary<string, int>();
        _wonderCubes.Add("Wonder 1", 0);

        status = ManagerStatus.Started;
    }

    public void ChangeScore(string name, int value)
    {
        if (_wonderCubes.ContainsKey(name))
        {
            _wonderCubes[name] += value;
        }
    }

    public int GetScore(string name)
    {
        if (_wonderCubes.ContainsKey(name))
        {
            return _wonderCubes[name];
        }
        return 0;
    }

    public Dictionary<string, int> GetData()
    {
        return _wonderCubes;
    }

    public void UpdateData(Dictionary<string, int> wonderCubes)
    {
        _wonderCubes = wonderCubes;
    }

    
}
