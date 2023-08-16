using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _rotationSpeed;

    public float Speed => _playerSpeed;
    public float RotationSpeed => _rotationSpeed;
   
}