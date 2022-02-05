﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Game : Form
    {
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();
        System.Media.SoundPlayer sp;
        public Game()
        {
            InitializeComponent();
            playMusic("tetris");
            loadCanvas();

            currentShape = getRandomShapeWithCenterAligned();
            nextShape = getNextShape();

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            this.KeyDown += Form1_KeyDown;
        }

        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        Pen pen = new Pen(Color.LightPink, 3);
        int canvasWidth = 20;
        int canvasHeight = 25;
        int[,] canvasDotArray;
        int dotSize = 20;
        private void loadCanvas()
        {
            // Resize the picture box based on the dotsize and canvas size
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            // Create Bitmap with picture box's size
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);

            canvasGraphics.FillRectangle(Brushes.Pink, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            // Load bitmap into picture box
            pictureBox1.Image = canvasBitmap;

            // Initialize canvas dot array. by default all elements are zero
            canvasDotArray = new int[canvasWidth, canvasHeight];
            drawLines();
        }
        private void drawLines()
        {
            for (int i = 0; i < canvasHeight; i++)
            {
                canvasGraphics.DrawLine(pen, 0, i * 20, 64 * 20, i * 20);
            }
            for (int i = 0; i < canvasWidth; i++)
            {
                canvasGraphics.DrawLine(pen, i * 20, 0, i * 20, 64 * 20);
            }
        }

        int currentX;
        int currentY;
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShape();

            // Calculate the x and y values as if the shape lies in the center
            currentX = 7;
            currentY = -shape.Height;

            return shape;
        }

        Bitmap workingBitmap;
        Graphics workingGraphics;
        private void Timer_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);
            // if shape reached bottom or touched any other shapes
            if (!isMoveSuccess)
            {
                // copy working image into canvas image
                canvasBitmap = new Bitmap(workingBitmap);

                updateCanvasDotArrayWithCurrentShape();
                // get next shape
                currentShape = nextShape;
                nextShape = getNextShape();

                clearFilledRowsAndUpdateScore();
                drawLines();
            }
        }

        private void updateCanvasDotArrayWithCurrentShape()
        {
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        if (checkIfGameOver()) { return; }
                        drawLines();
                        canvasDotArray[currentX + i, currentY + j] = 1;
                    }
                }
            }
        }

        private bool checkIfGameOver()
        {
            if (currentY < 0)
            {
                timer.Stop();
                sp.Stop();
                MessageBox.Show("Game Over");
                this.Close();
                return true;
            }
            return false;
        }

        // returns if it reaches the bottom or touches any other blocks
        private bool moveShapeIfPossible(int moveDown = 0, int moveSide = 0)
        {
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;

            // check if it reaches the bottom or side bar
            if (newX < 0 || newX + currentShape.Width > canvasWidth
                || newY + currentShape.Height > canvasHeight)
                return false;

            // check if it touches any other blocks 
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] == 1 && currentShape.Dots[j, i] == 1)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }
        private Brush getShapeColor(Shape shape)
        {
            if(shape.Id == 0)
            {
                return Brushes.Blue;
            } else if (shape.Id == 1)
            {
                return Brushes.Green;
            } else if(shape.Id == 2)
            {
                return Brushes.Purple;
            }
            else if (shape.Id == 3)
            {
                return Brushes.Yellow;
            }
            else if (shape.Id == 4)
            {
                return Brushes.DarkTurquoise;
            }
            else if (shape.Id == 5)
            {
                return Brushes.Red;
            }
            else
            {
                return Brushes.Orange;
            }
        }
        private void drawShape()
        {
            drawLines();
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);
            

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                        workingGraphics.FillRectangle(getShapeColor(currentShape), (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = workingBitmap;
            
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var verticalMove = 0;
            var horizontalMove = 0;

            // calculate the vertical and horizontal move values
            // based on the key pressed
            switch (e.KeyCode)
            {
                // move shape left
                case Keys.Left:
                    verticalMove--;
                    break;
                
                // move shape right
                case Keys.Right:
                    verticalMove++;
                    break;

                // move shape down faster
                case Keys.Down:
                    horizontalMove++;
                    break;
                case Keys.Space:
                    horizontalMove = canvasHeight-currentY-currentShape.Height;
                    break;

                // rotate the shape clockwise
                case Keys.Up:
                    currentShape.turn();
                    break;
                default:
                    return;
            }

            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            // if the player was trying to rotate the shape, but
            // that move was not possible - rollback the shape
            if (!isMoveSuccess && e.KeyCode == Keys.Up)
                currentShape.rollback();
        }

        int score;
        int indexMusic = 0;
        String[] arrMusic = new String[] {"tetris","tetrisFast","tetrisMetal","rock"};
        public void clearFilledRowsAndUpdateScore()
        {
            // check through each rows
            for (int i = 0; i < canvasHeight; i++)
            {
                int j;
                for (j = canvasWidth - 1; j >= 0; j--)
                {
                    if (canvasDotArray[j, i] == 0)
                        break;
                }

                if (j == -1)
                {
                    // update score and level values and labels
                    score+=10;
                    if(score/125 != indexMusic && score / 125 < 4)
                    {
                        indexMusic = score / 100;
                        sp.Stop();
                        playMusic(arrMusic[indexMusic]);

                    }
                    label1.Text = "Score: " + score;
                    label2.Text = "Level: " + score / 20;
                    // increase the speed 
                    if(timer.Interval - score <= 0)
                    {
                        timer.Interval = 1;
                    } else
                    {
                     timer.Interval -= 10;
                    }
                    

                    // update the dot array based on the check
                    for (j = 0; j < canvasWidth; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1];
                        }

                        canvasDotArray[j, 0] = 0;
                    }
                }
            }

            // Draw panel based on the updated array values
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.FillRectangle(
                        canvasDotArray[i, j] == 1 ? Brushes.Transparent : Brushes.Pink,
                        i * dotSize, j * dotSize, dotSize, dotSize
                        );
                }
            }

            pictureBox1.Image = canvasBitmap;
        }
        private void playMusic(String name) 
        {
            sp = new System.Media.SoundPlayer($@"..\..\src\{name}.wav");
            sp.PlayLooping();
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape()
        {
            var shape = getRandomShapeWithCenterAligned();
 
            // Codes to show the next shape in the side panel
            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);



            // Find the ideal position for the shape in the side panel
            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                    nextShapeGraphics.FillRectangle(
                        shape.Dots[i, j] == 1 ? Brushes.Black : Brushes.LightGray,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }
    }
}
