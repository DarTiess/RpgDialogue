using UI;
using UnityEngine;

namespace NPCContainer
{
    public class NPCSpawner
    {
        private NpcFactory _npcFactory;
        private readonly NPCConfig[] _configs;
        private Transform[] _npsPositions;
        private IDialogueWindow _dialogWindow;
        private IFinishDialogueEvent _dialogEvent;

        public NPCSpawner(NPCConfig[] configs, Transform[] positions, IDialogueWindow dialogWindow, IFinishDialogueEvent dialogEvent)
        {
            _configs = configs;
            _npcFactory = new NpcFactory();
            _npsPositions = positions;
            _dialogWindow = dialogWindow;
            _dialogEvent = dialogEvent;
        }

        public void SpawnNPC()
        {
            for (int i = 0; i < _configs.Length; i++)
            {
                NPC npc = _npcFactory.CreateNPC(_configs[i].NPCPrefab, _npsPositions[i]);
                npc.Init(_configs[i], _dialogWindow, _dialogEvent);
            }
        }

    }
}