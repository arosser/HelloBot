using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class BadAnswer : BaseState
    {
        public BadAnswer(Form1 form)
            : base(form)
        {
            this.form.SetTime(10.5);
            this.maxTime = 4;
        }

        public override void Reset()
        {
            form.SetTime(10.5);
        }
    }
}
