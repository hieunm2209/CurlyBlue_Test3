using Fusion;
using UnityEngine;
using TMPro;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_InputField inputName;

    public string playerName;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void OnConfirm()
    {
        playerName = inputName.text;
        canvas.gameObject.SetActive(false);
    }
}