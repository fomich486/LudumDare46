using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuRose : MonoBehaviour
{
    public float angles;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, angles * Time.deltaTime);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

}
