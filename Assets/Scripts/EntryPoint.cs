using System;
using CamFollow;
using Input;
using NPCContainer;
using PlayerContainer;
using UnityEngine;
using UnityEngine.Events;

public class EntryPoint: MonoBehaviour
{
    [Header("Player's Settings")]
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerPosition;
    [Header("Npc's Settings")]
    [SerializeField] private NPCConfig[] _npcConfigs;
    [SerializeField] private Transform[] _npcPosition;
    [Header("UI")]
    [SerializeField] private DialogueWindow _dialogueWindowPrefab;
    
        
    private Player _player;
    private IInputService _input;
    private CameraFollow _camera;
    private NPCSpawner _npcSpawner;
    private DialogueWindow _dialogueWindow;

    private void Awake()
    {
        _input = InputService();
        _dialogueWindow = Instantiate(_dialogueWindowPrefab);
        CreateAndInitPlayer();
        InitCamera();
        CreateNPCSpawner();
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
        _player.Init(_input, _playerConfig, _dialogueWindow);
    }

    private void InitCamera()
    {
        _camera = Camera.main.GetComponent<CameraFollow>();
        _camera.Init(_player.transform);
    }

    private void CreateNPCSpawner()
    {
        _npcSpawner = new NPCSpawner(_npcConfigs, _npcPosition, _dialogueWindow, _dialogueWindow);
        _npcSpawner.CreateNPCs();
    }
}