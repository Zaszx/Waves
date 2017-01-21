using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel
{
    
    public IEnumerator Spin(Items items, Ui ui)
    {
        List<Image> images = new List<Image>();
        float spriteSize = Screen.width / 5.0f;

        float startingPosition = -Screen.width * 10;
        float endPosition = Screen.width * 10;
        float currentPosition = startingPosition;

        ui.WheelParent.transform.position = new Vector3(Screen.width * 0.5f, 0, 0);

        while(currentPosition < endPosition)
        {
            for (int i = 0; i < (int)ItemType.Count; i++)
            {
                Image newImage = new GameObject().AddComponent<Image>();
                newImage.sprite = items.itemTypeToSpriteMap[(ItemType)i];
                newImage.rectTransform.sizeDelta = new Vector2(spriteSize, spriteSize);
                newImage.transform.position = new Vector3(currentPosition, Screen.height - spriteSize * 0.5f, 0);
                newImage.transform.parent = ui.WheelParent.transform;
                images.Add(newImage);

                currentPosition = currentPosition + spriteSize;
            }
        }

        float fastTime = 2.0f + Random.Range(0.0f, 1.0f);
        float fastSpeed = 2.5f;
        float accumulatedTime = 0.0f;
        while(accumulatedTime < fastTime)
        {
            ui.WheelParent.transform.position += fastSpeed * Vector3.right;
            yield return new WaitForEndOfFrame();
            accumulatedTime = accumulatedTime + Time.deltaTime;
        }

        float speed = fastSpeed;
        while(speed >= 0.1f)
        {
            ui.WheelParent.transform.position += speed * Vector3.right;
            yield return new WaitForEndOfFrame();
            speed = speed * 0.99f;
        }

        float xPosition = Screen.width * 0.5f;
        Image selectedImage = null;
        foreach(Image image in images)
        {
            float start = image.rectTransform.position.x - image.rectTransform.sizeDelta.x;
            float end = image.rectTransform.position.x + image.rectTransform.sizeDelta.x;

            if(start < xPosition && end > xPosition)
            {
                selectedImage = image;
                break;
            }
        }

        foreach (Image image in images)
        {
            if(image != selectedImage)
            {
                GameObject.Destroy(image.gameObject);
            }
        }

        accumulatedTime = 0.0f;
        float totalTime = 3.0f;
        Vector3 imageInitialPosition = selectedImage.transform.position;
        Vector3 imageTargetPosition = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        ui.BuKimeGirsinText.gameObject.SetActive(true);
        while(accumulatedTime < totalTime)
        {
            float percentage = accumulatedTime / totalTime;
            ui.BuKimeGirsinText.fontSize = Mathf.Max(2, (int)(percentage * 50.0f));
            selectedImage.transform.position = Vector3.Lerp(imageInitialPosition, imageTargetPosition, percentage);

            yield return new WaitForEndOfFrame();
            accumulatedTime = accumulatedTime + Time.deltaTime;
        }

        yield return new WaitForSeconds(0.5f);

        accumulatedTime = 0.0f;
        totalTime = 1.0f;
        imageInitialPosition = selectedImage.transform.position;
        imageTargetPosition = ui.WaveObject.transform.position;

        Image waveObjectImage = ui.WaveObject.GetComponent<Image>();
        Vector2 initialSize = new Vector2(spriteSize, spriteSize);
        Vector2 waveObjectSize = waveObjectImage.rectTransform.sizeDelta;

        while (accumulatedTime < totalTime)
        {
            float percentage = accumulatedTime / totalTime;
            ui.BuKimeGirsinText.fontSize = Mathf.Max(2, (int)((1 - percentage) * 50.0f));
            selectedImage.transform.position = Vector3.Lerp(imageInitialPosition, imageTargetPosition, percentage);

            selectedImage.rectTransform.sizeDelta = Vector2.Lerp(initialSize, waveObjectSize, percentage);
            selectedImage.transform.localScale = Vector3.Lerp(selectedImage.transform.localScale, Vector3.one, percentage);

            yield return new WaitForEndOfFrame();
            accumulatedTime = accumulatedTime + Time.deltaTime;
        }
        ui.BuKimeGirsinText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        
        ui.WaveObject.GetComponent<Image>().sprite = items.itemTypeToSpriteMap[ItemType.Boru];
        
        GameObject.Destroy(selectedImage.gameObject);

    }
}
