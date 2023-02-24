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
    }
}