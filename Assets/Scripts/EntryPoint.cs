using CamFollow;
using Scripts.Infrastructure.Input;
using UnityEngine;

namespace DefaultNamespace
{
    public class EntryPoint: MonoBehaviour
    {
        [Header("Player's Settings")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _playerPosition;

        private Player _player;
        private IInputService _input;
        private CamFollower _camera;

        private void Awake()
        {
            _input = InputService();
            CreateAndInitPlayer();
            InitCamera();
        }

        private void InitCamera()
        {
            _camera = Camera.main.GetComponent<CamFollower>();
            _camera.Init(_player.transform);
        }

        private void CreateAndInitPlayer()
        {
            _player = Instantiate(_playerPrefab, _playerPosition.position, Quaternion.identity);
            _player.Init(_input, _playerConfig);
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
    }
}