using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public float crosshairScale = 1f;
    private Rect position;

    void Start()
    {
        Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Confined;
    }
    void OnGUI()
    {
        // Determine the width and height of the crosshair:
        float width = crosshairTexture.width * crosshairScale;
        float height = crosshairTexture.height * crosshairScale;

        // Determine the mouse position:
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        // Create a rectangle at the mouse position:
        Rect position = new Rect(mousePos.x - (width / 2f), mousePos.y - (height / 2f), width, height);

        // Draw the texture into the rectangle:
        GUI.DrawTexture(position, crosshairTexture);
    }
}
