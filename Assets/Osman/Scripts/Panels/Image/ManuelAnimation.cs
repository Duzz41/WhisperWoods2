using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ManuelAnimation : MonoBehaviour
{
    public ImageData[] _imageDatas;
    [SerializeField] private List<GameObject> _imagesList;
    public GameObject _imageObject;
    public UnityEngine.UI.Image imageComponent;
    private int currentIndex = 0;
    private Coroutine displayCoroutine;

    void Start()
    {
        float _width = GetComponent<RectTransform>().rect.width;
        float _height = GetComponent<RectTransform>().rect.height;
        //Editörde Image Datada belirlemiş olduğum Imageleri olusturur.
        for (int i = 0; i < _imageDatas.Length; i++)
        {
            imageComponent = _imageObject.GetComponent<UnityEngine.UI.Image>();
            RectTransform rectTransform = _imageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(_width, _height);
            _imageObject.name = _imageDatas[i]._name;
            imageComponent.sprite = _imageDatas[i]._sourceSprite;

            GameObject newImage = Instantiate(_imageObject, transform);
            _imagesList.Add(newImage);
        }
    }
    public void StartAnim()
    {
        ShowImage(currentIndex);
        EvntManager.TriggerEvent("DisableCursor");
    }
    private void ShowImage(int index)
    {
        // Eğer geçerli bir coroutine varsa durdur
        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }

        // Seçili index'teki image'ı aç
        _imagesList[index].SetActive(true);

        // Belirtilen süre sonra kapat
        displayCoroutine = StartCoroutine(HideImageAfterTime(index));
    }

    private IEnumerator HideImageAfterTime(int index)
    {
        yield return new WaitForSeconds(_imageDatas[index]._showTime);
        if (index != _imagesList.Count - 1)
        {// Seçili index'teki image'ı kapat
            _imagesList[index].SetActive(false);

            // Eğer son eleman değilse bir sonraki image'ı göster
            if (index < _imagesList.Count - 1)
            {
                currentIndex = index + 1;
                ShowImage(currentIndex);
            }
        }
        else
            EvntManager.TriggerEvent("DisableCursor");
    }


}
