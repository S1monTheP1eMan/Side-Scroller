using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Fade : MonoBehaviour
{
    [SerializeField] private float _transitionTime;

    private Animator _canvas;
    private int _sceneIndex;

    private void Awake()
    {
        _canvas = GetComponent<Animator>();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void PlayTransitionAnimation(int sceneIndex)
    {
        _canvas.SetTrigger("Finished");

        _sceneIndex = sceneIndex;
    }
}
