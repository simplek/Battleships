using NUnit.Framework;
using System.Linq;

namespace Battleships.Domain.Test
{
    [TestFixture]
    public class GameResetTests
    {
        [Test]
        public void A_reset_game_command_is_responded_to_with_an_event_that_updates_100_spaces()
        {
            const int standardGridSize = 10;
            const int numberOfPlayers = 2;

            var underTest = new BattleshipsGame(standardGridSize);
            var results = underTest.GetResetGameResults();

            Assert.That(results.GridUpdates.Count, Is.EqualTo((standardGridSize * standardGridSize) * numberOfPlayers));
        }

        [Test]
        public void A_reset_game_command_is_responded_to_with_an_event_that_updates_certain_spaces()
        {
            const int standardGridSize = 10;

            var underTest = new BattleshipsGame(standardGridSize);
            var results = underTest.GetResetGameResults();

            Assert.That(results.GridUpdates.Count(gu => gu.ColumnIndexToUpdate == 3 && gu.RowIndexToUpdate == 3), Is.EqualTo(1));
            Assert.That(results.GridUpdates.Count(gu => gu.ColumnIndexToUpdate == 5 && gu.RowIndexToUpdate == 5), Is.EqualTo(1));
            Assert.That(results.GridUpdates.Count(gu => gu.ColumnIndexToUpdate == 2 && gu.RowIndexToUpdate == 7), Is.EqualTo(1));
            Assert.That(results.GridUpdates.Count(gu => gu.ColumnIndexToUpdate == 7 && gu.RowIndexToUpdate == 2), Is.EqualTo(1));
        }

        [Test]
        public void A_reset_game_command_is_responded_to_with_an_event_that_has_a_relevant_summary_attached()
        {
            var underTest = new BattleshipsGame(10);
            var results = underTest.GetResetGameResults();

            Assert.That(results.Summary, Is.EqualTo("Game reset."));
        }
    }
}
