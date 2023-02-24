namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperienceWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter(); //system under test(sut)

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut=new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.StartsWith("Sarah", sut.FullName);

        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.EndsWith("Smith",sut.FullName);

        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "SARAH";
            sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", sut.FullName,ignoreCase: true);

        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Contains("ah Sm", sut.FullName);

        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut=new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100,sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0,sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

           // Assert.True(sut.Health>=100 && sut.Health<=200);
            Assert.InRange<int>(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
           // Assert.NotNull(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }
        
        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("staff of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, wepon => wepon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();
            var expectedWeapons = new []
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons);

        }

        [Fact]
        public void HaveNoExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
            //To check that no weapon is null
        }
    }
}