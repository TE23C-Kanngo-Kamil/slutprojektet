using System.Numerics;
using Raylib_cs;

/* 

    Mål:
    - Rymdskepp (spelaren) som kan röras med piltangenterna
    - Fiender som kommer fram från toppen av skärmen
    - System där man kan skjuta fienderna med mellanslag

*/

// Skärmdimensioner
const int screenWidth = 800;
const int screenHeight = 1000;

// Starta spelets fönster
Raylib.InitWindow(screenWidth, screenHeight, "Space Invaders");
Raylib.SetTargetFPS(60);

// Spelarens startposition och hastighet
Vector2 playerPosition = new Vector2(screenWidth / 2, screenHeight - 100);
float playerSpeed = 5.0f;

while (Raylib.WindowShouldClose() == false)
{
    // --- Hantera spelarens rörelse ---
    // Om vänsterpil är nedtryckt och spelaren inte är vid vänstra kanten:
    //     Flytta spelaren åt vänster
    // Om högerpil är nedtryckt och spelaren inte är vid högra kanten:
    //     Flytta spelaren åt höger
    // Om uppåtpil är nedtryckt och spelaren inte är vid övre kanten:
    //     Flytta spelaren uppåt
    // Om nedåtpil är nedtryckt och spelaren inte är vid nedre kanten:
    //     Flytta spelaren nedåt

    if (Raylib.IsKeyDown(KeyboardKey.Left) && playerPosition.X > 0)
    {
        playerPosition.X -= playerSpeed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Right) && playerPosition.X < screenWidth - 50)
    {
        playerPosition.X += playerSpeed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Up) && playerPosition.Y > 0)
    {
        playerPosition.Y -= playerSpeed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Down) && playerPosition.Y < screenHeight - 50)
    {
        playerPosition.Y += playerSpeed;
    }

    // --- Rita spelet ---
    // Börja rita skärmen
    // Rensa bakgrunden (svart)
    // Rita spelaren som en grön triangel vid startposition
    // Avsluta ritningen

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    Raylib.DrawTriangle(
        new Vector2(playerPosition.X, playerPosition.Y - 20),
        new Vector2(playerPosition.X - 20, playerPosition.Y + 20),
        new Vector2(playerPosition.X + 20, playerPosition.Y + 20),
        Color.Green
    );

    Raylib.EndDrawing();
}