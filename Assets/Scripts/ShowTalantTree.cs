using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTalantTree : MonoBehaviour
{
    [SerializeField] private Vector3 smPos;

    private bool _showSideMenu = false;

    public void Show()
    {
        Vector3 newPos = new Vector3();
        newPos = smPos;
        if (_showSideMenu)
        {
            Vector3 pos = transform.position - newPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + newPos;
            transform.position = pos;
        }
        _showSideMenu = !_showSideMenu;
    }
}
