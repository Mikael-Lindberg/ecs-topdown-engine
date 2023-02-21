using System;
using System.Numerics;
using Raylib_cs;

public class Transform : Component {
    public Vector2 position;
    public float rotation;
    public Vector2 direction = new Vector2(0, -1);

    float angleRadians;
    float length = 1f;


    float timer = 0f;
    float interval = 0.5f;

    public Transform(float x, float y) {
        position = new Vector2(x, y);
    }

    public Transform() {
        position = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
    }

    public void Translate(Vector2 dir) {
        position += direction * Raylib.GetFrameTime() * 100;
    }

    public void Rotate(KeyboardKey key) {
        if (key == KeyboardKey.KEY_A)
            rotation -= Raylib.GetFrameTime() * 200;

        if (key == KeyboardKey.KEY_D)
            rotation += Raylib.GetFrameTime() * 200;

        // Console.WriteLine(rotation);

        if (rotation > 360) {
            rotation = rotation - 360;
        }
        if (rotation < 0) {
            rotation = rotation + 360;
        }
        angleRadians = (rotation - 90) * (float)Math.PI / 180f;
        float x = length * (float)Math.Cos(angleRadians);
        float y = length * (float)Math.Sin(angleRadians);
        direction = new Vector2(x, y);
    }
}