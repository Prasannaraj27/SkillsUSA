using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerModeUI : MonoBehaviour
{
    TMP_Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = "Mode: Explore";
    }

    void Update()
    {
        string switchText;
        if (FindObjectOfType<Player>().CanSwitchModes())
        {
            switchText = "|SPACE to Switch|\n";
        }
        else
        {
            switchText = "";
        }

        if (FindObjectOfType<Player>().GetInRunningMode())
        {
            textComponent.text = switchText + "Mode: Run";
            //StartCoroutine(RunningMode());
        }
        else
        {
            textComponent.text = switchText + "Mode: Explore";
            //StartCoroutine(ExploringMode());
        }
    }
    /*
    IEnumerator RunningMode()
    {
        int cooldown = 5;
        for (int i = cooldown; i >= 0; i--)
        {
            textComponent.text = "Can Switch in: " + cooldown + "\nMode: Run";
            yield return new WaitForSeconds(1);
            cooldown--;
        }
        textComponent.text = "Mode: Run";
    }

    IEnumerator ExploringMode()
    {
        int cooldown = 1;
        textComponent.text = "Can Switch in: " + cooldown + "\nMode: Explore";
        yield return new WaitForSeconds(1);
        cooldown--;
        textComponent.text = "Mode: Explore";
    }*/
}
