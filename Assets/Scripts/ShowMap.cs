using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    [SerializeField] private Vector3 smPos;

    private bool _showSideMenu = false;

    public void Show()
    {
        if (_showSideMenu)
        {
            Vector3 pos = transform.position - smPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + smPos;
            transform.position = pos;
        }
        _showSideMenu = !_showSideMenu;
    }
}
