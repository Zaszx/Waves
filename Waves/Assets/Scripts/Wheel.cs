using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Wheel
{
    public IEnumerator Spin(Items items, Ui ui)
    {
        Sfx.PlayWheelSpin();

        var images = new List<Image>();

        // Populate wheel
        for (int i = 0; i < 100; i++)
        {
            var itemPrefab = Prefabs.items.Random();
            var item = GameObject.Instantiate(itemPrefab);
            item.transform.SetParent(ui.WheelParent.transform, true);
            images.Add(item.GetComponent<Image>());
        }

        ui.WheelArrow.gameObject.SetActive(true);

        const float spinTime = 5f;
        var accumulatedTime = 0f;
        while (accumulatedTime < spinTime)
        {
            ui.WheelParent.transform.position -=
                ui.WheelSpeedCurve.Evaluate(accumulatedTime / spinTime) * Vector3.right * 50;

            accumulatedTime += Time.deltaTime;

            yield return null;
        }

        //Image selectedImage = (from image in images
        //    let start = image.rectTransform.position.x - image.rectTransform.sizeDelta.x * 0.5f
        //    let end = image.rectTransform.position.x + image.rectTransform.sizeDelta.x * 0.5f
        //    where start < xPosition && end > xPosition
        //    select image).FirstOrDefault();

        var mid = Screen.width / 2;
        var selectedImage =
            images.Aggregate(
                (curImage, next) => Mathf.Abs(curImage.transform.position.x - mid) < Mathf.Abs(next.transform.position.x - mid)
                    ? curImage
                    : next);

        Sfx.PlayWheelSelect();

        // Destroy others
        foreach (var image in images)
        {
            if(image != selectedImage)
            {
                image.CrossFadeAlpha(0, 2, true);
                GameObject.Destroy(image.gameObject, 2);
            }
        }

        ui.WheelArrow.gameObject.SetActive(false);

        // Move to middle
        accumulatedTime = 0.0f;
        var selectedLerpTime = 3.0f;
        var imageInitialPosition = selectedImage.transform.position;
        var imageTargetPosition = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        ui.BuKimeGirsinText.gameObject.SetActive(true);

        if(ui.isSafeMode)
        {
            ui.BuKimeGirsinText.text = "HAZIR";
        }
        else
        {
            ui.BuKimeGirsinText.text = "Bu Kime Girsin?";
        }

        while(accumulatedTime < selectedLerpTime)
        {
            var tText = ui.BuKimeGirsinTextFocusCurve.Evaluate(accumulatedTime / selectedLerpTime);
            ui.BuKimeGirsinText.transform.localScale = Vector3.one * tText;

            var tImage = ui.SelectedItemFocusCurve.Evaluate(accumulatedTime / selectedLerpTime);
            selectedImage.transform.position = Vector3.Lerp(imageInitialPosition, imageTargetPosition, tImage);

            accumulatedTime += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        ui.WheelParent.GetComponent<HorizontalLayoutGroup>().enabled = false; // Don't force children anymore

        // Align selected thing with wave object
        accumulatedTime = 0.0f;
        selectedLerpTime = 1.0f;
        imageInitialPosition = selectedImage.transform.position;
        imageTargetPosition = ui.WaveObject.transform.position;

        var waveObjectImage = ui.WaveObject.GetComponent<Image>();
        var selectedImgSize = selectedImage.rectTransform.sizeDelta;
        var waveObjectSize = waveObjectImage.rectTransform.sizeDelta;
        while (accumulatedTime < selectedLerpTime)
        {
            var tText = ui.BuKimeGirsinTextDefocusCurve.Evaluate(accumulatedTime / selectedLerpTime);
            ui.BuKimeGirsinText.transform.localScale = Vector3.one * tText;

            var tImage = ui.SelectedItemFocusCurve.Evaluate(accumulatedTime / selectedLerpTime);
            selectedImage.transform.position = Vector3.Lerp(imageInitialPosition, imageTargetPosition, tImage);
            selectedImage.rectTransform.sizeDelta = Vector2.Lerp(selectedImgSize, waveObjectSize, tImage);
            selectedImage.transform.localScale = Vector3.Lerp(selectedImage.transform.localScale, Vector3.one, tImage);

            yield return null;
            accumulatedTime += Time.deltaTime;
        }
        ui.BuKimeGirsinText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        ui.WaveObject.GetComponent<Image>().sprite = selectedImage.sprite;

        GameObject.Destroy(selectedImage.gameObject);

    }
}
