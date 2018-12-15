using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class signin : MonoBehaviour
{

    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confpass;
    public GameObject signinbutton;

    private string Username;
    private string Email;
    private string Password;
    private string Confpass;
    private string Form;
    private bool EmailValid = true;
    private string[] characters = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "{", "[", "}", "]", "?", "<", ",", ">", "." };


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }
            else if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            else if (password.GetComponent<InputField>().isFocused)
            {
                confpass.GetComponent<InputField>().Select();
            }
            else if (confpass.GetComponent<InputField>().isFocused)
            {
                signinbutton.GetComponent<Button>().Select();

            }
            else if (signinbutton.GetComponent<Button>().IsInteractable())
            {
                username.GetComponent<InputField>().Select();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Confpass = confpass.GetComponent<InputField>().text;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            regsterin();
        }



    }

    void emailvalidation()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            bool SW = false;
            bool EW = false;
            if (Email.StartsWith(characters[i]))
            {
                SW = true;
            }
            if (Email.EndsWith(characters[i]))
            {
                EW = true;
            }
            if (SW == true && EW == true)
            {
                EmailValid = false;
            }
        }
    }



    public void regsterin()
    {

        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if (Username != "")
        {
            if (!System.IO.File.Exists(@Application.persistentDataPath + "//" + Username + ".txt"))
            {
                UN = true;
            }
            else
            {
                username.GetComponent<InputField>().text = "";
                username.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Username Taken";
            }
        }
        else
        {

            //Debug.LogWarning("Enter Username");
            username.GetComponent<InputField>().text = "";
            username.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "cannot be empty";
        }

        if (Email != "")
        {
            emailvalidation();
            if (EmailValid)
            {
                if (Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        EM = true;
                    }
                    else
                    {
                        email.GetComponent<InputField>().text = "";
                        email.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Invalid Email";
                    }
                }
                else
                {
                    email.GetComponent<InputField>().text = "";
                    email.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "invalid Email id";
                }
            }
            else
            {
                email.GetComponent<InputField>().text = "";
                email.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "invalid Email id";
            }
        }
        else
        {
            email.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "cannot be empty";
        }

        if (Password != "")
        {
            if (Password.Length >= 8)
            {
                bool hasUpperCaseLetter = false;
                bool hasLowerCaseLetter = false;
                bool hasDecimalDigit = false;
                foreach (char c in Password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
                if (hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit)
                {
                    PW = true;
                }
                else
                {
                    password.GetComponent<InputField>().text = "";
                    password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Invalid Password";

                     }

            }
            else
            {
                password.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Invalid Password";
                }

        }
        else
        {
            password.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "cannot be empty";
        }

        if (Confpass != "")
        {
            if (Confpass == Password)
            {
                CPW = true;
            }
            else
            {
                confpass.GetComponent<InputField>().text = "";
                confpass.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "password dont match";
            }
        }
        else
        {
            confpass.GetComponent<InputField>().text = "";
            confpass.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "cannot be empty";
        }


        if (UN == true && EM == true & PW == true && CPW == true)
        {


            Username = (Encrpt(Username));
            Debug.Log(Username);
            Email = (Encrpt(Email));
            Password = (Encrpt(Password));
            Debug.Log(Password);

            Form = (Username + "\n" + Email + "\n" + Password);

            System.IO.File.WriteAllText(@Application.persistentDataPath + "//" + Username + ".txt", Form);
            username.GetComponent<InputField>().text = "";
            username.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Username";
            email.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Email";
            password.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Password";
            confpass.GetComponent<InputField>().text = "";
            confpass.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "confirm password";
            print("Registration Complete");
            SceneManager.LoadScene("Front Page");
            print(Form);
        }




    }
    private string Encrpt(string Newstring)
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

}