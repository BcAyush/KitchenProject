using Godot;

using System;
using System.Collections;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

public partial class Player : CharacterBody2D
{
    //initializes variables
    [Export] public int move_speed = 100;
    private AnimationTree _animTree;
    private AnimationNodeStateMachinePlayback _stateMachine;

    //Initializes nodes
    public override void _Ready()
    {
        _animTree = GetNode<AnimationTree>("AnimationTree");
        _animTree.Active = true;

        _stateMachine = (AnimationNodeStateMachinePlayback)_animTree.Get("parameters/playback");
    }

    public override void _PhysicsProcess(double delta)
    {
        //initializes input direction
        Vector2 inputDirection = Vector2.Zero;

        //determines which direction to move the character
        if (Input.IsActionPressed("up"))
        {
            inputDirection.Y -= 1;
        }
        else if (Input.IsActionPressed("down")){
            inputDirection.Y += 1;
        }
        else if (Input.IsActionPressed("left")){
            inputDirection.X -= 1;
        }
        else if (Input.IsActionPressed("right")){
            inputDirection.X += 1;
        }

        //inputDirection = inputDirection.Normalized();

        // switch((Input.IsActionPressed("up"), Input.IsActionPressed("down"), Input.IsActionPressed("left"), Input.IsActionPressed("right")))
        // {
        //     case(true, false, false, false):
        //         inputDirection.Y -= 1;
        //         break;
        //     case(false, true, false, false):
        //         inputDirection.Y += 1;
        //         break;
        //     case(false, false, true, false):
        //         inputDirection.X -= 1;
        //         break;
        //     case(false, false, false, true):
        //         inputDirection.X += 1;
        //         break;

        // }



        Velocity = inputDirection * move_speed;
        if(inputDirection != Vector2.Zero)
        {
            _stateMachine.Travel("Walk");
            _animTree.Set("parameters/Walk/blend_position", inputDirection);
            _animTree.Set("parameters/Idle/blend_position", inputDirection);
        }
        else
        {
            _stateMachine.Travel("Idle");

        }

        MoveAndSlide();

    }

}
