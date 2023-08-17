using NPCContainer;

public interface IDialogueWindow
{
    void StartDialogue(string npcText, Answer[] answers, IAnswer npc);
    void EndDialogue();
}