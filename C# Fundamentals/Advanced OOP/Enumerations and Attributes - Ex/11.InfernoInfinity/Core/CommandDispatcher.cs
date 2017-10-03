using System;
using System.Collections.Generic;
using System.Linq;
using InfernoInfinity.Core.Factories;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Models.Attributes;
using InfernoInfinity.Models.Weapons;

namespace InfernoInfinity.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly GemFactory gemFactory;
        private readonly InputHandler inHandler;
        private readonly OutputHandler outHandler;
        private readonly WeaponAttribute weaponAttribute;
        private readonly WeaponFactory weaponFactory;
        private readonly IList<IWeapon> weapons;

        public CommandDispatcher()
        {
            this.outHandler = new OutputHandler();
            this.weapons = new List<IWeapon>();
            this.inHandler = new InputHandler();
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
            this.weaponAttribute = (WeaponAttribute) typeof(Weapon).GetCustomAttributes(true).First();
        }

        public void ExecuteCommand(IList<string> tokens)
        {
            IWeapon currentWeapon = null;
            IBaseGem currentGem = null;

            var commandName = tokens[0];

            switch (commandName)
            {
                case "Create":
                    var weaponInfo = this.inHandler.SplitInput(tokens[1], " ");
                    weaponInfo.Add(tokens[2]);
                    this.weapons.Add(this.weaponFactory.Create(weaponInfo));
                    break;

                case "Add":
                    currentWeapon = GetWeapon(tokens[1]);
                    currentGem = this.gemFactory.Create(this.inHandler.SplitInput(tokens[3], " "));

                    currentWeapon.AddGem(int.Parse(tokens[2]), currentGem);
                    break;

                case "Remove":
                    currentWeapon = GetWeapon(tokens[1]);
                    currentWeapon.RemoveGem(int.Parse(tokens[2]));
                    break;

                case "Print":
                    currentWeapon = GetWeapon(tokens[1]);
                    this.outHandler.PrintLine(currentWeapon.ToString());
                    break;

                case "Author":
                    this.outHandler.PrintLine(this.weaponAttribute.PrintInfo("Author"));
                    break;

                case "Revision":
                    this.outHandler.PrintLine(this.weaponAttribute.PrintInfo("Revision"));
                    break;

                case "Description":
                    this.outHandler.PrintLine(this.weaponAttribute.PrintInfo("Description"));
                    break;

                case "Reviewers":
                    this.outHandler.PrintLine(this.weaponAttribute.PrintInfo("Reviewers"));
                    break;

                default:
                    throw new InvalidOperationException($"Command not available: {commandName}");
            }
        }

        private IWeapon GetWeapon(string weaponName)
        {
            return this.weapons.Where(w => w.WeaponName == weaponName).First();
        }
    }
}