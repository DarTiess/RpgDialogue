using System;
using DG.Tweening;
using NPCContainer;
using UnityEngine;
using UnityEngine.UI;

public interface IFinishDialogueEvent
{
    event Action FinishDialogue;
}
public class DialogueWindow : MonoBehaviour, IDialogueWindow, IFinishDialogueEvent
{
    [SerializeField] private Text _textNode;
    [SerializeField] private Button[] _answerButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private float _textingDuration=2f;
    private Text[] _answerText;
    private IAnswer _npc;
    private string _npcText;

    public event Action FinishDialogue;

    public void Start()
    {
        Hide();
      
        _answerText = new Text[_answerButton.Length];
        for(int i=0;i<_answerButton.Length;i++)
        {
            int b = i;
            _answerText[i] = _answerButton[i].GetComponentInChildren<Text>();
             _answerButton[i].onClick.AddListener(()=>OnClickedAnswer(b));
        }
        _closeButton.onClick.AddListener(OnCloseButton);
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialogue();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnClickedAnswer(0);
        } 
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnClickedAnswer(1);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnClickedAnswer(2);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            _textNode.DOKill();
            _textNode.text = _npcText;
        }
    }

    public void StartDialogue(string npcText, Answer[] answers, IAnswer npc)
    {
        _npcText = npcText;
        Show();
        _npc = npc;
        _textNode.DOText(_npcText, _textingDuration);
        for (int i = 0; i < answers.Length; i++)
        {
            _answerText[i].text = answers[i].text;
        }
    }

    public void EndDialogue()
    {
        Hide();
        _npc = null;
        FinishDialogue?.Invoke();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
      
        gameObject.SetActive(true);
        _textNode.text = "";
    }

    private void OnClickedAnswer(int index)
    {
        if (_npc != null)
        {
            _npc.MakeAnswer(index);
        }
    }

    private void OnCloseButton()
    {
        EndDialogue();
    }
}