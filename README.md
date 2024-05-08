# ChessGame C#

A chess game developed by me with C# & WPF for the UI elements


## Special Features

- Checkmate / stalemate 
- Castling queen & king side
- Pawn promotion
- En pessant move


## xUnit Tests

During the process of developing this game, I did 12 tests on some of the core "helpers". 
I decided initially to not add the tests but now at the end I said why not so I did it :).


## Roadmap / Initial Plan

Here is the initial approach I had on the game when I first thought of it in the first 1-2 days:

- First I decided to handle the basic skeletons for pieces, positions on the board, initialise the board itself & create the board, all of these without a single UI element.

- Second would be the UI coming up where I try to implement the visual aspect of these basic things, the part where I add visually the board and pieces for each player

- Third, I decided to continue with the development of the normal functionalities of the game like moving the pieces, handling possible and not possible moves, generated moves etc. whilst also keeping the UI up to date with what I implemented on the way.

Seems easy right? NOPE it totally wasn't :).. Deffinitely one of the most challenging projects I've done so far. There were a lot of problems appearing on the way, weird bugs and things that I noticed I forgot while working so having a well structured plan became a priority.


## Plan on days of work

Here is the breakdown of the plan I had afterwards when I thought better at the game:

#### 1st Day (2-3 hours)

- Pretty chill day, did pieces & directions

- I said I'll also do some work on the player side (opponent, colors, turns etc.)

#### 2nd Day (about 6-7 hours)

- Here is where hell raised as I started working on pieces, board & game state skeletons

- Started working on the UI side of the proj.

- Everything went good until I started generating moves for special pieces

- Moves for pawns (This was TERRIFYING, that's why it has a chapter of it's own)

#### 3rd Day + 2nd day's night :D (<undefined> hours)

- More generation of moves

- Moves for Knight (This took longer to figure out than it should've, that's why it's here)

- Implemented highlights for moves

- Got a random idea of making special custom cursors for players so I spent about 2 hours on a tutorial on how to do so :)

#### 4th Day (again <undefined> hours but I'll say 6h)

- On this day I decided to handle checkmate and stalemate as most functionalities were already implemented 

- I started doing it and I realised I didn't previously handle check so I went back and did that first :)

- After this I did a game over menu with 2 buttons to restart or exit the game

#### 5th Day (maybe around 5 hours)

- I started with the pawn promotion logic, with a bit of thinking and sketching on a piece of paper before coding it

- Got the logic done and then I implemented it in the UI as a menu just like the game over one.

- This day I also said I will implement castling for both king & queen sides (This was actually not as difficult as I initially thought)

#### 6th Day (around 3 hours)

- Today I wanted to end the project but I remembered of the en pessant move so I started working on it.

- Got everything I needed working and implemented the move.

- Solved an issue where pawns could no longer perform a 1st 2 square move because of en pessant (secret: I forgot to execute the move)


## Authors

- [@Darius](https://github.com/RusuDarius)

