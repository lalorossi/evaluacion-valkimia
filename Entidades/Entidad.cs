﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Entidad
    {
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified,
        }
        public Entidad()
        {
            this.State = States.New;
        }
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private States _State;
        public States State
        {
            get { return _State; }
            set { _State = value; }
        }
    }
}
