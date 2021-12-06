using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook = nameof(HandlerDisplayNameUpdated))]
    [SerializeField]
    string displayName = "Missing Name";

    public TextMeshProUGUI name;

    //[SyncVar(hook = nameof(HandlerDisplayColorUpdated))]
    //[SerializeField]
    //Color myColor;

    [Server]
    public void setDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;


    }

    //[SerializeField]
    //Renderer render;

    //[Server]
    //public void setChangedColor()
    //{
    //    myColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

    //}

    ////Llamar funcion desde el editor
    //[ContextMenu("UpdateColor")]
    //private void UpdateColor()
    //{
    //    myColor = Color.black;
    //}

    //private void HandlerDisplayColorUpdated(Color oldColour, Color newColour)
    //{
    //    render.material.SetColor("_Color", newColour);
    //}

    private void HandlerDisplayNameUpdated(string oldName, string newName)
    {
        name.text = newName;
    }

    [ClientRpc]
    public void SetChild(NetworkIdentity identity)
    {
        identity.transform.SetParent(transform);
    }
}
