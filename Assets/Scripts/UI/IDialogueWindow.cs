using DialogueSystem;
using NPCContainer;

namespace UI
{
    public interface IDialogueWindow
    {
        void StartDialogue(string npcText, Answer[] answers, IAnswer npc);
        void EndDialogue();
    }
}