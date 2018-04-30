using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace U3_Austin_Sum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        string word = " ";
        int randNum = 0;
        string lettrGuess = " ";
        int wrongGuess = 0;
        public MainWindow()
        {
            InitializeComponent();

            randNum = random.Next(1, 10);//pick number 1-9
            MessageBox.Show(randNum.ToString());

            StreamReader streamReader = new StreamReader("TextFile1.txt");

          //  lettrGuess = txtboxGuessLetter.Text;

            int counter = 0;
            while (counter != randNum)
            {
                string temp = streamReader.ReadLine();
                counter++;
                word = temp;
            }
            word = word.ToUpper();
            MessageBox.Show(word);

            string UnknownWord = "_ ";
            for (int i = 0; i < word.Length; i++)
            {
                UnknownWord += "_ ";
                Console.WriteLine(i.ToString());
            }
            lblWord.Text = UnknownWord;
           // MessageBox.Show("Wait for it....");
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(lblWord.Text);
            lettrGuess = txtboxGuessLetter.Text;
            lettrGuess = lettrGuess.ToUpper();
            MessageBox.Show(lettrGuess);
            string UnknownWord = lblWord.Text;
            bool lettrInWord = false;
            //Was letter guessed?
            if (lblUsed.Content.ToString().IndexOf(lettrGuess) >= 0)
            {
                MessageBox.Show("You guessed that already you schmuck.");//McT is so polite.content.baaaadddd
            }
            else
            {
                //letter wasn't guessed before

                //create buildWord set it to ""
                string buildWord = "";
                //loop through the letters in the word
                for (int i = 0; i<word.Length; i++)
                {
                    //check if letter matches guessed letter
                    if (lettrGuess == word[i].ToString())
                    {
                        //use the guessed letter to buildWord and add space
                        buildWord += word[i].ToString() + " ";
                   //     MessageBox.Show("BLAW");
                        //set our boolean variable to true
                        lettrInWord = true;
                    }
                    //if not matching guessed letter
                    else
                    {
                        //use UnknownWord letter at that spot (x2) and add space
                        buildWord += UnknownWord[i * 2].ToString() + " ";

                    }

                }
                lblWord.Text = buildWord;
                lblUsed.Content += lettrGuess;
                //if not letterFound
                if (!lettrInWord)
                {
                    //add one to wrong guesses
                    wrongGuess++;
                }
                
            }
            //check if wrong guesses is 6 or more
            if (wrongGuess >= 6)
            {
                //game over
                MessageBox.Show("Game Over, You Lose");
            }
               
           // MessageBox.Show(lblUsed.Content.ToString());
          //  MessageBox.Show(lblUsed.Content.ToString().IndexOf(lettrGuess).ToString());
        }
    }
}
