using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace MTM101BaldAPI.Components
{
    /// <summary>
    /// An <see cref="AnimatedSpriteRotator"/> except that all of it's serialized fields are exposed. For anyone who are tired of reflection or refuses to publicize the assembly code.
    /// </summary>
    public class PublicAnimatedSpriteRotator : AnimatedSpriteRotator
    {
        private static FieldInfo
            _renderer = AccessTools.DeclaredField(typeof(AnimatedSpriteRotator), "renderer"),
            _spriteMap = AccessTools.DeclaredField(typeof(AnimatedSpriteRotator), "spriteMap"),
            _bypassRotation = AccessTools.DeclaredField(typeof(AnimatedSpriteRotator), "bypassRotation");

        public SpriteRenderer renderer
        {
            get => (SpriteRenderer)_renderer.GetValue(this);
            set => _renderer.SetValue(this, value);
        }
        public SpriteRotationMap[] spriteMap
        {
            get => (SpriteRotationMap[])_spriteMap.GetValue(this);
            set => _spriteMap.SetValue(this, value);
        }
        public bool bypassRotation
        {
            get => (bool)_bypassRotation.GetValue(this);
            set => _bypassRotation.SetValue(this, value);
        }

        public PublicAnimatedSpriteRotator() : base()
        {
            spriteMap = new PublicSpriteRotationMap[0];
        }
    }
    /// <summary>
    /// An <see cref="SpriteRotationMap"/> except that all of it's serialized fields are exposed. For anyone who are tired of reflection or refuses to publicize the assembly code.
    /// </summary>
    public class PublicSpriteRotationMap : SpriteRotationMap
    {
        private static FieldInfo
            _spriteSheet = AccessTools.DeclaredField(typeof(SpriteRotationMap), "spriteSheet"),
            _overrideSpriteSheet = AccessTools.DeclaredField(typeof(SpriteRotationMap), "overrideSpriteSheet");

        public Sprite[] spriteSheet
        {
            get => (Sprite[])_spriteSheet.GetValue(this);
            set => _spriteSheet.SetValue(this, value);
        }
        public Sprite[] overrideSpriteSheet
        {
            get => (Sprite[])_overrideSpriteSheet.GetValue(this);
            set => _overrideSpriteSheet.SetValue(this, value);
        }
    }
}