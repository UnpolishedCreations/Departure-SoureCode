#pragma strict


// Displays scores.
function OnGUI () {
    // Player 1 Score
    GUI.Label (Rect(Screen.width/4, 5, 100, 20), "Player 1: ");
    GUI.Label (Rect ((Screen.width/4) + 55, 5, 100, 20), "" + ControlKingArea.p1Time);
    
    // Player 2 Score
    GUI.Label (Rect (Screen.width/2, 5, 100, 20), "Player 2: ");
    GUI.Label (Rect ((Screen.width/2) + 55, 5, 100, 20), "" + ControlKingArea.p2Time);

}
