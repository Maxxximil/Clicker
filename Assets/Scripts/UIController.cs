using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private ShowTalantTree tt;
    [SerializeField] private ShowMap map;

    private int _score;
    private string _level = "Wonder " + Managers.Mission.curWonder;
    private bool _isShowTalant = false;
    private bool _isShowMap = false;


    private void Awake()
    {
        Messenger.AddListener(GameEvent.CLICK_ON_WONDER, ClickOnWonder);
        Messenger.AddListener(GameEvent.CHANGE_SCORE, OnChangeScore );
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.CLICK_ON_WONDER, ClickOnWonder);
        Messenger.RemoveListener(GameEvent.CHANGE_SCORE, OnChangeScore);
    }
    private void Start()
    {
        scoreLabel.text = ": " + Managers.Score.GetScore(_level);
    }
    private void ClickOnWonder()
    {
        _score = 1;
        Managers.Score.ChangeScore(_level, _score);
        scoreLabel.text = ": " + Managers.Score.GetScore(_level);
    }

    private void OnChangeScore()
    {
        scoreLabel.text = ": " + Managers.Score.GetScore(_level);
    }

    public void ShowTalant()
    {
        if (_isShowMap)
        {
            ShowMap();
        }
        tt.Show();
        _isShowTalant = !_isShowTalant;
    }

    public void ShowMap()
    {
        if (_isShowTalant)
        {
            ShowTalant();
        }
        map.Show();
        _isShowMap = !_isShowMap;
    }

    public void SaveGame()
    {
        Managers.Data.SaveGameState();
    }

    public void LoadGame()
    {
        Managers.Data.LoadGameState();
    }

    

}
