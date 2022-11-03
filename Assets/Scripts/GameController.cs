using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] _wonder;

    private string _name;

    void Start()
    {
        _name ="Wonder " + Managers.Mission.curWonder;
        Managers.Level.AddLevel("Wonder " + Managers.Mission.curWonder);
        Instantiate(_wonder[Managers.Level.GetCurrentLevel(_name) - 1]);
    }

    public void LevelUp(int curLevel)
    {
        Destroy(GameObject.FindWithTag("Wonder"));
        Instantiate(_wonder[curLevel - 1]);
    }

}
