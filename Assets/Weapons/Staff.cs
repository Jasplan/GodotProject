using Godot;
using System;



public class Staff : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public AnimationPlayer animator;
    public AnimationTree animatorTree;

    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animator = GetNode<AnimationPlayer>("Animation");
        animatorTree = GetNode<AnimationTree>("AnimationTree");
        //animatorState = (AnimationNodeStateMachinePlayback)animatorTree.Get("parameters/playback");
        animatorTree.Active = true;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void animate(string animation){
        if(animation == "melee"){
            //AnimationPlayer
        }
    }
}
