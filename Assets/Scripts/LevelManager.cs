using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private NetworkService _network;
    private Dictionary<string, int> _curLevel;


    public void Startup(NetworkService service)
    {
        Debug.Log("Inventory manager starting...");

        _network = service;
        

        UpdateData(new Dictionary<string, int>());

        status = ManagerStatus.Started;
    }


    public void UpdateData(Dictionary<string,int> curLevel)
    {
        _curLevel = curLevel;
    }

    public Dictionary<string,int> GetData()
    {
        return _curLevel;
    }

    public void AddLevel(string name)
    {
        if (!_curLevel.ContainsKey(name))
        {
            _curLevel[name] = 1;
        }
        //else
        //{
        //    _curLevel[name]++;
        //}
    }

    public int GetCurrentLevel(string name)
    {
        if (_curLevel.ContainsKey(name))
        {
            return _curLevel[name];
        }
        return 0;
    }
}
