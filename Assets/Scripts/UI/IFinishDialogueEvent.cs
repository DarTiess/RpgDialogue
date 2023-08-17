using System;

namespace UI
{
    public interface IFinishDialogueEvent
    {
        event Action FinishDialogue;
    }
}