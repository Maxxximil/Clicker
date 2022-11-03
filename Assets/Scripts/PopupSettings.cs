using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSettings : MonoBehaviour
{
    [SerializeField] private GameObject clickable;

    private bool _isOpenSettings;

    private void Start()
    {
        Close();
    }

    public void Open_Close()
    {
        if (_isOpenSettings)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        gameObject.SetActive(true);
        _isOpenSettings = true;
        clickable.SetActive(false);
    }

    private void Close()
    {
        gameObject.SetActive(false);
        _isOpenSettings = false;
        clickable.SetActive(true);
    }
}
