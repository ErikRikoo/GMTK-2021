using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.UI;

public class FloatVariableText : MonoBehaviour
{
    [SerializeField] private FloatVariable _timer;
    [SerializeField] private Text _text;

    private void Update()
    {
        _text.text = ((int)_timer.Value).ToString();
    }
}
