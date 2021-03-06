﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helobot
{
    public class SongState : BaseState
    {

        float danceInterval = 5.5f;

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

        public override void AddTime()
        {
            time += 0.5f;
            if (time >= maxTime)
            {
                time = 0f;
                Reset();
            }

            danceInterval += 0.5f;
            if (danceInterval >= 5.5f)
            {
                danceInterval = 0;
                form.SendSerial("c");
            }

            
        }
    }
}
