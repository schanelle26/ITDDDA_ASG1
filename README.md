# DDA Hawker Explorer AR Food Discovery Experience


This script connects your Unity project to Firebase Realtime Database and Firebase Authentication, providing a complete backend for food stall data, likes, and user comments, with real-time UI updates.

##  Documentation & Research

This project was developed to demonstrate real-time backend management for a food stall review system in Unity, leveraging Firebase for authentication and data storage. 
Research included: 
- https://www.nhb.gov.sg/
- https://spark.meta.com/blog/meta-spark-announcement/ (Authentication page)
- https://www.yelp.com/ (like/interactive buttons for each post)



- Firebase Unity SDK documentation
- Unity UI and TMP_Text integration
- Best practices for real-time database syncing
- User authentication flows in mobile apps

---

##  Content Displayed
- Authentication screens (sign up, log in)
- UI updates reflecting database changes instantly
- List of food stalls (name, like count)
- Real-time like counts for each stall
- User-submitted comments with user IDs

---

##  Application Purpose

This application caters to users who want to:

- Discover and review food stalls
- Like their favorite stalls
- Leave comments and feedback
- Sign up and log in securely
- Experience real-time updates and interaction

---

##  Wireframe / Game Flow

1. **Authentication Screen**
	- Sign up or log in
	- On success, navigate to main app
2. **Main Stall List**
	- Displays all stall names
	- Like buttons for each stall
	- real time like count text
3. **Comments Section**
	- Shows all comments for selected stall
	- Input field to add new comment
	- Send button to send comment 
	- Real-time updates after posting

---

##  External Assets / Libraries Used

- **Firebase Unity SDK**: For authentication and real-time database
- **TextMeshPro (TMP_Text)**: For advanced UI text rendering
- **Unity UI Toolkit**: For user interface elements

---

##  Original Artwork / Assets

- Chicken Rice https://skfb.ly/oOATu
- Nasi Lemak https://skfb.ly/osqoU
- Prawn Noodles https://skfb.ly/oEyTt
---

##  Authentication Manager

Handles Firebase user authentication in Unity:

-  Sign up with email & password
-  Log in with email & password
-  Prevents auth actions before Firebase is ready
-  Navigates UI after successful login/signup

### How it works

- Initializes Firebase and checks dependencies before allowing any auth actions.
- **SignUp**: Creates a new user account, logs the result, and navigates to the next screen on success.
- **LogIn**: Authenticates existing users, logs the result, and navigates to the next screen on success.
- Uses a UIManager to keep authentication logic separate from UI logic.
- Handles errors by blocking actions if Firebase isn’t ready and logging issues.

---

##  Database Manager

Manages food stall data, likes, and comments:

### Stall Creation

- `CreateStallData()`: Creates three stalls (TianChi Chicken Rice, Lemak House, Prawn King) with 0 likes each, stores them in Firebase, and initializes an empty comments node.

### Likes System

- `RetrieveLikes(stallId, TMP_Text)`: Reads and displays the like count for a stall.
- `IncrementLikes(stallId, TMP_Text)`: Increments the like count and updates Firebase and the UI.
- Button methods (`LikeStall1()`, `LikeStall2()`, `LikeStall3()`) are designed for Unity UI buttons.

### Comments System

- `SendComment()`: Gets the logged-in user’s ID, sends a comment to Firebase, clears the input, and refreshes the comments display.
- `RetrieveComments()`: Fetches and displays all comments, showing “No comments yet.” if empty, and auto-refreshes after new comments.

---

##  In One Sentence

This script creates stalls, handles likes, stores and retrieves user comments, and keeps the Unity UI synced with Firebase in real time.

---

##  Firebase Usage

- **Firebase Realtime Database**: Stores stalls, likes, and comments.
- **Firebase Authentication**: Identifies which user posted each comment.

---

##  Error Handling

- Prevents login/signup before Firebase is ready
- Detects and logs errors from Firebase tasks
- Avoids app crashes with basic error handling

---

##  Summary

This backend controller safely initializes Firebase, manages user authentication, creates and updates food stall data, handles likes and comments, and keeps your Unity UI in sync with Firebase—all with real-time updates and basic error detection.
