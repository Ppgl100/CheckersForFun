using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersForFun
{
    public partial class Form1 : Form
    {
        public Button currentPiece = null;
        public bool nextMovePossible = false;
        public Panel leftJump = null;
        public Panel rightJump = null;
        public string leftPanel = "";
        public string rightPanel = "";
        public string myJumpLeft = "";
        public string myJumpRight = "";
        int myEnemyCounter = 12;
        int myCounter = 12;
        public Form1()
        {
            InitializeComponent(); 
            initializePanels();
        }

        private void initializePanels()
        {
            foreach(Control c in myField.Controls)
            {
                if(c is Panel && c.BackColor == Color.LightCoral)
                {
                    Panel p = (Panel)c;
                    p.Click += movePiece;
                }
            }
        }

        private void movePiece(object sender, EventArgs e)
        {
            if (currentPiece != null)
            {
                moveToNewPos((Panel)sender, currentPiece);
                nextMovePossible = true;
                myMoves(currentPiece);
                currentPiece = null;
                leftJump = null;
                rightJump = null;
            }
        }
        private void endMyTurn()
        {
            if(myEnemyCounter ==0)
            {
                MessageBox.Show("You won the game.");
                return;
            }
            bool turnFinished = false;
            this.opponentLabel.Visible = true;
            this.myLabel.Visible = false;
            foreach (Control c in myField.Controls)
            {
                foreach (Control c2 in c.Controls)
                {
                    if (c2 is Button && c2.BackColor == Color.Gold)
                    {
                        c2.Enabled = false;
                    }
                }
            }
            int i = 0;
            while (!turnFinished)
            {
                if (i==1)
                {             
                    endMyTurn();
                    break;
                }
                i++;
                foreach (Control c in myField.Controls)
                {
                    foreach (Control c3 in c.Controls)
                    {
                        if (c3.BackColor == Color.Brown)
                        {
                            enemyMoves((Button)c3);
                            List<Panel> pList = new List<Panel>();
                            foreach (Control c2 in myField.Controls)
                            {
                                if (c2 is Panel && c2.BackColor == Color.Blue)
                                {
                                    pList.Add((Panel)c2);
                                    /*if (pList.Count >= 1)
                                    {
                                        break;
                                    }*/
                                }
                            }

                            if (pList.Count >= 1)
                            {
                                var rand = new Random();
                                int rng = rand.Next(0, 20);
                                if (rng < 11)
                                {
                                    moveEnemyToNewPos(pList[0], (Button)c3);
                                    turnFinished = true;
                                }
                                else
                                {
                                    if (pList.Count >1)
                                    {
                                        moveEnemyToNewPos(pList[1], (Button)c3);
                                        turnFinished = true;
                                    }
                                }
                                if(turnFinished)
                                {
                                    resetColors();
                                    break;
                                    //return;
                                    //startMyTurn();
                                }
                                
                            }
                        }
                    }
                    if (turnFinished)
                    {
                        break;
                    }
                }
            }
        }

        private void startMyTurn()
        {
            if (myCounter == 0)
            {
                MessageBox.Show("You lost the game.");
                return;
            }
            resetColors();
            this.myLabel.Visible = true;
            this.opponentLabel.Visible = false;
            foreach (Control c in myField.Controls)
            {
                foreach (Control c2 in c.Controls)
                {
                    if (c2 is Button && c2.BackColor == Color.Gold)
                    {
                        c2.Enabled = true;
                    }
                }
            }      
        }
        private void chooseTurn()
        {
            var random = new Random();
            int randomTurn = random.Next(0, 10);
            if (randomTurn < 6)
            {                
                endMyTurn();            
            }
            else
            {               
                startMyTurn();
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mp1_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp2_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp3_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp4_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp5_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp6_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp7_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp8_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp9_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp10_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp11_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }

        private void mp12_Click(object sender, EventArgs e)
        {
            myMoves((Button)sender);
        }
        
        private void resetColors()
        {
            foreach(Control c in myField.Controls)
            {
                if(c is Panel)
                {
                    if(c.Name.Contains("A"))
                    {
                        int number = Int32.Parse(""+c.Name[1]);
                        if(number %2 ==1)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                    if (c.Name.Contains("B"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 0)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                    if (c.Name.Contains("C"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 1)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                    if (c.Name.Contains("D"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 0)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }
                    if (c.Name.Contains("E"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 1)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                    if (c.Name.Contains("F"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 0)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                    if (c.Name.Contains("G"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 1)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                    if (c.Name.Contains("H"))
                    {
                        int number = Int32.Parse("" + c.Name[1]);
                        if (number % 2 == 0)
                        {
                            c.BackColor = Color.White;
                        }
                        else
                        {
                            c.BackColor = Color.LightCoral;
                        }
                    }

                }
            }
        }

        private void moveEnemyToNewPos(Panel p, Button b)
        {
            if (p.BackColor == Color.Blue)
            {
                p.Controls.Add(b);
                if (leftJump != null && myJumpLeft == p.Name)
                {
                    foreach (Control c in myField.Controls)
                    {
                        if (c is Panel)
                        {
                            if (c.Name == leftPanel)
                            {
                                leftPanel = "";
                                foreach (Control c2 in c.Controls)
                                {
                                    if (c.Controls.Count > 0 && c2.BackColor == Color.Gold)
                                    {
                                        c.Controls.Remove(c2);
                                        myCounter--;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (rightJump != null && myJumpRight == p.Name)
                {
                    foreach (Control c in myField.Controls)
                    {
                        if (c is Panel)
                        {
                            if (c.Name == rightPanel)
                            {
                                rightPanel = "";
                                foreach (Control c2 in c.Controls)
                                {
                                    if (c.Controls.Count > 0 && c2.BackColor == Color.Gold)
                                    {
                                        c.Controls.Remove(c2);
                                        myCounter--;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                this.myPieces.Text = "" + myCounter;
                if (p.Name.Contains("A") || p.Name.Contains("H"))
                {
                    b.Text = "Q";
                }
            }
            //resetColors();
            Thread.Sleep(1000);
            startMyTurn();
        }

        private void moveToNewPos(Panel p,Button b)
        {
            if(p.BackColor == Color.Blue)
            {
                p.Controls.Add(b);
                if(leftJump != null && myJumpLeft == p.Name)
                {
                    foreach (Control c in myField.Controls)
                    {
                        if (c is Panel)
                        {
                            if (c.Name == leftPanel)
                            {
                                leftPanel = "";
                                foreach (Control c2 in c.Controls)
                                {
                                    if (c.Controls.Count > 0 && c2.BackColor == Color.Brown)
                                    {
                                        c.Controls.Remove(c2);
                                        myEnemyCounter--;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (rightJump != null && myJumpRight == p.Name)
                {
                    foreach (Control c in myField.Controls)
                    {
                        if (c is Panel)
                        {
                            if (c.Name == rightPanel)
                            {
                                rightPanel = "";
                                foreach (Control c2 in c.Controls)
                                {
                                    if (c.Controls.Count > 0 && c2.BackColor == Color.Brown)
                                    {
                                        c.Controls.Remove(c2);
                                        myEnemyCounter--;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                
                this.enemyPieces.Text = "" + myEnemyCounter;
                if (p.Name.Contains("A")|| p.Name.Contains("H"))
                {
                    b.Text = "Q";
                }
                /*foreach(Control c in myField.Controls)
                {
                    if(c is Panel)
                    {
                        if(c.Controls.Contains(b) && c.BackColor != Color.Blue)
                        {
                            //c.Controls.Remove(b);
                        }
                    }
                }*/
            }
            //resetColors();
            endMyTurn();
        }

        private void enemyMoves(Button b)
        {
            resetColors();
            leftJump = null;
            rightJump = null;
            bool myPiece = false;
            currentPiece = b;
            string piecePos = "";
            foreach (Control c in myField.Controls)
            {
                if (c is Panel)
                {
                    if (c.Controls.Contains(b))
                    {
                        piecePos = c.Name;
                    }
                }
            }

            string row = "" + piecePos[0];
            int column = Int32.Parse("" + piecePos[1]);
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (b.Text != "")
            {
                doubleMove(row, column, alphabet,Color.Brown);
            }
            else
            {
                int indexOfRow = alphabet.IndexOf(row);
                string topLeft = alphabet[indexOfRow - 1] + "" + (column - 1);
                string topRight = alphabet[indexOfRow - 1] + "" + (column + 1);

                foreach (Control c in myField.Controls)
                {
                    myPiece = false;
                    if (c is Panel)
                    {
                        //Check for normal Turn left or right
                        if (c.Controls.Count == 0 && c.Name == topLeft || c.Controls.Count == 0 && c.Name == topRight)
                        {
                            if (nextMovePossible)
                            {
                                //endMyTurn();
                                nextMovePossible = false;
                                return;
                            }
                            if (c.Name == topLeft)
                            {
                                leftPanel = c.Name;
                                leftJump = (Panel)c;
                                myJumpLeft = c.Name;
                            }
                            else if (c.Name == topRight)
                            {
                                rightPanel = c.Name;
                                rightJump = (Panel)c;
                                myJumpRight = c.Name;
                            }
                            c.BackColor = Color.Blue;
                        }
                        else if (c.Controls.Count != 0 && c.Name == topLeft || c.Controls.Count != 0 && c.Name == topRight)
                        {
                            foreach (Control c3 in c.Controls)
                            {
                                if (c3 is Button && c3.BackColor == Color.Brown)
                                {
                                    myPiece = true;
                                }
                            }
                            if (!myPiece)
                            {
                                string jumpPiecePos = c.Name;
                                string jumpRow = "" + jumpPiecePos[0];
                                int jumpColumn = Int32.Parse("" + jumpPiecePos[1]);

                                int nextindexOfRow = alphabet.IndexOf(jumpRow);
                                string jumptopLeft = "";
                                string jumptopRight = "";
                                if (c.Name == topLeft)
                                {
                                    if (nextindexOfRow > 0)
                                    {
                                        leftJump = (Panel)c;
                                        jumptopLeft = alphabet[nextindexOfRow - 1] + "" + (jumpColumn - 1);
                                        leftPanel = c.Name;
                                        myJumpLeft = jumptopLeft;
                                    }
                                }
                                else
                                {
                                    if (nextindexOfRow > 0)
                                    {
                                        rightJump = (Panel)c;
                                        jumptopRight = alphabet[nextindexOfRow - 1] + "" + (jumpColumn + 1);
                                        rightPanel = c.Name;
                                        myJumpRight = jumptopRight;
                                    }
                                }

                                foreach (Control c2 in myField.Controls)
                                {
                                    if (c2 is Panel)
                                    {
                                        if (c2.Controls.Count == 0 && c2.Name == jumptopLeft || c2.Controls.Count == 0 && c2.Name == jumptopRight)
                                        {
                                            c2.BackColor = Color.Blue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            nextMovePossible = false;
            return;
        }

        private void doubleMove(string row, int column,string alphabet,Color myColor)
        {
            bool myPiece = false;
            leftJump = null;
            rightJump = null;
            int indexOfRow = alphabet.IndexOf(row);
            string topLeft = alphabet[indexOfRow + 1] + "" + (column - 1);
            string topRight = alphabet[indexOfRow + 1] + "" + (column + 1);

            foreach (Control c in myField.Controls)
            {
                myPiece = false;
                if (c is Panel)
                {
                    //Check for normal Turn left or right
                    if (c.Controls.Count == 0 && c.Name == topLeft || c.Controls.Count == 0 && c.Name == topRight)
                    {
                        if (nextMovePossible)
                        {
                            //endMyTurn();
                            nextMovePossible = false;
                            return;
                        }
                        if (c.Name == topLeft)
                        {
                            leftPanel = c.Name;
                            leftJump = (Panel)c;
                            myJumpLeft = c.Name;
                        }
                        else if (c.Name == topRight)
                        {
                            rightPanel = c.Name;
                            rightJump = (Panel)c;
                            myJumpRight = c.Name;
                        }
                        c.BackColor = Color.Blue;
                    }
                    else if (c.Controls.Count != 0 && c.Name == topLeft || c.Controls.Count != 0 && c.Name == topRight)
                    {
                        foreach (Control c3 in c.Controls)
                        {
                            if (c3 is Button && c3.BackColor == myColor)
                            {
                                myPiece = true;
                            }
                        }
                        if (!myPiece)
                        {
                            string jumpPiecePos = c.Name;
                            string jumpRow = "" + jumpPiecePos[0];
                            int jumpColumn = Int32.Parse("" + jumpPiecePos[1]);

                            int nextindexOfRow = alphabet.IndexOf(jumpRow);
                            string jumptopLeft = "";
                            string jumptopRight = "";
                            if (c.Name == topLeft)
                            {
                                leftJump = (Panel)c;
                                jumptopLeft = alphabet[nextindexOfRow + 1] + "" + (jumpColumn - 1);
                                leftPanel = c.Name;
                                myJumpLeft = jumptopLeft;

                            }
                            else
                            {
                                rightJump = (Panel)c;
                                jumptopRight = alphabet[nextindexOfRow + 1] + "" + (jumpColumn + 1);
                                rightPanel = c.Name;
                                myJumpRight = jumptopRight;
                            }

                            foreach (Control c2 in myField.Controls)
                            {
                                if (c2 is Panel)
                                {
                                    if (c2.Controls.Count == 0 && c2.Name == jumptopLeft || c2.Controls.Count == 0 && c2.Name == jumptopRight)
                                    {
                                        c2.BackColor = Color.Blue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //-----------------------------------------------------

            indexOfRow = alphabet.IndexOf(row);
            if (indexOfRow > 0)
            {
                topLeft = alphabet[indexOfRow - 1] + "" + (column - 1);
                topRight = alphabet[indexOfRow - 1] + "" + (column + 1);
            }

            foreach (Control c in myField.Controls)
            {
                myPiece = false;
                if (c is Panel)
                {
                    //Check for normal Turn left or right
                    if (c.Controls.Count == 0 && c.Name == topLeft || c.Controls.Count == 0 && c.Name == topRight)
                    {
                        if (nextMovePossible)
                        {
                            //endMyTurn();
                            nextMovePossible = false;
                            return;
                        }
                        if (c.Name == topLeft)
                        {
                            leftPanel = c.Name;
                            myJumpLeft = c.Name;
                            leftJump = (Panel)c;
                        }
                        else if (c.Name == topRight)
                        {
                            rightPanel = c.Name;
                            myJumpRight = c.Name;
                            rightJump = (Panel)c;
                        }
                        c.BackColor = Color.Blue;
                    }
                    else if (c.Controls.Count != 0 && c.Name == topLeft || c.Controls.Count != 0 && c.Name == topRight)
                    {
                        foreach (Control c3 in c.Controls)
                        {
                            if (c3 is Button && c3.BackColor == myColor)
                            {
                                myPiece = true;
                            }
                        }
                        if (!myPiece)
                        {
                            string jumpPiecePos = c.Name;
                            string jumpRow = "" + jumpPiecePos[0];
                            int jumpColumn = Int32.Parse("" + jumpPiecePos[1]);

                            int nextindexOfRow = alphabet.IndexOf(jumpRow);
                            string jumptopLeft = "";
                            string jumptopRight = "";
                            if (c.Name == topLeft)
                            {
                                if (nextindexOfRow > 0)
                                {
                                    leftJump = (Panel)c;
                                    jumptopLeft = alphabet[nextindexOfRow - 1] + "" + (jumpColumn - 1);
                                    leftPanel = c.Name;
                                    myJumpLeft = jumptopLeft;
                                }
                            }
                            else
                            {
                                if (nextindexOfRow > 0)
                                {
                                    rightJump = (Panel)c;
                                    jumptopRight = alphabet[nextindexOfRow - 1] + "" + (jumpColumn + 1);
                                    rightPanel = c.Name;
                                    myJumpRight = jumptopRight;
                                }
                            }

                            foreach (Control c2 in myField.Controls)
                            {
                                if (c2 is Panel)
                                {
                                    if (c2.Controls.Count == 0 && c2.Name == jumptopLeft || c2.Controls.Count == 0 && c2.Name == jumptopRight)
                                    {
                                        c2.BackColor = Color.Blue;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        private void myMoves (Button b)
        {
            resetColors();
            leftJump = null;
            rightJump = null;
            bool myPiece = false;
            currentPiece = b;
            string piecePos = "";
            foreach (Control c in myField.Controls)
            {
                if (c is Panel)
                {
                    if (c.Controls.Contains(b))
                    {
                        piecePos = c.Name;
                    }
                }
            }
            
            string row = ""+piecePos[0];
            int column = Int32.Parse(""+piecePos[1]);
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (b.Text != "")
            {
                doubleMove(row,column,alphabet,Color.Gold);
            }
            else
            {
                int indexOfRow = alphabet.IndexOf(row);
                string topLeft = alphabet[indexOfRow+1] + "" + (column - 1);
                string topRight = alphabet[indexOfRow+1] + "" + (column + 1);

                foreach (Control c in myField.Controls)
                {
                    myPiece = false;
                    if (c is Panel)
                    {
                        //Check for normal Turn left or right
                        if (c.Controls.Count == 0 && c.Name == topLeft || c.Controls.Count == 0 && c.Name == topRight)
                        {
                            if(nextMovePossible)
                            {
                                //endMyTurn();
                                nextMovePossible = false;
                                return;
                            }
                            if (c.Name == topLeft)
                            {
                                leftPanel = c.Name;
                                myJumpLeft = c.Name;
                                leftJump = (Panel)c;
                            }
                            else if (c.Name == topRight)
                            {
                                rightPanel = c.Name;
                                myJumpRight = c.Name;
                                rightJump = (Panel)c;
                            }
                            c.BackColor = Color.Blue;
                        }
                        else if (c.Controls.Count != 0 && c.Name == topLeft || c.Controls.Count != 0 && c.Name == topRight)
                        {

                            foreach (Control c3 in c.Controls)
                            {
                                if(c3 is Button && c3.BackColor == Color.Gold)
                                {
                                    myPiece = true;
                                }
                            }
                            if (!myPiece)
                            {
                                string jumpPiecePos = c.Name;
                                string jumpRow = "" + jumpPiecePos[0];
                                int jumpColumn = Int32.Parse("" + jumpPiecePos[1]);

                                int nextindexOfRow = alphabet.IndexOf(jumpRow);
                                string jumptopLeft = "";
                                string jumptopRight = "";
                                if (c.Name == topLeft)
                                {
                                    leftJump = (Panel)c;
                                    leftPanel = c.Name;
                                    jumptopLeft = alphabet[nextindexOfRow + 1] + "" + (jumpColumn - 1);
                                    myJumpLeft = jumptopLeft;
                                    
                                }
                                else
                                {
                                    rightJump = (Panel)c;
                                    rightPanel = c.Name;
                                    jumptopRight = alphabet[nextindexOfRow + 1] + "" + (jumpColumn + 1);
                                    myJumpRight = jumptopRight;
                                }

                                foreach (Control c2 in myField.Controls)
                                {
                                    if (c2 is Panel)
                                    {
                                        if (c2.Controls.Count == 0 && c2.Name == jumptopLeft || c2.Controls.Count == 0 && c2.Name == jumptopRight)
                                        {
                                            c2.BackColor = Color.Blue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            nextMovePossible = false;
            return;
        }

        private void start_Click(object sender, EventArgs e)
        {
            chooseTurn();
        }
    }
}
