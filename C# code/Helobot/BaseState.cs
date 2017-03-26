using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class BaseState
    {
        public float time = 0;
        public float maxTime = 4.5f;
        public Form1 form = null;

        public BaseState(Form1 form)
        {
            this.form = form;
        }

        public void AddTime()
        {
            time += 0.5f;
            if (time >= maxTime)
            {
                time = 0f;
                Reset();
            }
        }

        public virtual void Reset()
        {
            form.SetTime(0);
        }
    }
}
