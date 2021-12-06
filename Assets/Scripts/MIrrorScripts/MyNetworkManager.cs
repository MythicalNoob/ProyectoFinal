using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    [Header("My Variables")]
    [SerializeField] List<GameObject> players;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        var newPlayer = conn.identity.GetComponent<MyNetworkPlayer>();

        newPlayer.setDisplayName($"Player{numPlayers}");

        var instance = Instantiate(players[numPlayers - 1], conn.identity.transform);
        instance.GetComponent<PlayerCharacter>().parentIdentity = conn.identity;
        NetworkServer.Spawn(instance, conn);

       // newPlayer.SetChild(instance.GetComponent<NetworkIdentity>());

        Debug.Log($"Join Player{numPlayers} the server!!!");

        //newPlayer.setChangedColor();
    }

    public override void ServerChangeScene(string newSceneName)
    {
        base.ServerChangeScene(newSceneName);
        networkSceneName = newSceneName;
    }
}
