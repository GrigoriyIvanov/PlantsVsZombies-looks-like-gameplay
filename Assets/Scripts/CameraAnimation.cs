using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private void Start()
    {
        LoseController.onDefeat += onDefeat;
    }
    private void onDefeat()
    {

    }
}
