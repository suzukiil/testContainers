public class IntegrationTests : BaseIntegrationTest
{
    public IntegrationTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Create_ShouldThrowArgumentException_WhenSkuIsInvalid()
    {
        var command = new CreateProductCommand("mydb", "123", "blabla");

        Task Action() => Sender.Send(command);
 
        await Assert.ThrowsAsync<ArgumentException>(Action);
    }

    [Fact]
    public async Task Create_ShouldAddProduct_WhenCommandIsValid()
    {
        var command = new CreateCommand("mydb", "123", "blabla");

        var PId = await Sender.Send(command);

        var person = DbContext.Person.FirstOrDefault(p => p.Id == new PId(pId));

        Assert.NotNull(person);
    }

    [Fact]
    public async Task GetById_ShouldReturnPerson_WhenPersonExists()
    {
        var command = new CreateCommand("mydb", "123", "blabla");
        var PId = await Sender.Send(command);
        var query = new GetPersonQuery(new PId(PId));

        var person = await Sender.Send(query);

        Assert.NotNull(person);
    }
}