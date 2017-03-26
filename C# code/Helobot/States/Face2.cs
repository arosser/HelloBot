using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class Face2 : BaseState
    {
        public Face2(Form1 form)
            : base(form)
        {
            this.form.SetTime(5);
        }

        public override void Reset()
        {
            this.form.SetState(new Face1(form));
        }
    }
}
