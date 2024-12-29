using UnityEngine;
using UnityEngine.UI;

public class Sensibility : MonoBehaviour
{

    [SerializeField] Slider verticalSlider;
    [SerializeField] Slider horizontalSlider;

    public const string VERTICAL_SENS = "VerticalSensivility";
    public const string HORIOZONTAL_SENS = "HorizontalSensivility";

    [SerializeField] CameraMovement playerCameraMovement;

    private void Awake()
    {
        verticalSlider.onValueChanged.AddListener(SetVerticalSensivity);
        horizontalSlider.onValueChanged.AddListener(SetHorizontalSensivity);
        if(playerCameraMovement != null)
        {
            playerCameraMovement.sensitivityX = PlayerPrefs.GetFloat(VERTICAL_SENS);
            playerCameraMovement.sensitivityY = PlayerPrefs.GetFloat(HORIOZONTAL_SENS);
        }
    }

    private void Start()
    {
        verticalSlider.value = PlayerPrefs.GetFloat(VERTICAL_SENS);
        horizontalSlider.value = PlayerPrefs.GetFloat(HORIOZONTAL_SENS);
    }

    void SetVerticalSensivity(float sensivity)
    {
        if(playerCameraMovement != null)
        {
            playerCameraMovement.sensitivityX = sensivity;
        }
        PlayerPrefs.SetFloat(VERTICAL_SENS, sensivity);
    }
    void SetHorizontalSensivity(float sensivity)
    {
        if(playerCameraMovement != null)
        {
            playerCameraMovement.sensitivityY = sensivity;
        }
        PlayerPrefs.SetFloat(HORIOZONTAL_SENS, sensivity);
    }
}
