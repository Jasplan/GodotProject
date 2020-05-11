using Godot;
using System;

public class Player : KinematicBody2D
{
    
    public const float acceleration = 1000;

    public const float friction = 1000;
    private Vector2 velocity = Vector2.Zero;
    public const float maxSpeed = 200;

    public AnimationPlayer animator;
    public AnimationTree animatorTree;
    public Vector2 mousePos = Vector2.Zero;

    
    
    
    
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        animator = GetNode<AnimationPlayer>("Animation");
        animatorTree = GetNode<AnimationTree>("AnimationTree");
        
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta){
        Vector2 inputDirection = Vector2.Zero;
        Boolean inputMagnitude = false;

        mousePos = GetLocalMousePosition();

        



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
            
        }
        velocity = MoveAndSlide(velocity);

        animatorTree.Set("parameters/Run/blend_position", mousePos);
       
        
        
    }
}
