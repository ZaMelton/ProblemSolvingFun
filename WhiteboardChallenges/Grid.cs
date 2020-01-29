using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteboardChallenges
{
    class Grid
    {
        public int maxWidth;
        public int maxLength;

        public Grid(int maxWidth, int maxLength)
        {
            this.maxWidth = maxWidth;
            this.maxLength = maxLength;
        }

        public void PlaceRectanglesOnBoard(Rectangle rectangle, Rectangle rectangleTwo)
        {
            if (rectangle.length + rectangleTwo.length <= maxLength && rectangle.width + rectangleTwo.width <= maxWidth)
            {
                Console.WriteLine("Rectangles placed!");
            }
            else
            {
                Console.WriteLine("Placement failed. Those overlap!");
            }

        }
    }
}
