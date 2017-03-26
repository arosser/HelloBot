using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class GoodAnswer : BaseState
    {
        public GoodAnswer(Form1 form)
            : base(form)
        {
            this.form.SetTime(25.5);
            this.maxTime = 1;
        }

        public override void Reset()
        {
            form.SetTime(25.5);
        }
    }
}
