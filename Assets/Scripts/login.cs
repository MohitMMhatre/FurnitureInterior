using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{


    public GameObject username;
    public GameObject password;

    private string Username;
    private string Password;
    private string[] Lines;
    private string Decrypted;


    // Update is called once per frame
    void Update()
    {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            else if (password.GetComponent<InputField>().isFocused)
            {
                username.GetComponent<InputField>().Select();
            }




            if (Input.GetKeyDown(KeyCode.Return))
            {
                loging();
            }


        }
    }

    public void loging()
    {

        bool UN = false;
        bool PW = false;
        Username = userdecrypt(Username);
        Password = userdecrypt(Password);
        print(@Application.persistentDataPath);

        if (Username != "")
        {
            if (System.IO.File.Exists(@Application.persistentDataPath + "//" + Username + ".txt"))
            {

                UN = true;
                Lines = System.IO.File.ReadAllLines(@Application.persistentDataPath + "//" + Username + ".txt");


            }
            else
            {

                username.GetComponent<InputField>().text = "";
                username.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Username Invalid";
            }
        }
        else
        {

            username.GetComponent<InputField>().text = "";
            username.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "cannot be empty";
        }
        if (Password != "")
        {

            if (System.IO.File.Exists(@Application.persistentDataPath + "//" + Username + ".txt"))
            {


                string Decryptpass = Lines[2];

                if (Password == Decryptpass)
                {
                    PW = true;

                }
            }
            else
            {
                password.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "File not found";
            }


        }
        else
        {
            password.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "cannot be empty";
        }

        if (UN && PW)
        {

            SceneManager.LoadScene("Front Page");
        }
    }
    private string userdecrypt(string Newstring)
    {
        bool Clear = true;
        int i = 1;
        foreach (char c in Newstring)
        {
            if (Clear)
            {
                Newstring = "";
                Clear = false;
            }
            i++;
            char Encrypted = (char)(c * i);
            Newstring += Encrypted.ToString();

        }
        return (Newstring);
    }


    private string decrypt(string newstring)
    {
        int i = 1;
        foreach (char c in newstring)
        {

            i++;
            char Decrypt = (char)(c / i);
            Decrypted += Decrypt.ToString();
        }

        return (Decrypted);
    }
}
