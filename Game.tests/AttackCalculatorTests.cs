using System;
using Xunit;
using Game;

namespace Game.tests
{
    public class AttackCalculatorTests
    {
        [Fact]
        public void WhenAttackerDamageIsLessThanDefenderArmor_DamageIsZero()
        {
            // Arrange
            var attackCalculator = new AttackCalculator();

            // Act
            var attackCharacter = new Character(0, 0, "elf", 10);
            var defCharacter = new Character(20, 0, "elf", 0);
            int damage = attackCalculator.CalculateDamage(attackCharacter, defCharacter);

            // Assert
            Assert.Equal(0, damage);
        }

        [Fact]
        public void WhenAttackerDamageIsMoreOrEqualThanDefenderArmorAndDiceIs1_DamageIsZero()
        {
            // Arrange
            var attackCalculator = new AttackCalculatorMock(1);

            // Act
            var attackCharacter = new Character(0, 0, "elf", 30);
            var defCharacter = new Character(20, 0, "elf", 0);
            int damage = attackCalculator.CalculateDamage(attackCharacter, defCharacter);

            // Assert
            Assert.Equal(0, damage);
        }

        [Fact]
        public void WhenAttackerDamageIsMoreOrEqualThanDefenderArmorAndAttackIsNormal_DamageIsZero()
        {
            // Arrange
            int dice = 5;
            var attackCalculator = new AttackCalculatorMock(dice);

            // Act

            // Improvement: use a builder to only pass the relevant variables
            // Objective, keep the focus on the relevant stuff
            var attackCharacter = new Character(0, 25, "elf", 30);
            var defCharacter = new Character(20, 0, "elf", 0);
            int damage = attackCalculator.CalculateDamage(attackCharacter, defCharacter);

            // Assert
            Assert.Equal(25, damage);
        }


        // Alternative name can be WhenDamageIsCritical
        [Fact]
        public void WhenAttackerDamageIsMoreOrEqualThanDefenderArmorAndDiceIs20_DamageIsCritical()
        {
            // Arrange
            var attackCalculator = new AttackCalculatorMock(20);
            var weaponDamage = 50;
            var criticalDamage = weaponDamage * 2;
            var attackCharacter = new Character(30, weaponDamage, "elf", 10);
            var defCharacter = new Character(10, 0, "elf", 0);

            // Act
            int damage = attackCalculator.CalculateDamage(attackCharacter, defCharacter);

            // Assert
            Assert.Equal(criticalDamage, damage);
        }
    }
}