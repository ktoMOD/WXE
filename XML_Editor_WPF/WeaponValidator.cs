using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor_WPF
{
    public class WeaponValidator: AbstractValidator<Weapon>
    {
        public WeaponValidator()
        {
            //RuleFor(x => x.Class).NotEmpty();
            RuleFor(weapon => weapon.Class).NotEmpty();
            RuleFor(weapon => weapon.Name).NotEmpty();
            RuleFor(weapon => weapon.ModelFile).NotEmpty();
            RuleFor(weapon => weapon.ResourceType).NotEmpty();
            RuleFor(weapon => weapon.NodeScale).NotEmpty();
            RuleFor(weapon => weapon.Mass).NotEmpty();
            RuleFor(weapon => weapon.BulletPrototype).NotEmpty();
            RuleFor(weapon => weapon.ExplosionType).NotEmpty();
            RuleFor(weapon => weapon.Damage).NotEmpty();
            RuleFor(weapon => weapon.FiringRate).NotEmpty();
            RuleFor(weapon => weapon.GroupingAngle).NotEmpty();
            RuleFor(weapon => weapon.FiringRange).NotEmpty();
            RuleFor(weapon => weapon.RecoilForce).NotEmpty();
            RuleFor(weapon => weapon.FiringType).NotEmpty();
            RuleFor(weapon => weapon.Price).NotEmpty();
            RuleFor(weapon => weapon.Decal).NotEmpty();
            RuleFor(weapon => weapon.ChargeSize).NotEmpty();
            RuleFor(weapon => weapon.RechargingTime).NotEmpty();
            RuleFor(weapon => weapon.Durability).NotEmpty();
        }
    }
}
