# Simon_Says

Simon Says game as console app developed by Tyler Thompson. 

Game starts with splash screen. Then asks player how many arrows to memorize. It flashes that number of arrows with their associated colors on screen and places them into an array. Then asks the player to type back those arrows on the keyboard in that same order and places the user input arrows into a seperate array. Then compares both array and if all items aren't identical, will either display a win or lose screen. I put a couple safty checks in place such as when the play types in the number to memorize, it must be a number greater than zero. Also when player is typing arrows, skips adding the item to the array if it's not an arrow key. When the game has finished, the user presses any key to play again or Escape key to quit.
