using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class DanceState : BaseState
    {
        public DanceState(Form1 form)
            : base(form)
        {
            this.maxTime = 218;
            this.form.SetTime(112);
        }

        public override void Reset()
        {
            this.form.SetState(new Face1(form));
        }
    }
}
