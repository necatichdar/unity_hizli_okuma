using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hizli_okuma : MonoBehaviour
{
    public GameObject cumle;
    public string cumlee;
    public GameObject inputField;
    public GameObject textDisplay;
    public UnityEngine.UI.Text bas, orta, son;
    int interval1 = 200;
    System.Timers.Timer aTimer;
    string deneme;
    public UnityEngine.UI.Text text_deneme;

    //public string kelime;
    List<string> kelimeler = new List<string>();

    private void Start()
    {
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 200;
    }

    public void Timer1()
    {
        cumlee = inputField.GetComponent<Text>().text;
        CumleParcala(cumlee);
        int uzunluk = kelimeler.Count, index = 0;
        aTimer.Elapsed += (a, b) =>
        {
            if (index < uzunluk)
            {
                kelimeRenklendir(kelimeler[index]);
                index += 1;
            }
        };
        aTimer.Enabled = true;
    }

    public void TimerStop()
    {
        aTimer.Enabled = false;
    }
    public void CumleParcala(string cumle)
    {
        kelimeler.AddRange(cumle.Replace("\n", " ").Split(' ').Where(text => !string.IsNullOrWhiteSpace(text)));
    }

    public void kelimeRenklendir(string kelime)
    {
        string b = "", s = "", o = "";
        if (kelime.Length == 1)
            o = kelime;
        else if (kelime.Length == 2)
        {
            b = kelime[0].ToString();
            o = kelime[1].ToString();
        }
        else if (kelime.Length > 2 && kelime.Length < 6)
        {
            b = kelime[0].ToString();
            o = kelime.Substring(1, 2);
            s = kelime.Substring(2);
        }
        else if (kelime.Length >= 6 && kelime.Length < 8)
        {
            b = kelime.Substring(0, 2);
            o = kelime.Substring(2, 3);
            s = kelime.Substring(3);

        }
        else if (kelime.Length >= 8)
        {
            b = kelime.Substring(0, 3);
            o = kelime.Substring(3, 4);
            s = kelime.Substring(4);
        }
        bas.text = b;
        orta.text = o;
        son.text = s;
    }
}