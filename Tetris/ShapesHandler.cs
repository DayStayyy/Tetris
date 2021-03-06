using System;

namespace Tetris
{
    static class ShapesHandler
    {
        private static Shape[] shapesArray;
        
        // static constructor : No need to manually initialize
        static ShapesHandler()
        {
            // Create shapes add into the array.
            shapesArray = new Shape[]
                {
                    new Shape {
                        Id = 0,
                        Width = 2,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 1 },
                            { 1, 1 }
                        }
                    },
                    new Shape {
                        Id = 1,
                        Width = 1,
                        Height = 4,
                        Dots = new int[,]
                        {
                            { 2 },
                            { 2 },
                            { 2 },
                            { 2 }
                        }
                    },
                    new Shape {
                        Id = 2,
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 3, 0 },
                            { 3, 3, 3 }
                        }
                    },
                    new Shape {
                        Id = 3,
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 0, 4 },
                            { 4, 4, 4 }
                        }
                    },
                    new Shape {
                        Id = 4,
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 5, 0, 0 },
                            { 5, 5, 5 }
                        }
                    },
                    new Shape {
                        Id = 5,
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 6, 6, 0 },
                            { 0, 6, 6 }
                        }
                    },
                    new Shape {
                        Id = 6,
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 7, 7 },
                            { 7, 7, 0 }
                        }
                    }
                };
        }
        
        // Get a shape form the array in a random basis
        public static Shape GetRandomShape()
        {
            var shape = shapesArray[new Random().Next(shapesArray.Length)];

            return shape;
        }
    }
}
