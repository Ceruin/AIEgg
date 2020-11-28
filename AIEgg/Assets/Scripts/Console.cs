using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] TMP_Text Text2;

    public void UpdateGUI(string text)
    {
        Text.text = text;
    }
}

