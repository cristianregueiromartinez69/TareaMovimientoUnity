using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControllerCenital : MonoBehaviour
{
    public Transform[] target;
    public float rotationSpeed = 10.0f;
    public int indexTerreno = 0;
    public Text countLevelsTextToChange;

    void Start()
    {

    }
    void Update()
    {

        transform.RotateAround(target[indexTerreno].position, Vector3.up, rotationSpeed * Time.deltaTime);

        transform.LookAt(target[indexTerreno]);
        changeTerremo();

    }

    void changeTerremo()
    {
        if (countLevelsTextToChange.text == "Level: 2/3"){
            indexTerreno = 1;
        }
        else if (countLevelsTextToChange.text == "Level: 3/3"){
            indexTerreno = 2;
        } 
    }
}

