using UnityEngine;
using UnityEngine.UI;

public class InspectObject : MonoBehaviour
{
    public GameObject inspectWindow;
    public Image inspectImage;
    public Text description;
    public float imageScale = 2f;

    private void Start()
    {
        inspectWindow.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInspectWindow();
        }
    }

    public void OpenInspectWindow(Sprite objectSprite, string objectDesc)
    {
        inspectImage.sprite = objectSprite;
        inspectImage.transform.localScale = new Vector3(imageScale, imageScale, 1);
        description.text = objectDesc;
        inspectWindow.SetActive(true);
    }

    public void CloseInspectWindow()
    {
        inspectWindow.SetActive(false);
    }

    public void OnMouseDown()
    {
        OpenInspectWindow(GetComponent<Image>().sprite, "Description goes here.");
    }
}
