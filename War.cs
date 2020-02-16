/* Steven Gussman    2/15/20 1:04 PM (SAT)    Plas.md @ 1776    War.cs is a console-app video game version of the classic
 *                                                              card game. */

using System;

namespace War{
    class War{
        static void Main(string[] args){
            int numRounds = 26;
            Console.WriteLine("Get ready for " + numRounds + " rounds of War!");

            // Create the deck
            int[] deck = new int[52];
            for(int i = 0; i < deck.Length; i++){
                // % 13 to account for four suites (52 / 4 = 13) of each valued-card
                deck[i] = i % 13;
            }
            // Parallel array of dirty bits so that cards drawn without replacement
            bool[] dirtyDeck = new bool[52];

            // Iterate for the correct number of rounds
            int playerWinnings = 0;
            // Keep track of the CPU's wins as well to avoid draws being assigned as wins or losses to someone
            int cPUWinningss = 0;
            Random rando = new Random();
            int j = 0;
            int numCardsAtStake = 2;
            while(j < numRounds){
                // Round i
                // CPU draws a card
                // Draw a random card from the deck (cards 1-9, Joker = 0, King = 10, Queen = 11, and Ace = 12)
                int cPUCardIndex = -1;
                // Draw until getting a card that has not already been in play
                while(cPUCardIndex == -1 || dirtyDeck[cPUCardIndex]){
                    // The argumens are [0, 52) because the lower bound is inclusive, while the upper bound is exclusive
                    cPUCardIndex = rando.Next(0, 52);
                }
                // Remove the chosen card from future play
                dirtyDeck[cPUCardIndex] = true;

                // Player draw's a card
                Console.WriteLine("Press [ENTER] to draw a card...");
                Console.ReadLine();
                int playerCardIndex = -1;
                // Draw until getting a card that has not already been in play
                while(playerCardIndex == -1 || dirtyDeck[playerCardIndex]){
                    // The argumens are [0, 52) because the lower bound is inclusive, while the upper bound is exclusive
                    playerCardIndex = rando.Next(0, 52);
                }
                // Remove the chosen card from future play
                dirtyDeck[playerCardIndex] = true;

                // Round results
                string cPUCardName = "";
                // Joker
                if(deck[cPUCardIndex] == 0){
                    cPUCardName = "a Joker";

                // Numerical cards
                }else if(deck[cPUCardIndex] >= 1 && deck[cPUCardIndex] <= 9){
                    cPUCardName = deck[cPUCardIndex].ToString();

                // King
                }else if(deck[cPUCardIndex] == 10){
                    cPUCardName = "a King";

                // Queen
                }else if(deck[cPUCardIndex] == 11){
                    cPUCardName = "a Queen";

                // Ace
                }else{
                    cPUCardName = "an Ace";
                }
                string playerCardName = "";
                // Joker
                if(deck[playerCardIndex] == 0){
                    playerCardName = "a Joker";

                // Numerical cards
                }else if(deck[playerCardIndex] >= 1 && deck[playerCardIndex] <= 9){
                    playerCardName = deck[playerCardIndex].ToString();

                // King
                }else if(deck[playerCardIndex] == 10){
                    playerCardName = "a King";

                // Queen
                }else if(deck[playerCardIndex] == 11){
                    playerCardName = "a Queen";

                // Ace
                }else{
                    playerCardName = "an Ace";
                }

                Console.WriteLine("You drew " + playerCardName + ", and your opponent drew " +
                 cPUCardName + "...");

                // Draw--the winner of the next round wins both (or all, depending on how many draws occur in a row) rounds
                if(deck[playerCardIndex] == deck[cPUCardIndex]){
                    Console.WriteLine("Round " + (j + 1) + " is a draw.  This means war!");
                    // Move to the next round with higher stakes
                    numCardsAtStake += 2;
                    j++;
                    // The game could end here by running out of cards during continual draws
                    if(j == numRounds){
                        // We will handle this unfortunate scenario by no one winning those cards on the table
                        Console.WriteLine("The WAR ended in a stalemate.  No cards awarded to either side.");
                        break;
                    }else{
                        continue;
                    }

                // Win
                }else if(deck[playerCardIndex] > deck[cPUCardIndex]){
                    // Normal win
                    if(numCardsAtStake <= 2){
                        Console.WriteLine("You win round " + (j + 1) + ", earning " + numCardsAtStake + " cards!");
                    
                    // War win
                    }else{
                        Console.WriteLine("You win the WAR at round " + (j + 1) + ", earning " + numCardsAtStake + " cards!");
                    }
                    playerWinnings += numCardsAtStake;
                    // Reset the number of cards at stake in case of this being the end of Draw-WAR
                    numCardsAtStake = 2;
                // Loss
                }else{
                    // Normal loss
                    if(numCardsAtStake <= 2){
                        Console.WriteLine("You lost round " + (j + 1) + ", your opponent earned "
                         + numCardsAtStake + " cards.");
                    
                    // War round
                    }else{
                        Console.WriteLine("You lost the WAR at round " + (j + 1) + ", your opponent earned "
                         + numCardsAtStake + " cards.");
                    }

                    cPUWinningss += numCardsAtStake;
                    // Reset the number of cards at stake in case of this being the end of Draw-WAR
                    numCardsAtStake = 2;
                }

                j++;
            }

            // Reveal the overall results of the game
            // Draw
            if(playerWinnings == cPUWinningss)
                Console.WriteLine("\nThe game is a draw, " + playerWinnings + " to " + cPUWinningss + ".\n\nGAME OVER");

            // Player wins
            else if(playerWinnings > cPUWinningss)
                Console.WriteLine("\nYou win the game, " + playerWinnings + " to " + cPUWinningss + ".\n\nGAME OVER");

            // CPU wins
            else
                Console.WriteLine("\nYou lose, " + cPUWinningss + " to " + playerWinnings + ".\n\nGAME OVER");
        }
    }
}
