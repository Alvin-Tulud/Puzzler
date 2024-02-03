using UnityEngine;
using UnityEngine.UI;

public class Play_Button : MonoBehaviour
{
    private GameObject Test_Phase;
    private GameObject Build_Phase;

    private Turn_Clicker Turn_Clicker;
    private bool clicked;

    public Sprite[] playButtonState;
    private Image playButton;

    // Start is called before the first frame update
    void Start()
    {
        Test_Phase = gameObject.transform.GetChild(0).gameObject;
        Build_Phase = gameObject.transform.GetChild(1).gameObject;
        Turn_Clicker = GameObject.FindWithTag("Turn_DIrector").GetComponent<Turn_Clicker>();

        Test_Phase.GetComponent<Test_Phase_Initialize>().state(false);//start in build_phase
        Build_Phase.GetComponent<Build_Phase_Initialize>().state(true);

        clicked = false;

        playButton = GetComponent<Image>();
    }

    public void FlipFlop()
    {
        playButton.sprite = playButtonState[1];

        if (!clicked)
        {
            Test_Phase.GetComponent<Test_Phase_Initialize>().state(true);//start test_phase
            Build_Phase.GetComponent<Build_Phase_Initialize>().state(false);
            Debug.Log("test");
            clicked = true;
        }
        else
        {
            Turn_Clicker.Stopping(true);
        }
    }

    public void StartBuildPhase()
    {
        playButton.sprite = playButtonState[0];

        Test_Phase.GetComponent<Test_Phase_Initialize>().state(false);//start build_phase
        Build_Phase.GetComponent<Build_Phase_Initialize>().state(true);

        //Set the flipbelts back to original position
        GameObject[] FlipBelts = GameObject.FindGameObjectsWithTag("Flip_Belt");
        foreach (GameObject flipbelt in FlipBelts)
        {
            Flip_Belt_Move script = flipbelt.GetComponent<Flip_Belt_Move>();
            script.RealignFlipBelt();
        }


        Debug.Log("build");
        clicked = false;
    }
}
