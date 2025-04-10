using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //����� ��� ����

public class Game_manager : MonoBehaviour
{
    //[SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] TextMeshProUGUI _levelTWO;
    [SerializeField] TextMeshProUGUI _levelTHREE;

    //[SerializeField] GameObject _finishWindow;
    [SerializeField] Count_coin _coinManager;

    //[SerializeField] GameObject _okno;


    // Start is called before the first frame update
    void Start()
    {
        _level.text = SceneManager.GetActiveScene().name; //����� ��� ����(������ ��� ����� � �������� � �����
        _levelTWO.text = SceneManager.GetActiveScene().name;
        _levelTHREE.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void NextLevel()
    {

        int next = SceneManager.GetActiveScene().buildIndex + 1;
        int LevelOne = SceneManager.GetActiveScene().buildIndex;//d
        int rers = LevelOne - LevelOne;
        if (next < SceneManager.sceneCountInBuildSettings) // ���� ������ ���� ����� ������ ������ ���-�� ����, ����� ���������� ���� �����
        {
            _coinManager.AddOne();
            _coinManager.SaveToProgress();
            SceneManager.LoadScene(next);
           
        }
        if (next == SceneManager.sceneCountInBuildSettings)//d
        {
            SceneManager.LoadScene(rers); //d
        }


    }
    public void Restart()
    {
        int res = SceneManager.GetActiveScene().buildIndex;
        //_coinManager.SaveToProgress();
        SceneManager.LoadScene(res);
    }
}
