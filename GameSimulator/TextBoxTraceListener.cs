using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameSimulator
{
    public class TextBoxTraceListener : TraceListener
    {
        private TextBox _textBox;

        public TextBoxTraceListener(TextBox textBox)
        {
            _textBox = textBox;
        }

        public override void Write(string message)
        {
            _textBox.AppendText(message);
        }

        public override void WriteLine(string message)
        {
            _textBox.AppendText(message + Environment.NewLine);
        }
    }
}
