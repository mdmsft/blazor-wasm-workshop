public class UserService
{
    public ValueTask<ICollection<User>> GetUsersAsync(int index) =>
        ValueTask.FromResult<ICollection<User>>(Enumerable.Range(index, 250).Select(_ => new User(Faker.Name.FullName(), $"{Faker.Address.StreetAddress()}, {Faker.Address.ZipCode()} {Faker.Address.City()}, {Faker.Address.Country()}", Faker.Phone.Number())).ToList());
}