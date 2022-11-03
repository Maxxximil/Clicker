using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int curWonder { get; private set; }

    public int maxWonder { get; private set; }

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Mission managers starting...");

        _network = service;

        UpdateData(1, 1);

        status = ManagerStatus.Started;
    }

    public void GoToNext()
    {
        if (curWonder <= maxWonder)
        {
            string name = "Wonder " + curWonder;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last level");
            //Messenger.Broadcast(GameEvent.GAME_COMPLETE);
        }
    }

    public void ReachObjective()
    {
        //Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
    }

    public void RestartCurrent()
    {
        string name = "Wonder " + curWonder;
        Debug.Log("Loading " + name);
        SceneManager.LoadScene(name);
    }

    public void UpdateData(int curWonder, int maxWonder)
    {
        this.curWonder = curWonder;
        this.maxWonder = maxWonder;
    }


}
