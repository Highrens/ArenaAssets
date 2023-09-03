using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Text bigText;
    public Text smallText;
    public Animator anim;
    // Start is called before the first frame update
    public void ShowMessage(string BigMessageText, string smallMessageText)
    {
        bigText.text = BigMessageText;
        smallText.text = smallMessageText;
        anim.SetTrigger("message");
    }
}
