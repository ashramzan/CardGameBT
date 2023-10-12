using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameBT
{
    [TestFixture]
    internal class CardScoresTests
    {
        [Test]
        public void TestValidInput()
        {
            CardScores scorer = new CardScores();
            int score = scorer.CalculateScore("KC,AS,9D,4H,AH");
            Assert.AreEqual(141, score);
        }
        [Test]
        public void TestDuplicateCards()
        {
            CardScores scorer = new CardScores();
            Assert.Throws<InvalidOperationException>(() => scorer.CalculateScore("5C,3D,5C,AS,KS"));
        }
        [Test]
        public void TestInvalidCardValue()
        {
            CardScores scorer = new CardScores();
            Assert.Throws<InvalidOperationException>(() => scorer.CalculateScore("5X,3D,6H,AS,KS"));
        }
        [Test]
        public void TestJokerDuplicates()
        {
            CardScores scorer = new CardScores();
            Assert.Throws<InvalidOperationException>(() => scorer.CalculateScore("AH,KS,JK,4D,JK"));
        }
    }
}

