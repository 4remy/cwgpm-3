using System;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
    private static event Action<Conversation> OnNewConversation;
    public static void NewConversation(Conversation conversation) => OnNewConversation?.Invoke(conversation);

    [SerializeField] private GameObject speakerLeft;
    [SerializeField] private GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private Conversation activeConversation;
    private int activeLineIndex = 0;

    private void Awake()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        InitialiseConversation(null);

        OnNewConversation += InitialiseConversation;
    }

    private void OnDestroy() => OnNewConversation -= InitialiseConversation;

    private void InitialiseConversation(Conversation conversation)
    {
        if (conversation == null)
        {
            ClearDialog();
        }
        else if (conversation != activeConversation)
        {
            activeConversation = conversation;
            gameObject.SetActive(true);

            speakerUILeft.Speaker = activeConversation.speakerLeft;
            speakerUIRight.Speaker = activeConversation.speakerRight;

            // Show the first line
            AdvanceConversation();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && activeConversation != null)
        {
            //check animator triggers?
            AdvanceConversation();
        }
    }

    private void AdvanceConversation()
    {
        if (activeLineIndex < activeConversation.lines.Length)
        {
            DisplayLine(activeConversation.lines[activeLineIndex]);
            activeLineIndex++;
        }
        else
        {
            ClearDialog();
        }
    }

    //assumptions: only two characters
    private void DisplayLine(Line line)
    {
        if (speakerUILeft.SpeakerIs(line.character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line);
        }
    }

    private void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, Line line)
    {
        activeSpeakerUI.Dialog = line.text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
        activeSpeakerUI.animator.Play(line.emotion.ToString());
    }

    private void ClearDialog()
    {
        gameObject.SetActive(false);
        speakerUILeft.Hide();
        speakerUIRight.Hide();
        activeLineIndex = 0;
        activeConversation = null;
    }
}
