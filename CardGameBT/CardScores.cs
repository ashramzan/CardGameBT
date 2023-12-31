﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameBT
{
    internal class CardScores
    {
        public int CalculateScore(string cardList)
        {
            // splits inputted values using a comma, and also replaces any empty space
            cardList = cardList.Replace(" ", "");
            string[] cards = cardList.Split(',');

            int jkCount = 0;

            // keep track of joker cards and only allow up to two

            foreach (string card in cards)
            {
                if (card == "JK")
                {
                    jkCount++;

                    if (jkCount > 2)
                        throw new InvalidOperationException("You can't have more than two jokers");
                }
                else
                {
                    if (cards.Length > 1 * cards.Distinct().Count())
                        throw new InvalidOperationException("You can't enter duplicate cards");
                }
            }

            int totalScore = 0;

            // seperate for loops for each card index 

            foreach (string card in cards)
            {
                int value;
                switch (card[0])
                {
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        value = int.Parse(card[0].ToString());
                        break;
                    case 'T':
                        value = 10;
                        break;
                    case 'J':
                        value = 11;
                        break;
                    case 'Q':
                        value = 12;
                        break;
                    case 'K':
                        value = 13;
                        break;
                    case 'A':
                        value = 14;
                        break;
                    default:
                        throw new InvalidOperationException("You entered an unrecognised card");
                }

                int multiplier;
                switch (card[1])
                {
                    case 'C':
                        multiplier = 1;
                        break;
                    case 'D':
                        multiplier = 2;
                        break;
                    case 'H':
                        multiplier = 3;
                        break;
                    case 'S':
                        multiplier = 4;
                        break;
                    case 'K':
                        multiplier = 0;
                        break;
                    default:
                        throw new InvalidOperationException("You entered an unrecognised card suit");
                }

                totalScore += value * multiplier;
            }

            // double value of the hand if there are any jokers present 

            if (cards.Contains("JK"))
            {
                totalScore *= 2;
            }

            return totalScore;
        }
    }
}

