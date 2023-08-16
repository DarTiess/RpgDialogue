using CamFollow;
using Input;
using NPCContainer;
using PlayerContainer;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [Header("Player's Settings")]
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerPosition;
    [Header("Npc's Settings")]
    [SerializeField] private NPC _npcPrefab;
    [SerializeField] private float _npcRotateSpeed;
    [SerializeField] private Transform _npcPosition;
        
    private Player _player;
    private IInputService _input;
    private CameraFollow _camera;
    private NPC _npc;

    private void Awake()
    {
        _input = InputService();
        CreateAndInitPlayer();
        InitCamera();
        _npc = Instantiate(_npcPrefab, _npcPosition.position, Quaternion.identity);
        _npc.Init(_npcRotateSpeed);
    }

    private IInputService InputService()
    {
        if (Application.isEditor)
        {
            return new StandaloneInputService();
        }
        else
        {
            return new MobileInputService();
        }
    }

    private void CreateAndInitPlayer()
    {
        _player =Instantiate(_playerPrefab, _playerPosition.position, Quaternion.identity);
        _player.Init(_input, _playerConfig);
    }

    private void InitCamera()
    {
        _camera = Camera.main.GetComponent<CameraFollow>();
        _camera.Init(_player.transform);
    }
}