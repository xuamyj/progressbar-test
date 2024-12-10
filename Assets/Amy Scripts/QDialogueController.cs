using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class QDialogueController : MonoBehaviour
{
    // /* ---- UI: DRAGGED ---- */
    public GameObject qDialogueCanvas;

    /* ---- DATA but treat like const ---- */
    const string TRAINING_PREFIX = "Training";
    Dictionary<TrainingStatus, string> TRAINING_LINE_MAP;

    /* ---- YARN ---- */
    DialogueRunner qDialogueRunner;

    private void Awake()
    {
        qDialogueRunner = gameObject.GetComponent<DialogueRunner>();

        /* ---- DATA but treat like const ---- */
        TRAINING_LINE_MAP = new Dictionary<TrainingStatus, string>();
        TRAINING_LINE_MAP[TrainingStatus.Collab] = "Collab";
        TRAINING_LINE_MAP[TrainingStatus.Perfect] = "Perfect";
        TRAINING_LINE_MAP[TrainingStatus.Great] = "Great";
        // Good = no line
        TRAINING_LINE_MAP[TrainingStatus.NewSkill] = "NewSkill";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* 
        StatusController's BigToqDialogueScreen()
        -> this SetupAndStartDialogue()
        -> Yarn's StartDialogue()
    */
    // public void SetupAndStartDialogue(string qDialogueKey)
    public void SetupAndStartDialogue()
    {
        CharacterName cName = CharacterName.Evander;
        TrainingStatus tStatusName = TrainingStatus.Collab;

        if (TRAINING_LINE_MAP.ContainsKey(tStatusName))
        {
            string yNName = TRAINING_PREFIX + TRAINING_LINE_MAP[tStatusName] + cName.ToString();

            // set script
            qDialogueRunner.StartDialogue(yNName);
        }
        else
        {
            UnityEngine.Debug.Log("TrainingStatus is " + tStatusName.ToString() + ", no dialogue");
        }
    }
    /* 
        Yarn's OnDialogueComplete() [upon Stop()]
        -> this StopAndToWorld() 
        -> StatusController's BigToInWorldScreen()
    */
    public void StopAndToInWorld()
    {

    }
}
