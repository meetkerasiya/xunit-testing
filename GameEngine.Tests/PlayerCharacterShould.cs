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
    }
}