# TicTacToe Minimax

This is a C# implementation of Tic Tac Toe game using Minimax algorithm with Alpha-Beta Pruning

<img src="Screenshots/TicTacToe.gif" width="300">

Minimax:
* We denote players as MIN and MAX
* Final state values are defined such that a positive value represents a win for player MAX and a negative value a win for player MIN; a tie is usually evaluated with 0
* Implementation is with recursive depth-first search of the game tree
* To evaluate the leaves we use heuristic estimation h(P) which reflects the quality of state P for player on the move
  * positive values signify advantage for player MAX and negative values signify advantage for player MIN
  * values ±∞ are used to denote a win for player MAX or MIN
  
* For heuristic calculation: 
  * if P is not a winning position for any player then h(P) = (number of rows, columns and diagonals still open for MAX) − (number of rows, columns and diagonals still open for MIN)
  * if P is a winning position for MAX then h(P) = ∞
  * if P is a winning position for MIN then h(P) = −∞

* Difficulity is basically the depth limit of the search tree. When the depth is equal to 8, the best outcome for a player is a draw since all the game states would be evaluated by the program. 

* Alpha-Beta Pruning is used as an extention to the Minimax algorithm to optimize it, since in some cases it is not necessary to explore the whole game tree.

