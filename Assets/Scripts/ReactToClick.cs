using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Transform wonder = GameObject.FindWithTag("Wonder").transform;
        wonder.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    private void OnMouseUp()
    {
        Transform wonder = GameObject.FindWithTag("Wonder").transform;
        wonder.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Messenger.Broadcast(GameEvent.CLICK_ON_WONDER);
    }
}
