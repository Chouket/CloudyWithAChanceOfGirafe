using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirafeEggs : MonoBehaviour
{
    int count = 0;

    private void OnMouseDown()
    {
        count++;

        if (count >= 3)
            SceneManager.LoadScene("EGcutscene");
    }
}
