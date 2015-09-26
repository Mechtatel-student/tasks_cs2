using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    enum CellStatus { 
        NotOpened = -1,
        Empty = 0, 
        /*don't change the order*/
        OneAround, TwoAround, ThreeAround, FourAround, FiveAround, SixAround, SevenAround, EightAround,
        HasMine = 100
    }

    interface IMinerGame
    {
        bool SetBomb(int row, int col);

        bool IsGameStarted { get; }

        void Start();

        bool Win { get; }
        bool Lose { get; }

        /// <summary>
        /// makes the cell opened
        /// </summary>
        /// <param name="row">row of field. Must be within field, numbered from 0 to Height-1</param>
        /// <param name="col">column of field. must be within field, numbered from 0 to Width-1</param>
        /// <returns>if indexes were good, returns true. if no cell with such coordinate exists, returns false</returns>
        bool OpenCell(int row, int col);

        /// <summary>
        /// retrieves status of the cell.
        /// If row and col are not within the field, method should throw IndexOutOfRange exception.
        /// </summary>
        /// <param name="row">row of field. Must be within field, numbered from 0 to Height-1</param>
        /// <param name="col">column of field. must be within field, numbered from 0 to Width-1</param>
        /// <returns>status of cell (not opened, empty, has mine, does not have mine but has some mines around)</returns>
        CellStatus this[int row, int col] { get; }




        int Width { get; }
        int Height { get; }
    }
}
