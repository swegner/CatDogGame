# CatDogGame
Implementations of a simple word game algorithm.

## The Problem
Given a pair of words, i.e. "CAT" and "DOG" determine whether it's possible to tranform
the first word into the second using a series of transformations. At each transformation 
step, you may swap a letter in the first word with any letter in the alphabet, with the 
constraint that each intermediate step must be a valid dictionary word. So for example,
"CAT" can be transformed to "COT", "DOT", and then "DOG"-- each step changes one letter
and is a valid word. "CAT" "DAT" "DOT" "DOG" does not work because "DAT" is not a word.
