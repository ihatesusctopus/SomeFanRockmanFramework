using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

public partial class EntityBase : CharacterBody2D
{
    [Export] int Hp_max = 100;
    private int Hp { get => Hp_max; set {if (value != Hp_max){ Hp_max = Math.Clamp(value,0,Hp_max);}} }
    [Export] bool UsingDmgTable = false;
    [Export] bool Dieon0hp = false;
    [Export] bool Gravityenabled = true;  
    [Export] bool Infinite_inertia = true;
    [Export] float Invulnerable_Time = 0f;
    
    Godot.Vector2 Velocity = Godot.Vector2.Zero; 
    bool Visible = false;
    int DmgTable;
    int DmgResistence = 1;
    int LatestComboVal = -1;
    bool Snap = true;

    public override void _Ready()
    {
        var Ent_Hp = Hp; 
        var Ent_sprite = GetNode<AnimatedSprite2D>("Sprite");
        var Visanotifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        var Collshape = GetNode<CollisionShape2D>("CollisionShape2D");
        var Animplayer = GetNode<AnimationPlayer>("AnimationPlayer");
        var Hurtbox = GetNode<CollisionShape2D>("CollisionShape2D");
        var Hurtcoll = GetNode<CollisionShape2D>("Hurtbox/CollisionShape2D");
        var I_frame_timer = GetNode<Timer>("I_frame_time");
        
        I_frame_timer.WaitTime = Invulnerable_Time;
    }

    public override void _Process(double delta) 
    {
        var SnapVector = Convert.ToBoolean(new Godot.Vector2(0,15)) ? Snap : Convert.ToBoolean(Godot.Vector2.Zero);
        var velocity = Convert.ToBoolean(Velocity);
        velocity = MoveAndSlide();
    }

    public void SnapToGround(float RayLenght)
    {
        var SpaceState = GetWorld2D().DirectSpaceState;
        //the first globalPosition is a 0,0 the other 2 are 0s in their own Axis 
        //var query = PhysicsRayQueryParameters2D.Create(GlobalPosition, new Godot.Vector2(GlobalPosition.X, GlobalPosition.Y + RayLenght), this, CollisionMask);
        var ResultPos = SpaceState.IntersectRay(query);

        if (Convert.ToBoolean(ResultPos))
        {
            // GlobalPosition.Y = ResultPos.Position.Y
            // return ResultPos;
        }
    }
}

