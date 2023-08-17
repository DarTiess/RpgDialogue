using UnityEngine;

namespace CamFollow
{
    public class CameraFollow: MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX=18.83f;
        [SerializeField] private int _distance=3;
       [SerializeField] private float _offsetY=1.62f;
        
        private Transform _following;

        public void Init(Transform target)
        {
            _following = target;
        }
        private void LateUpdate()
        {
            if(_following == null)
                return;
            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();
            transform.rotation = rotation;
            transform.position = position;
        }
        
        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += _offsetY;
            return followingPosition;
        }
    }
}