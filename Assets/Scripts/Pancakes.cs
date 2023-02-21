using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pancakes : MonoBehaviour
{
    [SerializeField] GameObject _buttonAct;
    [SerializeField] GameObject _buttonPas;


    [SerializeField] Text _incomeTXT;
    [SerializeField] Text _upgradeTXT;
    [SerializeField] Text _lvlTXT;
    [SerializeField] Text _ResultOfIncomeTXT;

    [SerializeField] Slider _slider;

    private int _lvl = 0;
    private float _speed = 1.1f;
    private int _income = 400;
    private int _upgrade = 2000;

    public int _resultMoney;

    public int _Upgrade { get { return _upgrade; } set { _upgrade = value; } }
    public int _Level { get { return _lvl; } set { _lvl = value; } }
    public float _Speed { get { return _speed; } set { _speed = value; } }
    public int _Income { get { return _income; } set { _income = value; } }


    void Start()
    {
        _lvlTXT.text = _lvl.ToString();
    }


    void Update()
    {
        if (_lvl != 0)
        {
            _slider.value += (_speed / 10) * Time.deltaTime;
            if (_slider.value >= 1)
            {
                _slider.value = 0;
                _resultMoney = int.Parse(_incomeTXT.text) + int.Parse(_ResultOfIncomeTXT.text);
                _ResultOfIncomeTXT.text = _resultMoney.ToString();
            }
            _incomeTXT.text = _income.ToString();
            _upgradeTXT.text = _upgrade.ToString();
        }
        ShowButton();
    }

    void ShowButton()
    {
        if (int.Parse(_ResultOfIncomeTXT.text) >= _upgrade)
        {
            _buttonAct.SetActive(true);
            _buttonPas.SetActive(false);
        }
        else
        {
            _buttonAct.SetActive(false);
            _buttonPas.SetActive(true);
        }
    }

    public void Upgrade()
    {
        if (int.Parse(_ResultOfIncomeTXT.text) >= _upgrade)
        {
            _ResultOfIncomeTXT.text = (int.Parse(_ResultOfIncomeTXT.text) - _upgrade).ToString();
            _lvlTXT.text = (int.Parse(_lvlTXT.text) + 1).ToString();
            _lvl++;
            _income *= 2;
            _upgrade *= 2;
            _incomeTXT.text = _income.ToString();
            _upgradeTXT.text = _upgrade.ToString();
            _speed += _lvl * 0.11f;
        }
    }
}
