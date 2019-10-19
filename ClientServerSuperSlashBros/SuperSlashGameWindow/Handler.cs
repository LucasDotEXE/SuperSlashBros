using System.Collections.Generic;
using System.Timers;
using System.Windows.Input;
using Test;

namespace SuperSLashWPF
{
    class Handler
    {
        private HashSet<Key> keys;
        private CharacterHandler OwnCharacter;
        private CharacterHandler OtherCharacter;
        private MapHandler maphandler;

        private MainWindow mainWindow;

        private Timer timer;

        public Handler(HashSet<Key> keys, MainWindow mainWindow)
        {
            this.maphandler = new MapHandler();

            this.keys = keys;
            this.OwnCharacter = new CharacterHandler(this.keys);
            this.OtherCharacter = new CharacterHandler(new HashSet<Key>());
            this.mainWindow = mainWindow;
            setTimer(1);
        }

        public void setKeys(HashSet<Key> keys)
        {
            this.keys = keys;
            this.OwnCharacter.setKeys(this.keys);
        }

        public void setTimer(int time)
        {
            this.timer = new Timer(time);
            this.timer.Elapsed += handle;
            this.timer.Elapsed += this.mainWindow.handle;
            this.timer.Enabled = true;
        }

        public void handle(object source, ElapsedEventArgs e)
        {
            if (OwnCharacter != null)
            {
                this.OwnCharacter.Handle(this.maphandler);
            }
            if (OtherCharacter != null)
            {
                this.OtherCharacter.Handle(this.maphandler);
            }

        }

        public CharacterHandler GetCharacterHandler(int i)
        {
            if (i == 1 && OwnCharacter != null)
            {
                return OwnCharacter;
            } else if (i == 2 && OtherCharacter != null) {
                return OtherCharacter;
            }
            else
            {
                return null;
            }
        }

        public MapHandler GetMapHandler() {
            return this.maphandler;
        }
    }
}
