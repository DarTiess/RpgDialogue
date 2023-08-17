using UnityEngine;

namespace NPCContainer
{
    public class NpcFactory
    {
        public NPC CreateNPC(NPC prefab, Transform position)
        {
            return Object.Instantiate(prefab, position.position, Quaternion.identity);
        }
    }
}