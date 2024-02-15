using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Button : MonoBehaviour
{
    public static Tutorial_Button Instance;

    public List<GameObject> children;
    public Animator animation;
    private int i;
    // Start is called before the first frame update

    private void Awake()
    {//https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#634f8281edbc2a65c86270cc
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(hideButton());
    }

    void Start()
    {
        i = 0;
    }

    public void next()
    {

        i++;
        if (i == 1)
        {
            animation.SetBool("Drag->Rotate", true);
            StartCoroutine(hideButton());
        }
        else if (i == 2)
        {
            animation.SetBool("Drag->Rotate", false);
            animation.SetBool("Rotate->Flask", true);
            StartCoroutine(hideButton());
        }
        else
        {
            animation.SetBool("Rotate->Flask", false);
            foreach(GameObject go in children)
            {
                go.SetActive(false);
            }
        }
    }

    IEnumerator hideButton()
    {
        children[1].gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        children[1].gameObject.SetActive(true);
    }
}
