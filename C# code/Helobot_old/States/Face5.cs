using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class Face5 : BaseState
    {
        public Face5(Form1 form)
            : base(form)
        {
            this.form.SetTime(20);
        }

        public override void Reset()
        {
            form.SetTime(20);
        }
    }
}
