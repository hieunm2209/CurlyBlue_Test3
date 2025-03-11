using UnityEngine;
using Fusion;
using TMPro;

public class PlayerInfo : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(NameChanged))]
    public string PlayerName { get; set; }

    [SerializeField]
    TMP_Text txtName;

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            PlayerName = Runner.GetComponent<PlayerSpawner>().playerName;
        }
    }

    void NameChanged()
    {
        txtName.text = PlayerName;
        gameObject.name = PlayerName;
    }
}
