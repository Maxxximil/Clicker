using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private int _tierTalant;
    [SerializeField] private TalantController talantController;

    private void OnMouseDown()
    {
        talantController.CheckLevel(_tierTalant);
    }
}

