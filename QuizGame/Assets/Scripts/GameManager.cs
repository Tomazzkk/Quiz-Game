using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
   
    {
        Instance = this;
    }
    #endregion

    Quiz.Dificulty dificulty;
    Quiz.Theme theme;
    QuizManager quizManager;

    public Quiz.Dificulty Dificulty { get => dificulty;}
    public Quiz.Theme Theme { get => theme;}

    private void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }
    // Inicia o jogo quanto o botao start do menu for pressionado
    public void StartGame(int difficultSelected, int ThemeSelected)
    {
        //Fechar a janela de menu
        UIManager.instance.SetMenu(false);
        //Atualizar a dificuldade e tema selecionado
        dificulty = (Quiz.Dificulty)difficultSelected;
        theme = (Quiz.Theme) ThemeSelected;
        //Solicitar um novo quiz
        quizManager.SelectQuiz(Theme, Dificulty);
    }

    public void GameOver()
    {
        // Implementa��o do que acontece quando o jogo acaba
    }
}
