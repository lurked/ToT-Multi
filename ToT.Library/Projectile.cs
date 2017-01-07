using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ToT.Library
{
    public class Projectile
    {
        public Vector2 Position { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Vector2 StartPosition { get; set; }
        public Vector2 TargetPosition { get; set; }
        public bool Active { get; set; }
        public Vector2 Movement { get; set; }
        public float BulletSpeed { get; set; }
        public float MaxDistance { get; set; }

        
        public Projectile()
        {
            BulletSpeed = 0.025f;
            Active = false;
            MaxDistance = 640;
        }

        public Projectile(Prop props)
        {
            Name = props.Name;
            Level = (int)props.Level;
            Active = false;
            BulletSpeed = 0.025f;
            MaxDistance = 640;
        }

        public void Init(Vector2 startPosition, Vector2 targetPosition)
        {
            Position = startPosition;
            StartPosition = startPosition;
            TargetPosition = targetPosition;

            Movement = TargetPosition - StartPosition;

            if (Movement != Vector2.Zero)
                Movement.Normalize();

            TargetPosition = StartPosition + (Movement * (MaxDistance / Vector2.Distance(StartPosition, TargetPosition)));
            Movement = TargetPosition - StartPosition;

            if (Movement != Vector2.Zero)
                Movement.Normalize();

            Active = true;
        }

        public void Update()
        {
            Position += Movement * BulletSpeed;            
        }

    }
}
