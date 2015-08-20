﻿namespace DwarfWarrior.Core.Interfaces
{
    using System;

    public interface IGameController
    {
        event EventHandler OnUpPressed;

        event EventHandler OnDownPressed;

        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        event EventHandler OnEnterPressed;

        void UserInput();
    }
}