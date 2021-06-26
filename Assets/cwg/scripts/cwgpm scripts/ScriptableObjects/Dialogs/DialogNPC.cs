using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public enum SpeechType
{
    loopingConvo,
    oneOffConvo
}

public class DialogNPC : Interactable
{

    //reference to the NPC's dialog
    [SerializeField] private Conversation conversation;
    public bool isCompleted;
    // i want to hide onlyOnce from editor
    private bool onlyOnce;

    //this is how the status of your conversation is saved
    public BoolValue convoCompleted;
    public SpeechType thisSpeechType;

    [Header("give item?")]
    //set itemless to TRUE if it doesn't give stuff.
    public bool itemless;
    [SerializeField] private Schwer.ItemSystem.Item item = default;

    [Header("Happens independently? Or needs priors")]
    //set independent to TRUE if you aren't running checks.
    public bool independent;

    [Header("Reliant on earlier things being completed?")]

    //do you want your conversation to be triggered only after something else
    // was completed? it can be an earlier convo, but could be any bool value
    //check the bool value is added to your gamesaver manager
    public BoolValue priorEvent;
    public bool priorSuccess;




    //how do you make it wait a coroutine if it requires a prior, and the prior is also on the same character
    //maybe it would work good 2 convos on same character


    private void Start()
    {
        isCompleted = convoCompleted.RuntimeValue;
        priorSuccess = priorEvent.RuntimeValue;

    }
    protected override void Interact()
    {
        if (!independent)
        {
            priorSuccess = priorEvent.RuntimeValue;
            if (!priorSuccess)
            {
                Debug.Log("the prior conversation is set to" + priorSuccess);
                return;
            }
        }
        if (thisSpeechType == SpeechType.oneOffConvo)
        {
            if (!onlyOnce)
            {
                Debug.Log("one off convo");
                DialogDisplay.NewConversation(conversation);
                isCompleted = true;
                convoCompleted.RuntimeValue = isCompleted;
                onlyOnce = true;
                if (!itemless)
                {
                    player.inventory[item]++;
                }
                onlyOnce = true;
            }
            Debug.Log("already did one off convo");
        }
        else
        {
            Debug.Log("looping convo");
            DialogDisplay.NewConversation(conversation);
            isCompleted = true;
            convoCompleted.RuntimeValue = isCompleted;
        }

    }
}
/*
if (!priorSuccess)
{
    Debug.Log("the prior conversation is set to" + priorSuccess);

}
else
{
    Debug.Log("prior conversation is set to" + priorSuccess);
} */