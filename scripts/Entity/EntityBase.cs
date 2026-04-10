using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

public partial class EntityBase : CharacterBody2D
{
    [Export] int Hp_max = 100;
    public int Hp { get{ return Hp; } set{ value = Hp_max; } }
    [Export] bool UsingDmgTable = false;
    [Export] bool Dieon0hp = false;
    [Export] bool Gravityenabled = true;  
    [Export] bool Infinite_inertia = true;
    [Export] float Invulnerable_Time = 0f;

    public override void _Ready()
    {
        int Ent_Hp = Hp;
        bool visible = false;

        Vector2 Velocity = Vector2.Zero;

        var Ent_sprite = GetNode<AnimatedSprite2D>("Sprite");
        var Visanotifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        var Collshape = GetNode<CollisionShape2D>("CollisionShape2D");
        var Animplayer = GetNode<AnimationPlayer>("AnimationPlayer");
        var Hurtbox = GetNode<CollisionShape2D>("CollisionShape2D");
        var Hurtcoll = GetNode<CollisionShape2D>("Hurtbox/CollisionShape2D");
        var I_frame_timer = GetNode<Timer>("I_frame_time");

        int DmgTable;
        int DmgResistence = 1;
        int LatestComboVal = -1;
        bool Snap = true;

        I_frame_timer.WaitTime = Invulnerable_Time;
    }

    public void Set_Hp(int value)
    {
        if (value != Hp)
        {
            Hp = (int)Math.Clamp(value,0,Hp_max);
        }
    }

    public int Get_Hp()
    {
        return Hp;
    }

    public override void Move()
    {
        Vector2 Snap_vector = (new(0,15)) ? _Ready.Snap: Vector2.Zero;
        velocity = 
    }
}

