namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorretPower()
        {
            BossEnemy sut= new BossEnemy();

            Assert.Equal(166.667,sut.TotalSpecialAttackPower, 3); //precision of 3, but dong that might do round figuring
        }
    }
}
