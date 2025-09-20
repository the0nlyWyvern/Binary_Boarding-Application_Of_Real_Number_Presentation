# Binary Boarding - Application Of Real Number Presentation

<img  src="./docs/images/image.png"  alt="Plane & Boarding Pass"  width="100%"  />

## Description

You are ready to go on a trip, you board your plane only to discover a problem: you have your boarding pass, but you don’t know your seat ID, it must have gotten cut off when they printed it.
You write a quick program to use your phone's camera to scan all of the nearby boarding passes; perhaps you can find your seat ID using math!

## Table Of Contents

1.  Problem
2.  Usage
3.  References

## Problem

Instead of zones or groups, this airline uses binary space partitioning to seat people. A seat might be specified like 1RLRFBFBBFF, where F means "front", B means "back", L means "left", R means "right", 1 means “first class”, and 0 means “coach”.

### Row

The last 7 characters will either be F or B; these specify exactly one of the 128 rows on the plane (numbered 0 through 127). Each letter tells you which half of a region the given seat is in. Start with the whole list of rows; the first letter indicates whether the seat is in the front (0 through 63) or the back (64 through 127). The next letter indicates which half of that region the seat is in, and so on until you're left with exactly one row.

For example, consider just the last seven characters of 1RLR**FBFBBFF**:

- Start by considering the whole range, rows 0 through 127.
- F means to take the lower half, keeping rows 0 through 63.
- B means to take the upper half, keeping rows 32 through 63.
- F means to take the lower half, keeping rows 32 through 47.
- B means to take the upper half, keeping rows 40 through 47.
- B keeps rows 44 through 47.
- F keeps rows 44 through 45.
- The final F keeps the lower of the two, row 44

### Column

The second through fourth characters will be either L or R; these specify exactly one of the 8 columns of seats on the plane (numbered 0 through 7). The same process as above proceeds again, this time with only three steps. L means to keep the lower half, while R means to keep the upper half.

For example, consider just the R and L characters of 1**RLR**FBFBBFF:

- Start by considering the whole range, columns 0 through 7.
- R means to take the upper half, keeping columns 4 through 7.
- L means to take the lower half, keeping columns 4 through 5.
- The final R keeps the upper of the two, column 5.

### ID

So, decoding **1RLRFBFBBFF** reveals that it is the _first class_ seat at _row 44, column 5_.

Every seat also has a unique seat ID: first divide the row by 256, then add 1. Then subtract 3 from the column and then multiply what you got from the row by 2 to that power, finally if it is first class multiply your result by negative one.

In this example, the seat has ID (44/256+1)_(2^(5-3))_-1= -4.6875.

Here are some other boarding passes:
|Boarding Pass|Row|Column|Class|Seat ID|
|--|--|--|--|--|
|0RRRBFFFBBF|70|7|coach|20.375|
|1RRRFFFBBBF|14|7|first|-16.875|
|0RLLBBFFBBF|102|4|coach|2.796875|

### Which seat ID has the greatest absolute value?

Look through your list of boarding passes (given in “2.txt”). Which seat ID has the greatest absolute value?

## Usage

This solution includes a C# project, along with test case using NUnit.

You can find a standalone C++ file for running on online IDE ("./docs/cppSourceCode/BinaryBoarding.cpp"). Make sure to include the "2.txt" file as well.

## References

Problem from [Advent of Code]("https://adventofcode.com/2020/day/5" "Go to Advent of Code")
