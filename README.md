# Character Coordinate Tracker

A simple, customizable Unity script that displays your player's position (coordinates) as an in-game overlay. Toggle the overlay with the **F3** key. The overlay appears in the top-right corner with a clean white font and a translucent black background.

---

## ✨ Features

- **Toggle Overlay:** Press F3 to show/hide the coordinate overlay.
- **Customizable:** Easily change overlay size, position, and font size in the Inspector.
- **Non-intrusive:** Overlay appears only when needed, perfect for debugging or development.
- **Easy Integration:** Just add the script and assign your player!

---

## 🚀 Installation

1. **Download the Script**

   - Download `PlayerPositionOverlay.cs` from this repository.

2. **Add to Your Project**

   - Place `PlayerPositionOverlay.cs` into your Unity project's `Assets/Scripts` folder (or any folder inside `Assets`).

3. **Attach the Script**

   - In the Unity Editor, select any GameObject in your scene (e.g., your player, a UI manager, or an empty GameObject).
   - Click **Add Component** and search for `Player Position Overlay`.
   - Add the script to the selected GameObject.

4. **Assign the Player Transform**

   - In the Inspector, find the `Player` field on the script component.
   - Drag your player GameObject (the one with the `Transform` you want to track) into this field.

5. **Customize (Optional)**

   - Adjust `Overlay Size`, `Overlay Offset`, and `Font Size` in the Inspector to fit your needs.

---

## 🕹️ Usage

- **Toggle Overlay:**  
  Press **F3** during Play mode to show or hide the overlay.

- **Move Overlay:**  
  Change the `Overlay Offset` values in the Inspector to move the overlay to a different screen corner.

---

## ⚙️ Script Reference

```csharp
public Transform player;        // Assign your player transform here
public Vector2 overlaySize;     // Size of the overlay box
public Vector2 overlayOffset;   // Offset from the top-right corner
public int fontSize;            // Font size for the overlay text
```

---

## 📝 Notes

- The overlay uses Unity's built-in `OnGUI` for simplicity.
- Works in both 2D and 3D projects.
- No external dependencies required.

---

## 📄 License

This project is licensed under the GNU General Public License v3.0.  
See the [LICENSE](LICENSE) file for details.

---

## 🙏 Credits

Created by Devanshu Sharma gi([emotional-push](https://github.com/emotional-push)).  
Inspired by coordinate overlays in popular sandbox games.

---

## 🆕 What's New in V2

- **Auto Player Detection:** If the `player` field is not set, the script will attempt to find a GameObject tagged as "Player" automatically.
- **Overlay Safety:** Overlay size and offset values are clamped to prevent negative or too-small values.
- **Error Overlay:** If the player is not assigned or found, a clear error message is displayed in the overlay.
- **Resource Cleanup:** The background texture is properly destroyed when the script is destroyed, preventing memory leaks.
- **Improved Visuals:** Uses Unity's rich text for bold labels and a more robust GUIStyle.
- **Code Robustness:** Defensive programming practices for more reliable use in any Unity project.

---

**Happy developing**