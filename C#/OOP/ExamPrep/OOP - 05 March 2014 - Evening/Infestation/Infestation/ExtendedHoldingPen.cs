using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;

namespace Infestation
{
    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            string supplement = commandWords[1];
            string unit = commandWords[2];
            if (this.GetUnit(unit) != null)
            {
                switch (supplement)
                {
                    case "AggressionCatalyst": this.GetUnit(unit).AddSupplement(new AggressionCatalyst());
                        break;
                    case "HealthCatalyst": this.GetUnit(unit).AddSupplement(new HealthCatalyst());
                        break;
                    case "PowerCatalyst": this.GetUnit(unit).AddSupplement(new PowerCatalyst());
                        break;
                    case "Weapon": this.GetUnit(unit).AddSupplement(new Weapon());
                        break;
                }
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            Unit targetUnit;
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                case InteractionType.Infest:
                    targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    base.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    base.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    base.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    base.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }
    }
}
