using UnityEngine;

namespace NPCContainer
{
    [CreateAssetMenu]
    public class NPCConfig : ScriptableObject
    {
   
        [SerializeField] private float _rotationSpeed;
        [SerializeField]private TextAsset _textAsset;
        [SerializeField] private NPC _npcPrefab;
        [SerializeField] private AudioClip[] _audioClips;

    
        public float RotationSpeed => _rotationSpeed;
        public TextAsset TextAsset => _textAsset;
        public NPC NPCPrefab => _npcPrefab;
        public AudioClip[] AudioClips => _audioClips;

    }
}