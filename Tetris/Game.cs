using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tetris
{

    public partial class Game : Form
    {
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();
        System.Media.SoundPlayer sp;
        public int score { get; set; }
        public char[] keysArr { get; set; }
        public Game(char[] keys)
        {
            keysArr = keys;
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
        Pen pen = new Pen(Color.Black, 3);
        int canvasWidth = 20;
        int canvasHeight = 25;
        int[,] canvasDotArray;
        int dotSize = 20;
        DateTime startTime = DateTime.Now;
        private void loadCanvas()
        {
            // Resize the picture box based on the dotsize and canvas size
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            // Create Bitmap with picture box's size
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);

            canvasGraphics.FillRectangle(Brushes.Pink , 0, 0, canvasBitmap.Width, canvasBitmap.Height);

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
            for (int i = 0; i < canvasWidth+1; i++)
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
            TimeSpan difference = DateTime.Now.Subtract(startTime);
            label2.Text = $"Timer : {difference.Minutes}:{difference.Seconds} sec";
            
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
                    if (currentShape.Dots[j, i] >= 1)
                    {
                        if (checkIfGameOver()) { return; }
                        drawLines();
                        canvasDotArray[currentX + i, currentY + j] = currentShape.Dots[j, i];
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
                Application.Restart();
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
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] >= 1 && currentShape.Dots[j, i] >= 1)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }
        private Brush getShapeColor(int id)
        {
            id -= 1;
            if (id == 0)
            {
                return Brushes.Blue;
            } else if (id == 1)
            {
                return Brushes.Green;
            } else if(id == 2)
            {
                return Brushes.Purple;
            }
            else if (id == 3)
            {
                return Brushes.Yellow;
            }
            else if (id == 4)
            {
                return Brushes.DarkTurquoise;
            }
            else if (id == 5)
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
                    if (currentShape.Dots[j, i] > 0)
                        workingGraphics.FillRectangle(getShapeColor(currentShape.Dots[j, i]), (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = workingBitmap;
            
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            var verticalMove = 0;
            var horizontalMove = 0;
            if ( (char)e.KeyCode == char.ToUpper(keysArr[0]))
            {
                verticalMove--;
            } else if ((char)e.KeyCode == char.ToUpper(keysArr[1])) 
            {
                verticalMove++;
            }
            else if ((char)e.KeyCode == char.ToUpper(keysArr[2]))
            {
                horizontalMove++;
            }
            else if ((char)e.KeyCode == char.ToUpper(keysArr[3]))
            {
                horizontalMove = canvasHeight - currentY - currentShape.Height;
            }
            else if ((char)e.KeyCode == char.ToUpper(keysArr[4]))
            {
                currentShape.turn();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                OptionInGame option = new OptionInGame(this);
                timer.Stop();
                option.ShowDialog();
                timer.Start();

            }
            else
            {
                return;
            }
            // calculate the vertical and horizontal move values
            // based on the key pressed

            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            // if the player was trying to rotate the shape, but
            // that move was not possible - rollback the shape
            if (!isMoveSuccess && e.KeyCode == Keys.Up)
                currentShape.rollback();
        }

        
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
                    updateScore();
                    // increase the speed 
                    

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
                        canvasDotArray[i, j] > 0 ? getShapeColor(canvasDotArray[i, j]) : Brushes.Pink,
                        i * dotSize, j * dotSize, dotSize, dotSize
                        );
                }
            }

            pictureBox1.Image = canvasBitmap;
        }

        public void updateScore()
        {
            if (score / 100 != indexMusic && score / 100 < 4)
            {
                indexMusic = score / 100;
                sp.Stop();
                playMusic(arrMusic[indexMusic]);

            }
            label1.Text = "Score: " + score;
            if (500 - score <= 0)
            {
                timer.Interval = 1;
            }
            else
            {
                timer.Interval = 500 - score;
            }
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
                        shape.Dots[i, j] >= 1 ? getShapeColor(shape.Dots[i, j]) : Brushes.Transparent,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

    }
}
