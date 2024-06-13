using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]Button[] answersButtons;
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] GameObject MenuWindow;
    [SerializeField] Button StartButton;
    [SerializeField] TMP_Dropdown dificultyDropDown, themeDropdown;
    [SerializeField] Button nextButton;


    private void Start()
    {
        nextButton.onClick.AddListener (()=> QuizManager.instance.SelectQuiz(GameManager.Instance.Theme, GameManager.Instance.Dificulty));

        StartButton.onClick.AddListener (()=> GameManager.Instance.StartGame(dificultyDropDown.value, themeDropdown.value));


        for (int i = 0; i < answersButtons.Length; i++ )
        {
            int x = i;

            answersButtons[i].onClick.AddListener(() => QuizManager.instance.CheckAnswer(x));
            answersButtons[i].onClick.AddListener(() => nextButton.interactable = true);    
        } 
    }


    public void UpdateQuestion(Quiz quizSelected)
    {
        questionText.text = quizSelected.Question;

        for(int i = 0; i < answersButtons.Length; i++)
        {
            
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i];
            answersButtons[i].onClick.AddListener(() => nextButton.interactable = true);
            answersButtons[i].GetComponent<Image>().color = Color.white;

        }
        nextButton.interactable = false;

    }
    public void SetMenu(bool active)
    {
        MenuWindow.SetActive(active);    
    }

    public void HighlightButton(int correctAnswer, int answerSelected)
    {
        answersButtons[correctAnswer]. GetComponent<Image>().color = Color.green;

        if(answerSelected != correctAnswer)
        {
            answersButtons[answerSelected].GetComponent<Image>().color = Color.red;
        }

        for (int i = 0; i < answersButtons.Length; i++ )
        {
            answersButtons[i].interactable = false;
        }
    }

}
