using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
public class SettingsValues : MonoBehaviour
{

    public Slider sensitivitySlider;

    public float sensitivityValue;

    private CinemachineFreeLook camera;

    public GameObject pauseCanvas;
    public GameObject optionsMenu;

    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        optionsMenu = GameObject.Find("OptionsMenu");
        optionsMenu.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this);
        if (scene.name.Equals("TiinaUItesting") && optionsMenu.activeInHierarchy == true)
        {
            Debug.Log("Main menu options"); // Gets slider in main menu
            sensitivitySlider = GameObject.Find("SensitivitySlider").GetComponent<Slider>();
            sensitivitySlider.value = sensitivityValue;
            
            sensitivitySlider.onValueChanged.AddListener(delegate { valueChanged(); });
        }
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("Level"))
        {
            sensitivitySlider = GameObject.Find("SensitivitySlider").GetComponent<Slider>(); // gets slider and pause canvas as soon as scene is changed
            pauseCanvas = GameObject.Find("PauseCanvas");
            StartCoroutine(GetStuff());
        }
    }

    

    IEnumerator GetStuff()
    {
        yield return new WaitForSeconds(0.2f);
        //pauseCanvas = GameObject.Find("PauseCanvas");
        Debug.Log("Main Scene");
        
        Debug.Log(sensitivitySlider);
        camera = GameObject.Find("CM FreeLook1").GetComponent<CinemachineFreeLook>();
        //sensitivitySlider = GameObject.Find("SensitivitySlider").GetComponent<Slider>();
        sensitivitySlider.value = sensitivityValue;
        sensitivitySlider.onValueChanged.AddListener(delegate { valueChanged(); });
        camera.m_XAxis.m_MaxSpeed = sensitivityValue; // Changes cinemachines "sensitivity" to sensitivityValue
        pauseCanvas.SetActive(false);
    }

    public void valueChanged()
    {

        sensitivityValue = sensitivitySlider.value;
        
        if (scene.name.Equals("Level"))
        {
            camera.m_XAxis.m_MaxSpeed = sensitivityValue;
        }
        



    }



}
