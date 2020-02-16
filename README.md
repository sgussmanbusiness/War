# War
 A Windows console-application version of the classic card game.
The rules are simple: the player and the CPU-opponent each draw a card from a shared 52-card deck (without replacement) for 26 rounds and the player with the larger numbered card wins, adding both cards into their inventory (with Joker being treated as a 0 card, King being treated as a 10 card, Queen being treated as an 11 card, and Ace being treated as a 12 card).  If there is a draw, WAR is declared and each subsequent round until there is a winner has higher stakes: all of the cards at play in the previous rounds which ended in draw are won.  If the WAR ends in a stalemate (attrition of all cards with a draw to the very end), no one is awarded those cards at play. [1]
NOTE: The relative numbered values of cards are used only to determine the winner of a round; each card is worth one point when it comes to scoring.

# Build
The user can build the game from the repo, or alternatively just run the pre-built War.exe exeutable located in War\bin\Release\netcoreapp3.1\ (make sure to download at least the entire netcoreapp3.1 folder).

# Sources
1: I brushed up on the rules of the game at https://en.wikipedia.org/wiki/War_(card_game)'s "Gameplay" section which itself cites "Rules of card games: War" (at pagat.com).
