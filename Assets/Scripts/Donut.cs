using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Donut : MonoBehaviour
{
    [SerializeField] GameObject _buttonAct;
    [SerializeField] GameObject _buttonPas;

    [SerializeField] Text _incomeTXT;
    [SerializeField] Text _upgradeTXT;
    [SerializeField] Text _lvlTXT;
    [SerializeField] Text _ResultOfIncomeTXT;

    [SerializeField] Slider _slider;

    UI_Scripts scripts;

    private int _lvl = 0;
    private float _speed = 3f;
    private int _income = 10;
    private int _upgrade = 50;

    public int _Level { get { return _lvl; } set { _lvl = value; } }
    public float _Speed { get { return _speed; } set { _speed = value; } }
    public int _Income { get { return _income; } set { _income = value; } }
    public int _Upgrade { get { return _upgrade; } set { _upgrade = value; } }

    public int _resultMoney;

    public void Save()
    {
        Debug.Log("Save successfully");
        PlayerPrefs.SetInt("income_donut", _Income);
        PlayerPrefs.SetInt("level_donut", _Level);
        PlayerPrefs.SetFloat("speed_donut", _Speed);
        PlayerPrefs.SetInt("upgrade_donut", _Upgrade);
    }

    public void Load()
    {
        Debug.Log("Load successfully");
        _Level = PlayerPrefs.GetInt("level_donut");
        _Speed = PlayerPrefs.GetFloat("speed_donut");
        _Income = PlayerPrefs.GetInt("income_donut");
        _Upgrade = PlayerPrefs.GetInt("upgrade_donut");
    }

    void Start()
    {
        _lvlTXT.text = _Level.ToString();
    }

    private void OnEnable()
    {
        UI_Scripts.onSaved += Save;
        UI_Scripts.onLoaded += Load;
    }

    //private void OnDisable()
    //{
    //    UI_Scripts.onSaved -= Save;
    //    UI_Scripts.onLoaded -= Load;
    //}

    void Update()
    {

        if (_lvl != 0)
        {
            _slider.value += (_Speed / 10) * Time.deltaTime;
            if (_slider.value >= 1)
            {
                _slider.value = 0;
                _resultMoney = int.Parse(_incomeTXT.text) + int.Parse(_ResultOfIncomeTXT.text);
                _ResultOfIncomeTXT.text = _resultMoney.ToString();
            }
            _incomeTXT.text = _Income.ToString();
            _upgradeTXT.text = _Upgrade.ToString();
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
        if (int.Parse(_ResultOfIncomeTXT.text) >= _Upgrade)
        {
            _ResultOfIncomeTXT.text = (int.Parse(_ResultOfIncomeTXT.text) - _Upgrade).ToString();
            _lvlTXT.text = (int.Parse(_lvlTXT.text) + 1).ToString();
            _Level++;
            _Income *= 2;
            _Upgrade *= 2;
            _incomeTXT.text = _Income.ToString();
            _upgradeTXT.text = _Upgrade.ToString();
            _Speed += _Level * 0.11f;
        }
    }

}
