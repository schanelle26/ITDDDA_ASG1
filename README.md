# ITD Hawker Explorer AR Food Discovery Experience

## Project Overview
This Unity project is an AR-based food discovery experience. Users scan physical food posters using AR image tracking. When a food model appears, users can tap it to:
- View food-related UI (info & ingredients)
- Track discovery progress using a progress bar
- Complete the experience after discovering all foods

The project currently features 3 local foods:
- Nasi Lemak
- Chicken Rice
- Noodles

---

## Walkthrough & Instructions

### How to Use and Run the Application
1. **Platform/Hardware Requirements:**
   - Unity 
   - AR-capable mobile device (iOS/Android) with camera
   - Printed food poster images for AR tracking
2. **Setup:**
   - Build and deploy the Unity project to your AR-capable device
   - Launch the app and grant camera permissions
3. **Controls:**
   - **Navigation:** Use on-screen buttons to move between Start, Instructions, and Explore screens
   - **AR Scene:** Point your device camera at the food posters
   - **Interaction:** Tap on the AR food models to view info and ingredients
   - **Progress:** Watch the progress bar fill as you discover each food
   - **Finish:** After all foods are found, tap the finish button to complete the experience
4. **Game Cheats/Hacks:**
   - There are no built-in cheats or hacks. For testing, you may simulate food discovery by tapping models multiple times, but duplicate discoveries are prevented.
5. **Answer Key/Solutions:**
   - To complete the experience, scan and tap all three food models: Nasi Lemak, Chicken Rice, and Noodles. The finish button will appear when all are found.

---

## Script Breakdown

### 1. FoodTargetHandler.cs
- Handles user interaction with AR food prefabs
- Detects taps, identifies food, notifies GameManager, triggers UI updates

### 2. GameManager.cs
- Tracks discovered foods, prevents duplicates, updates progress bar/text, shows finish button

### 3. ImageTracker.cs
- Listens for tracked image changes, spawns/attaches prefabs, manages prefab visibility

### 4. ProgressBar.cs
- Calculates and updates progress bar fill based on foods found

### 5. UIManager.cs
- Manages all UI screens and AR panels, handles navigation, displays food info, resets app state

---

## Platforms/Hardware Required
- Unity 2021.3+ with AR Foundation
- AR-capable iOS/Android device with camera
- Printed AR marker images (food posters)

---

## Limitations & Known Bugs
- Requires good lighting and clear AR markers for reliable tracking
- Only supports three specific food posters
- No persistent save; progress resets on app restart
- Occasional AR tracking loss if camera is moved too quickly
- UI may not scale perfectly on all device resolutions

---

## References & Credits
- **AR Foundation**: Unity's AR Foundation package
- **Food Models/Textures**:
  https://sketchfab.com/3d-models/food-delicious-nasi-lemak-4625dae3b0814c57bbc7ba24ce2bed95
  https://sketchfab.com/3d-models/prawn-noodles-scaniverse-lidar-fd3b216a1027470f9b78d210796b95ce
  https://sketchfab.com/3d-models/hainanese-chicken-rice-6a0d0aa3851849508f584248f96cd417
  
- **UI Icons/Graphics**:
- https://www.canva.com/
  

---

## Solutions (for Game Completion)
1. Scan the Nasi Lemak poster and tap the AR model
2. Scan the Chicken Rice poster and tap the AR model
3. Scan the Noodles poster and tap the AR model
4. Once all three are found, tap the finish button to complete the experience

---

## Summary
This project demonstrates:
- AR image tracking using Unity AR Foundation
- Interactive AR object selection
- UI state management
- Progress tracking and completion logic



