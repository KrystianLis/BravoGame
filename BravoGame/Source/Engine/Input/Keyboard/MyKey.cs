namespace BravoGame
{
    /// <summary>
    /// The my key.
    /// </summary>
    public class MyKey
    {
        /// <summary>
        /// The key.
        /// </summary>
        public string Key, Print, Display;

        /// <summary>
        /// The state.
        /// </summary>
        public int State;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyKey"/> class.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        public MyKey(string key, int state)
        {
            this.Key = key;
            this.State = state;
            this.MakePrint(this.Key);
        }

        /// <summary>
        /// The make print.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void MakePrint(string key)
        {
            this.Display = key;

            var tempStr = "";

            if (key == "A" || key == "B" || key == "C" || key == "D" || key == "E" || key == "F" || key == "G"
                || key == "H" || key == "I" || key == "J" || key == "K" || key == "L" || key == "M" || key == "N"
                || key == "O" || key == "P" || key == "Q" || key == "R" || key == "S" || key == "T" || key == "U"
                || key == "V" || key == "W" || key == "X" || key == "Y" || key == "Z")
            {
                tempStr = key;
            }
            if (key == "Space")
            {
                tempStr = " ";
            }
            if (key == "OemCloseBrackets")
            {
                tempStr = "]";
                this.Display = tempStr;
            }
            if (key == "OemOpenBrackets")
            {
                tempStr = "[";
                this.Display = tempStr;
            }
            if (key == "OemMinus")
            {
                tempStr = "-";
                this.Display = tempStr;
            }
            if (key == "OemPeriod" || key == "Decimal")
            {
                tempStr = ".";
            }
            if (key == "D1" || key == "D2" || key == "D3" || key == "D4" || key == "D5" || key == "D6" || key == "D7"
                || key == "D8" || key == "D9" || key == "D0")
            {
                tempStr = key.Substring(1);
            }
            else if (key == "NumPad1" || key == "NumPad2" || key == "NumPad3" || key == "NumPad4" || key == "NumPad5"
                     || key == "NumPad6" || key == "NumPad7" || key == "NumPad8" || key == "NumPad9"
                     || key == "NumPad0")
            {
                tempStr = key.Substring(6);
            }

            this.Print = tempStr;
        }

        /// <summary>
        /// The update.
        /// </summary>
        public virtual void Update()
        {
            this.State = 2;
        }
    }
}