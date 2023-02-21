using Raylib_cs;
using System.Numerics;

public class Program {
    static void Main(string[] args) {
        Raylib.InitWindow(800, 600, "My Game");
        Raylib.SetTargetFPS(60);

        Scene scene = new Scene();

        GameObject go = new GameObject(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

        GameObject gameObject = new GameObject(10, 10);


        scene.AddGameObject(go);
        scene.AddGameObject(gameObject);

        while (!Raylib.WindowShouldClose()) {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.WHITE);

            scene.Update();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}