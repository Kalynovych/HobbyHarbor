using AutoFixture;

namespace HobbyHarbor.Tests
{
	public static class AutoFixtureExtensions
	{
		public static IFixture AllowCircularReference(this IFixture fixture)
		{
			fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
				.ForEach(b => fixture.Behaviors.Remove(b));
			fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			return fixture;
		}
	}
}
