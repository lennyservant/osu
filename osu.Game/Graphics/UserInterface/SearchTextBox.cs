﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using OpenTK;
using OpenTK.Input;

namespace osu.Game.Graphics.UserInterface
{
    public class SearchTextBox : FocusedTextBox
    {
        protected virtual bool AllowCommit => false;

        public override bool HandleLeftRightArrows => false;

        public SearchTextBox()
        {
            Height = 35;
            AddRange(new Drawable[]
            {
                new SpriteIcon
                {
                    Icon = FontAwesome.fa_search,
                    Origin = Anchor.CentreRight,
                    Anchor = Anchor.CentreRight,
                    Margin = new MarginPadding { Right = 10 },
                    Size = new Vector2(20),
                }
            });

            PlaceholderText = "type to search";
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            var keyboard = e.CurrentState.Keyboard;
            if (!keyboard.ControlPressed && !keyboard.ShiftPressed)
            {
                switch (e.Key)
                {
                    case Key.Left:
                    case Key.Right:
                    case Key.Up:
                    case Key.Down:
                        return false;
                }
            }

            if (!AllowCommit)
            {
                switch (e.Key)
                {
                    case Key.KeypadEnter:
                    case Key.Enter:
                        return false;
                }
            }

            if (keyboard.ShiftPressed)
            {
                switch (e.Key)
                {
                    case Key.Delete:
                        return false;
                }
            }

            return base.OnKeyDown(e);
        }
    }
}
