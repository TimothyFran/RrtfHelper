using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgloManager_Main.Helpers;

public abstract class RtfHelper
{

    public static string GenerateRTFTable(string[][] dataArray, int cellWidth)
    {

        if(dataArray == null)
            throw new ArgumentNullException(nameof(dataArray), "Input data array cannot be null");

        int howManyRows = dataArray.Length;

        if(howManyRows < 0)
            throw new ArgumentException(nameof(dataArray), "Input data array must have at least one row");

        int howManyCols = dataArray[0].Length;

        if(howManyCols < 0)
            throw new ArgumentException(nameof(dataArray), "Input data array must have at least one column");

        StringBuilder rtfTable = new();

        // Start of the RTF text
        rtfTable.Append(@"{\rtf1\ansi\deff0");

        // Loop to populate cell data from dataArray
        for (int r = 0; r < howManyRows; r++)
        {

            // Start the row
            rtfTable.Append(@"\trowd");

            // Set cell width and position
            for (int c = 0; c < howManyCols; c++)
            {
                int thisCellWidth = (c + 1) * cellWidth;
                rtfTable.Append(@"\cellx" + thisCellWidth.ToString() + " ");
            }

            // Set cell content
            for (int c = 0; c < howManyCols; c++)
            {
                rtfTable.Append(dataArray[r][c] + @"\intbl\cell ");
            }

            // Insert data row
            rtfTable.Append(@"\row");

        }

        rtfTable.Append(@"}");

        return rtfTable.ToString();

    }

}
