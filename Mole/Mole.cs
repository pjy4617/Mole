using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mole
{
    class Mole
    {
        public delegate void PopUp(int hole, bool show);
        private PopUp popUpCallback;
        private bool hidden;
        public bool Hidden { get { return hidden; } }
        private int timesHit = 0;
        private int timesShown = 0;
        private int hole = 0;
        Random random;

        public Mole(Random random, PopUp popUpcallback)
        {
            if (popUpcallback == null)
                throw new ArgumentException("PopupCallback can't be null");
            this.random = random;
            this.popUpCallback += popUpcallback;
            hidden = true;
        }
        public void Show()
        {
            timesShown++;
            hidden = false;
            hole = random.Next(5);
            popUpCallback(hole, true);//두더지가 자기자신을 보여준 후에 버튼의 색을 붉은색으로, 텍스트를 "Hit me"로 변경해서 두더지를 보여주는 폼에 있는 메소드를 호출해야 함
        }
        public void HideAgain()
        {
            hidden = true;
            popUpCallback(hole, false);
            CheckForGameOver();
        }
        public void Smacked(int holeSmacked)
        {
            if(holeSmacked == hole)
            {
                timesHit++;
                hidden = true;
                CheckForGameOver();
                popUpCallback(hole, false);
            }
        }
        private void CheckForGameOver()
        {
            if(timesShown >= 10)
            {
                popUpCallback(-1, false);
                MessageBox.Show("You scored" + timesHit, "Game over");
                Application.Exit();
            }
        }
    }
}
