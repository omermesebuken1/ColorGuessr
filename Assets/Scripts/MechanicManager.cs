using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MechanicManager : MonoBehaviour
{
    [SerializeField] private GameObject theObject;
    [SerializeField] private List<Image> objectColors = new List<Image>();
    [SerializeField] private Slider RSlider;
    [SerializeField] private Slider GSlider;
    [SerializeField] private Slider BSlider;
    [SerializeField] private TextMeshProUGUI RValue;
    [SerializeField] private TextMeshProUGUI GValue;
    [SerializeField] private TextMeshProUGUI BValue;
    [SerializeField] private Slider SxSlider;
    [SerializeField] private Slider SySlider;
    [SerializeField] private Slider SzSlider;
    [SerializeField] private TextMeshProUGUI SxValue;
    [SerializeField] private TextMeshProUGUI SyValue;
    [SerializeField] private TextMeshProUGUI SzValue;
    [SerializeField] private Slider RxSlider;
    [SerializeField] private Slider RySlider;
    [SerializeField] private Slider RzSlider;
    [SerializeField] private TextMeshProUGUI RxValue;
    [SerializeField] private TextMeshProUGUI RyValue;
    [SerializeField] private TextMeshProUGUI RzValue;

    [SerializeField] private GameObject ScalePanel;
    [SerializeField] private GameObject RotatePanel;
    [SerializeField] private GameObject ColorizePanel;

    [SerializeField] private GameObject ScaleButton;
    [SerializeField] private GameObject RotateButton;
    [SerializeField] private GameObject ColorizeButton;
    

    private Color color;
    private int currentColor;
    private int score;
    private bool gameEnd;

    private Vector3 scaleVector;
    private Vector3 rotationVector;


    private void Start()
    {
        ChangePanel("Scale");

        foreach (var item in theObject.GetComponent<MeshRenderer>().materials)
        {
            item.color = Color.white;
        }
        foreach (var item in objectColors)
        {
            item.color = Color.white;
        }
        gameEnd = false;
        currentColor = 0;
    }

    private void Update()
    {
        
        AdjustScale();
        AdjustRotation();
        AdjustColor();


    }

    private void AdjustColor()
    {
        RValue.text = RSlider.value.ToString();
        GValue.text = GSlider.value.ToString();
        BValue.text = BSlider.value.ToString();

        color = new Color32((byte)(RSlider.value), (byte)(GSlider.value), (byte)(BSlider.value), 255);

        objectColors[currentColor].color = color;
        theObject.GetComponent<MeshRenderer>().materials[currentColor].color = color;
    }

    public void ChangeColorNumber(int colorNo)
    {
        currentColor = colorNo;
    }

    public void ChangePanel(string name)
    {
        switch (name)
        {
            case "Scale":
            ScalePanel.SetActive(true);
            RotatePanel.SetActive(false);
            ColorizePanel.SetActive(false);
            ScaleButton.GetComponent<Image>().color = Color.white;
            RotateButton.GetComponent<Image>().color = Color.grey;
            ColorizeButton.GetComponent<Image>().color = Color.grey;
            break;

            case "Rotate":
            ScalePanel.SetActive(false);
            RotatePanel.SetActive(true);
            ColorizePanel.SetActive(false);
            ScaleButton.GetComponent<Image>().color = Color.grey;
            RotateButton.GetComponent<Image>().color = Color.white;
            ColorizeButton.GetComponent<Image>().color = Color.grey;
            break;

            case "Colorize":
            ScalePanel.SetActive(false);
            RotatePanel.SetActive(false);
            ColorizePanel.SetActive(true);
            ScaleButton.GetComponent<Image>().color = Color.grey;
            RotateButton.GetComponent<Image>().color = Color.grey;
            ColorizeButton.GetComponent<Image>().color = Color.white;
            break;
            
        }
    }

    private void AdjustScale()
    {
        SxValue.text = SxSlider.value.ToString("F2");
        SyValue.text = SySlider.value.ToString("F2");
        SzValue.text = SzSlider.value.ToString("F2");

        scaleVector = new Vector3(SxSlider.value,SySlider.value,SzSlider.value);
        
        theObject.GetComponent<Transform>().localScale = scaleVector;
    }

    private void AdjustRotation()
    {
        RxValue.text = RxSlider.value.ToString();
        RyValue.text = RySlider.value.ToString();
        RzValue.text = RzSlider.value.ToString();

        rotationVector = new Vector3(RxSlider.value,RySlider.value,RzSlider.value);
        
        theObject.GetComponent<Transform>().rotation = Quaternion.Euler(rotationVector);
    }


}
