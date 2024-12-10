using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn;
using Yarn.Compiler;
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
    DialogueRunner qDialogueRunner;
    private void Awake()
    {
        qDialogueRunner = gameObject.GetComponent<DialogueRunner>();

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

    void CompileDialogueHelper(string speaker, string[] lines)
    {
        // Generate unique node name
        string nodeName = $"Dynamic_{System.Guid.NewGuid()}";

        // Create Yarn script
        string yarnScript = $"title: {nodeName}\n---\n";
        foreach (string line in lines)
        {
            yarnScript += $"{speaker}: {line}\n";
        }
        yarnScript += "===";

        // Compile the script
        var compilationJob = CompilationJob.CreateFromString(nodeName, yarnScript, new Yarn.Library());
        var result = Compiler.Compile(compilationJob);

        Program[] programs = { qDialogueRunner.yarnProject.Program, result.Program };
        var temp = Program.Combine(programs);


        // Load the compiled program
        qDialogueRunner.Dialogue.SetProgram(temp);

        // qDialogueRunner.Dialogue.AddProgram(result.Program);

        UnityEngine.Debug.Log("yarnScript = " + yarnScript);
        UnityEngine.Debug.Log("result.Program = " + result.Program);
        UnityEngine.Debug.Log("result.Diagnostics = " + result.Diagnostics);
        UnityEngine.Debug.Log("result.Diagnostics.ToList() = " + result.Diagnostics.ToList());
        UnityEngine.Debug.Log("Join() for result.Diagnostics = " + string.Join(", ", result.Diagnostics.ToList()));
        UnityEngine.Debug.Log("nodeName = " + nodeName);
        UnityEngine.Debug.Log("qDialogueRunner.NodeExists(\"WrongScriptName\") = " + qDialogueRunner.NodeExists("WrongScriptName"));
        UnityEngine.Debug.Log("qDialogueRunner.NodeExists(\"TestScript\") = " + qDialogueRunner.NodeExists("TestScript"));
        UnityEngine.Debug.Log("qDialogueRunner.NodeExists(nodeName) = " + qDialogueRunner.NodeExists(nodeName));

        // Start the dialogue
        qDialogueRunner.StartDialogue(nodeName);
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
        // cutsceneCanvas.SetActive(true);
        // backgroundImage.sprite = Resources.Load<Sprite>(bUrl);



        string[] list = { "Ah, I did it!", "I'm making good progress." };
        CompileDialogueHelper("A", list);

        // string yNName = "TestScript";
        // qDialogueRunner.StartDialogue(yNName);
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
