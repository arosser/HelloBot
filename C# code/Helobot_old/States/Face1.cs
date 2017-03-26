using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class Face1 : BaseState
    {
        public Face1(Form1 form)
            : base(form)
        {
            this.form.SetTime(0);
        }

        public override void Reset()
        {
            this.form.SetTime(0);
        }
    }
}
