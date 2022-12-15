using Lab2.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab2
{
    internal class GameButton: Button, INotifyPropertyChanged
    {
        private WordHolder wordHolder;
        private bool isPressed;
        private ICommand command;
        public ICommand Command
        {
            get { return command; }
            set {  command = value; }
        }
        public GameButton(WordHolder _wordHolder)
        {
            this.wordHolder = _wordHolder;
            this.Background = Brushes.White;
            this.Content = wordHolder.Word;
            this.isPressed = false;
            this.Command = new SimpleCommand(onClick);
        }

        public void onClick(object parameter)
        {
            if (!isPressed)
            {
                if (wordHolder.Right)
                {
                    Background = Brushes.Green;
                    isPressed = true;
                }
                else
                {
                    Background = Brushes.Red;
                    isPressed = true;
                }
            }
            MessageBox.Show("");
            OnPropertyChanged("Background");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
