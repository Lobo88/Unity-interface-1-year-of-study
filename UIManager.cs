using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Animator startButton;
    public Animator SettingsButton;
    public Animator dialog;
    public Animator contentPanel;
    public Animator gearImage;
    public GameObject sound;
    public Animator command;
    public Animator button1;
    public Animator button2;
    public Animator button3;
    
    public void StartGame()
    {
        SceneManager.LoadScene("RocketMouse");
    }
    public void HiddenSound()// chowanie opcji sound z settings
    {
      sound.transform.gameObject.SetActive(false);
    }
    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        SettingsButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
        command.SetBool("isHidden", false);
    }
    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        SettingsButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
        sound.transform.gameObject.SetActive(true);
        command.SetBool("isHidden", true);
        button1.SetBool("isHidden", true);
        button2.SetBool("isHidden", true);
        button3.SetBool("isHidden", true);
    }
    public void ToggleMenu()
    {
        bool isHidden = contentPanel.GetBool("isHidden");
        contentPanel.SetBool("isHidden", !isHidden);
        gearImage.SetBool("isHidden", !isHidden);
    }
    public void Uruchom()
    {
        button1.SetBool("isHidden", false);
        button2.SetBool("isHidden", false);
        button3.SetBool("isHidden", false);
        command.SetBool("isHidden", true);
        dialog.SetBool("isHidden", true);
    }

}
