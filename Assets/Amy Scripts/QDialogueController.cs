using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

// /* ---- DATA ---- */
// public class CutsceneInfo
// {
//     public string cutsceneKey; // "clerk"
//     public string yarnNodeName; // "Clerk"
//     public string backgroundUrl; // "day1-clerk.png"
//     // other properties added later

//     public CutsceneInfo(string cKey, string yNName, string bUrl)
//             : base() // calls base first
//     {
//         cutsceneKey = cKey;
//         yarnNodeName = yNName;
//         backgroundUrl = bUrl;
//     }
// }

public class QDialogueController : MonoBehaviour
{
    // /* ---- UI: DRAGGED ---- */
    // public UnityEngine.UI.Image backgroundImage;
    public GameObject cutsceneCanvas;

    // /* ---- DATA, should be used like a const ---- */
    // private Dictionary<string, CutsceneInfo> cutsceneInfoMap;

    /* ---- YARN ---- */
    DialogueRunner cutsceneRunner;
    private void Awake()
    {
        cutsceneRunner = gameObject.GetComponent<DialogueRunner>();

        // /* ---- DATA ---- */
        // cutsceneInfoMap = new Dictionary<string, CutsceneInfo>();
        // cutsceneInfoMap["clerk"] = new CutsceneInfo("clerk", "Clerk", "cutscene/day1-clerk");
        // cutsceneInfoMap["wally"] = new CutsceneInfo("wally", "Wally", "cutscene/day1-wally");
        // cutsceneInfoMap["eat"] = new CutsceneInfo("eat", "Eat", "cutscene/town1-bg");
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
        StatusController's BigToCutsceneScreen()
        -> this SetupAndStartDialogue()
        -> Yarn's StartDialogue()
    */
    // public void SetupAndStartDialogue(string cutsceneKey)
    public void SetupAndStartDialogue()
    {
        // string yNName = cutsceneInfoMap[cutsceneKey].yarnNodeName;
        // string bUrl = cutsceneInfoMap[cutsceneKey].backgroundUrl;

        // // set active + background
        cutsceneCanvas.SetActive(true);
        // backgroundImage.sprite = Resources.Load<Sprite>(bUrl);

        string yNName = "TestScript";

        // set script
        cutsceneRunner.StartDialogue(yNName);
    }
    /* 
        Yarn's OnDialogueComplete() [upon Stop()]
        -> this StopAndToWorld() 
        -> StatusController's BigToInWorldScreen()
    */
    public void StopAndToInWorld()
    {
        // unset active
        cutsceneCanvas.SetActive(false);
        // backgroundImage.sprite = Resources.Load<Sprite>(CUTSCENE_BLANK_URL);

        // StatusController.instance.BigToInWorldScreen();
    }
}
