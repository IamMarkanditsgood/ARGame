using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TextMeshProUGUI outputText;

    public void SetGenericValue<T>(T value)
    {
        outputText.text = value.ToString();
    }
}
