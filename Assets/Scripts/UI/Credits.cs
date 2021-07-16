using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Credits : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private CanvasGroup _menu;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        _menu.blocksRaycasts = true;
        _animator.Play(AnimatorCredits.States.DropPanel);
    }
}
