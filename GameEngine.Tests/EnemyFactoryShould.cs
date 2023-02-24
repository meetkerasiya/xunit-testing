namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemybyDefault()
        {
            EnemyFactory sut=new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTupeExample()
        {
            EnemyFactory sut=new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            var sut=new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut=new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            BossEnemy boss=Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            EnemyFactory sut=new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert.IsType<Enemy>(enemy);
            //It fails cause it's strictly checking

            //if we want to check for inherited types then

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSaperateInstances()
        {
            var sut=new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
            //Assert.Same(enemy1, enemy2);

        }

        [Fact]
        public void NotAllowNullName()
        {
            var sut=new EnemyFactory();

            //To expect a null exception

            //Assert.Throws<ArgumentNullException>(()=>sut.Create(null));
            Assert.Throws<ArgumentNullException>("name",()=>sut.Create(null));
            
            //This test fails
           //Assert.Throws<ArgumentNullException>("isBoss",()=>sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            var sut=new EnemyFactory();

            EnemyCreationException ex=Assert.Throws<EnemyCreationException>(()=>sut.Create("Zombie",true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut=new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                ()=>sut.Sleep()); 
        }
    }
}
