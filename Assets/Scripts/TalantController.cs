using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalantController : MonoBehaviour
{
    [SerializeField] private GameObject[] _talantLevels;
    [SerializeField] private GameController _gameController;

    private Dictionary<string, int> _curLevel;

    private int[] _neededScore;
    private int _curScore;
    private int _maxLevel;
    private int _activeLevel;
    private int _inactive;
    private string _name;

    private void Start()
    {
        _curLevel = new Dictionary<string, int>();
        _maxLevel = 7;
        _activeLevel = 1;
        _inactive = 1;
        _neededScore = new int[] { 0, 10, 20, 30, 40, 50, 60 };



        _curLevel = Managers.Level.GetData();
        _name = "Wonder " + Managers.Mission.curWonder;


        ChangeActiveLevel(_activeLevel);


       

        for(int i = _curLevel[_name]; i > _activeLevel; i--)
        {

            _talantLevels[i-1].GetComponent<Renderer>().material.color = Color.grey;
        }

        for (int i = _curLevel[_name]; i < _maxLevel; i++)
        {
            _talantLevels[i].GetComponent<Renderer>().material.color = Color.black;
        }
    }

    private void Update()
    {
        if (_curLevel[_name] < 7)
        {
            if (_neededScore[_curLevel[_name]] <= Managers.Score.GetScore(_name))
            {
                _talantLevels[_curLevel[_name]].GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    public void ChangeActiveLevel(int activeLevel)
    {
        
        if (activeLevel > 0 && activeLevel < 8)
        {
            //_talantLevels[_activeLevel].GetComponent<Renderer>().material.color = Color.gray;
            _inactive = this._activeLevel;
            this._activeLevel = activeLevel;

        }
        _talantLevels[_activeLevel - 1].GetComponent<Renderer>().material.color = Color.white;
        Transform active = GameObject.FindWithTag("Tier " + _activeLevel).transform;
        active.position = new Vector3(active.transform.position.x,active.transform.position.y, -3f);

        if (_inactive != _activeLevel)
        {
            _talantLevels[_inactive - 1].GetComponent<Renderer>().material.color = Color.grey;
            Transform inactive = GameObject.FindWithTag("Tier " + _inactive).transform;
            inactive.position = new Vector3(inactive.transform.position.x, inactive.transform.position.y, 3f);
        }
        Debug.Log("Curlvl: " + _curLevel[_name]);
    }

    public void CheckLevel(int level)
    {
        if (level <= _curLevel[_name] || level == 1 )
        {
            ChangeActiveLevel(level);
        }
        else
        {
            BuyLevel(level);
        }
    }

    public void BuyLevel(int level)
    {
        if (_neededScore[level-1] <= Managers.Score.GetScore(_name))
        {
            _curLevel[_name]++;
            Managers.Level.UpdateData(_curLevel);
            Managers.Score.ChangeScore(_name, -_neededScore[level - 1]);
            ChangeActiveLevel(level);
            Messenger.Broadcast(GameEvent.CHANGE_SCORE);
            _gameController.LevelUp(_curLevel[_name]);
        }
    }
}
