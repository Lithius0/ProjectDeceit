using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] Transform focus;
    [SerializeField] float timeToFade = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Color oldColor = GetComponent<Text>().color;
        GetComponent<Text>().color = oldColor - new Color(0, 0, 0, (1f / timeToFade) * Time.deltaTime);
    }

    public void DisplayTitle()
    {
        GetComponent<Text>().color = GetComponent<Text>().color + new Color(0, 0, 0, 255);
    }
}
