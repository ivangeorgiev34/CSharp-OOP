 using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public void Hero_ConstructorShouldWorkProperly()
    {
        Hero hero = new Hero("john", 10);

        Assert.AreEqual("john", hero.Name);
        Assert.AreEqual(10, hero.Level);
    }

    [Test]
    public void HeroRepository_ConstructorShouldWorkProperly()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.AreSame(heroRepository, heroRepository);
    }

    [Test]
    public void HeroRepository_MethodCreateShouldWorkProperly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("john", 10);
        string expectedResult = "Successfully added hero john with level 10";

        Assert.AreEqual(expectedResult, heroRepository.Create(hero));
    }

    [Test]
    public void HeroRepository_MethodCreateShouldThrowExceptionWhenHeroIsNull()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void HeroRepository_MethodCreateShouldThrowExceptionWhenHeroAlreadyExists()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("john",10);
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void HeroRepository_MethodRemoveShouldWorkProperly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("john", 10);
        heroRepository.Create(hero);

        bool expectedResult = true;

        Assert.AreEqual(expectedResult, heroRepository.Remove("john"));
    }

    [Test]
    [TestCase(null)]
    [TestCase(" ")]
    public void HeroRepository_MethodRemoveShouldThrowExceptionWhenNameIsNullOrWhiteSpace(string name)
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("john", 10);
        heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(name);
        });
    }

    [Test]
    public void HeroRepository_MethodGetHeroWithHighestLevelShouldWorkProperly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("john", 10);
        heroRepository.Create(hero);
        Hero hero2 = new Hero("john2", 11);
        heroRepository.Create(hero2);

        Assert.AreSame(hero2, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void HeroRepository_MethodGetHeroShouldWorkProperly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("john", 10);
        heroRepository.Create(hero);

        Assert.AreSame(hero, heroRepository.GetHero("john"));
    }
}