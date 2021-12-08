using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string _levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(_levelName);
    }
}
