using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public const float acceleration = 1000;

    public const float friction = 1000;
    private Vector2 velocity = Vector2.Zero;
    public const float maxSpeed = 200;

    public AnimationPlayer animator;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        animator = GetNode<AnimationPlayer>("Animation");

        
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta){
        Vector2 inputDirection = Vector2.Zero;
        Boolean inputMagnitude = false;
        
        inputDirection.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        inputDirection.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
        inputDirection = inputDirection.Normalized();
        if(inputDirection != Vector2.Zero){
            inputMagnitude = true;
        }else{
            inputMagnitude = false;
        }

        if(inputMagnitude){
            velocity = velocity.MoveToward(inputDirection * maxSpeed, acceleration * delta);
        }else{
            velocity = velocity.MoveToward(Vector2.Zero, friction * delta);
            animator.Play("IdleDown");
        }
        velocity = MoveAndSlide(velocity);
    }
}
