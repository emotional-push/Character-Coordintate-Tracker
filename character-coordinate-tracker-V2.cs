using UnityEngine;

/// <summary>
/// Character Coordinate Tracker
/// Displays the player's position as an overlay in the top-right corner.
/// Toggle the overlay with F3.
/// By Devanshu
/// </summary>
[DisallowMultipleComponent]
public class CharacterCoordinateTracker : MonoBehaviour
{
    [Header("Assign the player Transform to track")]
    public Transform player;

    [Header("Overlay Settings")]
    public Vector2 overlaySize = new Vector2(220, 60);
    public Vector2 overlayOffset = new Vector2(10, 10); // Offset from top-right
    [Range(10, 40)]
    public int fontSize = 18;

    private bool showOverlay = false;
    private GUIStyle textStyle;
    private Texture2D bgTexture;

    void Awake()
    {
        // Defensive: Ensure overlay size is reasonable
        overlaySize.x = Mathf.Max(overlaySize.x, 100);
        overlaySize.y = Mathf.Max(overlaySize.y, 40);
        overlayOffset.x = Mathf.Max(overlayOffset.x, 0);
        overlayOffset.y = Mathf.Max(overlayOffset.y, 0);
    }

    void Start()
    {
        // Defensive: If player not set, try to find a tagged "Player"
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null)
                player = found.transform;
        }

        // Create a black translucent background texture
        bgTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        bgTexture.SetPixel(0, 0, new Color(0, 0, 0, 0.6f));
        bgTexture.Apply();

        // Set up the text style
        textStyle = new GUIStyle(GUI.skin.label);
        textStyle.normal.textColor = Color.white;
        textStyle.fontSize = fontSize;
        textStyle.alignment = TextAnchor.UpperLeft;
        textStyle.wordWrap = true;
        textStyle.richText = true;
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
        if (!showOverlay)
            return;

        if (player == null)
        {
            DrawErrorOverlay("Player Transform not assigned!");
            return;
        }

        float x = Screen.width - overlaySize.x - overlayOffset.x;
        float y = overlayOffset.y;

        // Draw the background
        GUI.DrawTexture(new Rect(x, y, overlaySize.x, overlaySize.y), bgTexture);

        // Draw the coordinates text
        Vector3 pos = player.position;
        string posText = $"<b>Position:</b>\nX: {pos.x:F2}\nY: {pos.y:F2}\nZ: {pos.z:F2}";
        GUI.Label(new Rect(x + 10, y + 10, overlaySize.x - 20, overlaySize.y - 20), posText, textStyle);
    }

    private void DrawErrorOverlay(string message)
    {
        float x = Screen.width - overlaySize.x - overlayOffset.x;
        float y = overlayOffset.y;
        GUI.DrawTexture(new Rect(x, y, overlaySize.x, overlaySize.y), bgTexture);
        GUIStyle errorStyle = new GUIStyle(textStyle);
        errorStyle.normal.textColor = Color.red;
        errorStyle.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(x + 10, y + 10, overlaySize.x - 20, overlaySize.y - 20), message, errorStyle);
    }

    void OnDestroy()
    {
        if (bgTexture != null)
        {
            Destroy(bgTexture);
        }
    }
}