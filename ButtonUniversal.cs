using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonUniversal : MonoBehaviour
{
    public void  myFunction()
    {
        Text txt = transform.Find("Text3").GetComponent<Text>();
        txt.GetComponent<Text>().enabled = false;
        
    }
    public void LimitCharacter()
    {
        InputField input = GetComponent<InputField>();


        input.characterLimit = 1;
        
    }

}
