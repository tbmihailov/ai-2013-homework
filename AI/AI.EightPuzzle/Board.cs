using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    public class Board
    {
        public Board(int[][] tiles)
        {
            this._tiles = tiles;
        }

        int[][] _tiles;
        public int[][] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        List<Board> _nextStates;
        public List<Board> GetNextStates()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hamming priority function. 
        /// The number of blocks in the wrong position, 
        /// plus the number of moves made so far to get to the state. Intutively, 
        /// a state with a small number of blocks in the wrong position is close 
        /// to the goal state, and we prefer a state that have been reached using 
        /// a small number of moves. 
        /// </summary>
        /// <returns>Number of blocks out of place</returns>
        public int GetHammingValue(Board goalState)
        {
            int hammingValue = 0;
            int size = Tiles.Length;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (Tiles[row][col] != 0 && Tiles[row][col] != goalState.Tiles[row][col])
                    {
                        hammingValue++;
                    }
                }
            }

            return hammingValue;
        }

        /// <summary>
        /// Manhattan priority function. 
        /// The sum of the distances (sum of the vertical and horizontal distance) 
        /// from the blocks to their goal positions, plus the number of moves made 
        /// so far to get to the state. 
        /// </summary>
        /// <returns>Sum of Manhattan distances between blocks and goal</returns>
        public int GetManhattanValue(Board goalState)
        {
            //int manhattanValue = 0;
            //int size = Tiles.Length;
            //for (int row = 0; row < size; row++)
            //{
            //    for (int col = 0; col < size; col++)
            //    {
            //        if (Tiles[row][col] != 0)
            //        {
            //            int val = Tiles[row][col];
            //            int valManhDistance = (val/size) 
            //        }
            //    }
            //}

            //return manhattanValue;

            throw new NotImplementedException();
        } 

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine("-------");
            print.AppendFormat("|{0} {1} {2}|\n", _tiles[0][0], _tiles[0][1], _tiles[0][2]);
            print.AppendFormat("|{0} {1} {2}|\n", _tiles[1][0], _tiles[1][1], _tiles[1][2]);
            print.AppendFormat("|{0} {1} {2}|\n", _tiles[2][0], _tiles[2][1], _tiles[2][2]);
            print.AppendLine("-------");

            return print.ToString();
        }

        public bool Equals(Board other)
        {
            for (int i = 0; i < Tiles.Length; i++)
            {
                for (int col = 0; col < Tiles[i].Length; col++)
                {
                    if (this.Tiles[i][col] != other.Tiles[i][col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
