using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureFinancing
{
    class Program
    {
        private const string inputValues ="215\n"
                                      + "192 124\n"
                                    + "117 269 442\n"
                                  + "218 836 347 235\n"
                                + "320 805 522 417 345\n"
                              + "229 601 728 835 133 124\n"
                            + "248 202 277 433 207 263 257\n"
                          + "359 464 504 528 516 716 871 182\n"
                        + "461 441 426 656 863 560 380 171 923\n"
                      + "381 348 573 533 448 632 387 176 975 449\n"
                    + "223 711 445 645 245 543 931 532 937 541 444\n"
                  + "330 131 333 928 376 733 017 778 839 168 197 197\n"
                + "131 171 522 137 217 224 291 413 528 520 227 229 928\n"
              + "223 626 034 683 839 052 627 310 713 999 629 817 410 121\n"
            + "924 622 911 233 325 139 721 218 253 223 107 233 230 124 233\n";

        static void Main(string[] args)
        {
            PyramidBuilder builder = new PyramidBuilder(inputValues);
            builder.BuildIntScaffold();
            PyramidNode topNode = builder.BuildPyramid();
            Console.WriteLine("Max sum: " + (topNode.value + topNode.sumOfChildren));
            Console.WriteLine("Path: " + topNode.pathString);
            Console.ReadLine();
        }

    }
}
