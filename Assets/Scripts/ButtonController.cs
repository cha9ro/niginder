using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Application.OpenURL("http://localhost:8081/top/missionComplete?userId=3");
    }
}
