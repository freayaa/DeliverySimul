using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] Sprite _soundOnSprite;
    [SerializeField] Sprite _soundOffSprite;

    [SerializeField] Button _soundButton;

    public void SoundToggleButton()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            _soundButton.image.sprite = _soundOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            _soundButton.image.sprite = _soundOffSprite;
        }
    }
}