using UnityEngine;

/// <summary>
/// Character Coordinate Tracker
/// Displays the player's position as an overlay in the top-right corner.
/// Toggle the overlay with F3.
/// By Devanshu
/// </summary>
public class CharacterCoordinateTracker : MonoBehaviour
{
    [Header("Assign the player Transform to track")]
    public Transform player;

    [Header("Overlay Settings")]
    public Vector2 overlaySize = new Vector2(220, 60);
    public Vector2 overlayOffset = new Vector2(10, 10); // Offset from top-right
    public int fontSize = 18;

    private bool showOverlay = false;
    private GUIStyle textStyle;
    private Texture2D bgTexture;

    void Start()
    {
        // Create a black translucent background texture
        bgTexture = new Texture2D(1, 1);
        bgTexture.SetPixel(0, 0, new Color(0, 0, 0, 0.6f));
        bgTexture.Apply();

        // Set up the text style
        textStyle = new GUIStyle();
        textStyle.normal.textColor = Color.white;
        textStyle.fontSize = fontSize;
        textStyle.alignment = TextAnchor.UpperLeft;
        textStyle.wordWrap = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            showOverlay = !showOverlay;
        }
    }

    void OnGUI()
    {
        if (!showOverlay || player == null) return;

        float x = Screen.width - overlaySize.x - overlayOffset.x;
        float y = overlayOffset.y;

        // Draw the background
        GUI.DrawTexture(new Rect(x, y, overlaySize.x, overlaySize.y), bgTexture);

        // Draw the coordinates text
        Vector3 pos = player.position;
        string posText = $"Position:\nX: {pos.x:F2}\nY: {pos.y:F2}\nZ: {pos.z:F2}";
        GUI.Label(new Rect(x + 10, y + 10, overlaySize.x - 20, overlaySize.y - 20), posText, textStyle);
    }
}