using UnityEngine;

namespace CamFollow
{
    public class CameraFollow: MonoBehaviour
    {
        [SerializeField] public float RotationAngleX;
        [SerializeField] public int Distance;
        [SerializeField] public float OffsetY;
        
        private Transform _following;

        public void Init(Transform target)
        {
            _following = target;
        }
        private void LateUpdate()
        {
            if(_following == null)
                return;
            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -Distance) + FollowingPointPosition();
            transform.rotation = rotation;
            transform.position = position;
        }
        
        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}