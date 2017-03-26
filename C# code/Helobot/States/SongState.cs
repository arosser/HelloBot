using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class SongState : BaseState
    {
        public SongState(Form1 form)
            : base(form)
        {
            this.maxTime = 84;
            this.form.SetTime(27);
        }

        public override void Reset()
        {
            this.form.SetState(new Face1(form));
        }
    }
}
