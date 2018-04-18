using System;

namespace Inertia
{
    internal class Program
    {
        public static void Main()
        {
            string[] matrix =
            {
                    "#%%%%%%%%%%########", 
                    "#          #      #", 
                    "#          #      #", 
                    "#          #      #", 
                    "#$    &    #$     #", 
                    "#.  . .    ##     #", 
                    "#  %       %#     #",  
                    "#  %              #", 
                    "#  %$        $    #", 
                    "#  ################",
                    "#   $             #", 
                    "################# #", 
                    "#       $         #", 
                    "# #################", 
                    "#            $    #", 
                    "###################" 
            };

            Game level01 = new Game(matrix);
            level01.Start();
        }
    }
}