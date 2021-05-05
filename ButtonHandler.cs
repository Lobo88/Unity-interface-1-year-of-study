using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonHandler : MonoBehaviour
  
{
    public GameObject ob;

   public char activeButton;
    string nowy = "Zmień latanie pod: ";
    public void setA()
    {
       
        activeButton = 'a';
        setText("active");

        Text txtB = ob.GetComponentInChildren<Text>();
       txtB.text = nowy+'b' ;
       
    }
    
    
    public void setB()
    {
       
        activeButton = 'b';
        setText("active");
        Text txtB = ob.GetComponentInChildren<Text>();
        txtB.text = nowy+'a';
    }

    public void setText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
        
        if (activeButton=='a') {change(activeButton);}
        else if (activeButton == 'b') { change(activeButton); }
    }
    private void change(char znak)
    {
        command zm = new command();

        zm.wez = znak;
    }
}

