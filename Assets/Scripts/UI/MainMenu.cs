using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creditButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Animator _panel;
    [SerializeField] private Fade _fade;
    [SerializeField] private float _transitionTime;

    private CanvasGroup _menu;

    private void Awake()
    {
        _menu = GetComponent<CanvasGroup>();

        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _creditButton.onClick.AddListener(OnCreditButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _creditButton.onClick.RemoveListener(OnCreditButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        _fade.PlayTransitionAnimation(1);
    }

    private void OnCreditButtonClick()
    {
        _menu.blocksRaycasts = false;
        _panel.Play(AnimatorCredits.States.RaisePanel);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
