using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using Lab2.Commands;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Lab2
{
    internal class theGameView: INotifyPropertyChanged
    {
        private int wordNum;
        private bool allRightPressed;
        private ObservableCollection<GameButton> buttons;
        private List<GameButton> rightButtons;
        private Visibility victory;
        int pressedCount;
        public int WordNum { get { return wordNum; } set { wordNum = value; } }
        public ObservableCollection<GameButton> Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }
        public bool AlRightlPressed
        {
            get
            {
                foreach (GameButton button in rightButtons)
                {
                    if (!button.IsPressed)
                        return false;
                }
                allRightPressed = true;
                return true;
            }
        }

        public int PressedCount
        {
            get
            {
                pressedCount = 0;
                foreach (GameButton button in buttons)
                {
                    if (button.IsPressed)
                        pressedCount++;
                }
                return pressedCount;
            }
        }

        public Visibility Victory
        {
            get
            {
                if (allRightPressed && pressedCount == rightButtons.Count)
                    victory = Visibility.Visible;
                return victory;
            }
        }
        public theGameView()
        {
            StartGame = new SimpleCommand(startGameFunc);
            wordNum= 0;
            victory = Visibility.Hidden;
            OnPropertyChanged("WordNum");
        }

        public ICommand StartGame { get; set; }
        private void startGameFunc(object parameter)
        {
            OnPropertyChanged("WordNum");
            if (WordNum > 0)
            {
                allRightPressed = false;
                List<string> words = new List<string>() {"cat", "pet", "carrot", "plane",
                                                        "car", "village", "villain", "course",
                                                        "letter", "meeting",
                                                        "waste", "jar", "magic", "lion", "love", "market"};
                List<GameButton> _buttons = new List<GameButton>();
                Random r = new Random();
                if (wordNum < words.Count / 2)
                {
                    
                    rightButtons = new List<GameButton>();
                    words = words.OrderBy(x => (float)r.NextDouble()).ToList();


                    for (int i = 0; i < wordNum; i++)
                    {
                        GameButton curButton = new GameButton(new WordHolder(words[0], true));
                        rightButtons.Add(curButton);
                        _buttons.Add(curButton);
                        words.RemoveAt(0);
                    }
                    for (int i = 0; i < wordNum; i++)
                    {
                        GameButton curButton = new GameButton(new WordHolder(words[0], false));
                        _buttons.Add(curButton);
                        words.RemoveAt(0);
                    }
                    _buttons = _buttons.OrderBy(x => (float)r.NextDouble()).ToList();
                }
                buttons = new ObservableCollection<GameButton>(_buttons);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
