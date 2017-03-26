using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class Face4 : BaseState
    {
        public Face4(Form1 form)
            : base(form)
        {
            this.form.SetTime(15);
        }

        public override void Reset()
        {
            this.form.SetState(new Face1(form));
        }
    }
}
