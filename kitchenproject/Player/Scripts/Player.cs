using Godot;

using System;
using System.Reflection.Metadata;
using System.Runtime.Serialization;

public partial class Player : CharacterBody2D
{
    [Export] public int move_speed = 100;

    public override void _PhysicsProcess(double delta)
    {
        
        Vector2 inputDirection = Vector2.Zero;

        if (Input.IsActionPressed("up"))
        {
            inputDirection.Y -= 1;
        }
        if (Input.IsActionPressed("down")){
            inputDirection.Y += 1;
        }
        if (Input.IsActionPressed("left")){
            inputDirection.X -= 1;
        }
        if (Input.IsActionPressed("right")){
            inputDirection.X += 1;
        }

        inputDirection = inputDirection.Normalized();

        Velocity = inputDirection * move_speed;
        MoveAndSlide();

    }

}
